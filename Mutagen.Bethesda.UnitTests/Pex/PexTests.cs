using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using FluentAssertions;
using Mutagen.Bethesda.Pex;
using Xunit;

namespace Mutagen.Bethesda.UnitTests.Pex
{
    public class PexTests
    {
        public static readonly IEnumerable<object[]> TestDataFiles = new List<object[]>
        {
            //from SKSE https://skse.silverlock.org
            new object[]{ "Actor.pex", GameCategory.Skyrim },
            new object[]{ "Art.pex", GameCategory.Skyrim },
            new object[]{ "FormType.pex", GameCategory.Skyrim },
            new object[]{ "Game.pex", GameCategory.Skyrim },
            new object[]{ "ObjectReference.pex", GameCategory.Skyrim },
            new object[]{ "Outfit.pex", GameCategory.Skyrim },
            new object[]{ "SoulGem.pex", GameCategory.Skyrim },
            
            //from F4SE https://f4se.silverlock.org
            new object[]{ "ActorBase-F04.pex", GameCategory.Fallout4 },
            
            //from https://github.com/mwilsnd/SkyrimSE-SmoothCam/blob/master/CodeGen/MCM/SmoothCamMCM.pex
            new object[]{ "SmoothCamMCM.pex", GameCategory.Skyrim },
            
            //from https://www.nexusmods.com/skyrimspecialedition/mods/18076
            new object[]{ "nwsFollowerMCMExScript.pex", GameCategory.Skyrim },
            new object[]{ "nwsFollowerMCMScript.pex", GameCategory.Skyrim },
        };

        [Theory]
        [MemberData(nameof(TestDataFiles))]
        public void TestPexParsing(string file, GameCategory gameCategory)
        {
            var path = Path.Combine("Pex", "files", file);
            Assert.True(File.Exists(path));

            var pex = PexFile.CreateFromFile(path, gameCategory);
            Assert.NotNull(pex);
        }

        [Theory]
        [MemberData(nameof(TestDataFiles))]
        public void TestPexWriting(string file, GameCategory gameCategory)
        {
            var inputFile = Path.Combine("Pex", "files", file);
            Assert.True(File.Exists(inputFile));

            var inputPex = PexFile.CreateFromFile(inputFile, gameCategory);

            var outputFile = Path.Combine("output", file);
            inputPex.WritePexFile(outputFile, gameCategory);
            Assert.True(File.Exists(outputFile));

            var outputPex = PexFile.CreateFromFile(outputFile, gameCategory);
            Assert.NotNull(outputPex);

            var inputFi = new FileInfo(inputFile);
            var outputFi = new FileInfo(outputFile);

            Assert.Equal(inputFi.Length, outputFi.Length);

            var inputHash = SHA256.HashData(File.ReadAllBytes(inputFile));
            var outputHash = SHA256.HashData(File.ReadAllBytes(outputFile));

            Assert.Equal(inputHash, outputHash);
        }

        [Fact]
        public void TestSinglePexParsing()
        {
            var path = Path.Combine("Pex", "files", "Art.pex");
            Assert.True(File.Exists(path));

            var pex = PexFile.CreateFromFile(path, GameCategory.Skyrim);

            Assert.Equal(3, pex.MajorVersion);
            Assert.Equal(2, pex.MinorVersion);
            Assert.Equal(1, pex.GameId);
            Assert.Equal(((ulong)0x5F21B0ED).ToDateTime(), pex.CompilationTime);
            Assert.Equal("Art.psc", pex.SourceFileName);
            Assert.Equal(string.Empty, pex.Username);
            Assert.Equal(string.Empty, pex.MachineName);

            var debugInfo = pex.DebugInfo;
            Assert.NotNull(debugInfo);

            {
                Assert.Equal(4, debugInfo!.Functions.Count);
            }

            var objects = pex.Objects;
            Assert.Single(objects);

            var mainObject = objects.First();

            Assert.Equal("Art", mainObject.Name);
            Assert.Equal("Form", mainObject.ParentClassName);
            Assert.Equal(string.Empty, mainObject.DocString);
            Assert.Equal(string.Empty, mainObject.AutoStateName);

            Assert.Empty(mainObject.Properties);
            Assert.Empty(mainObject.Variables);
            Assert.Single(mainObject.States);

            var state = mainObject.States.First();
            Assert.Equal(string.Empty, state.Name);
            Assert.Equal(4, state.Functions.Count);
        }

        [Fact]
        public void TestPexAddition()
        {
            var path = Path.Combine("Pex", "files", "Art.pex");
            Assert.True(File.Exists(path));

            var pex = PexFile.CreateFromFile(path, GameCategory.Skyrim);
            var functionToAdd = new DebugFunction(pex)
            {
                FunctionName = "HelloWorld",
                FunctionType = DebugFunctionType.Method,
            };
            pex.DebugInfo?.Functions.Add(functionToAdd);

            using var tempFolder = Utility.GetTempFolder(nameof(PexTests));
            var outPath = Path.Combine(tempFolder.Dir.Path, Path.GetTempFileName());
            pex.WritePexFile(outPath, GameCategory.Skyrim);

            var pex2 = PexFile.CreateFromFile(outPath, GameCategory.Skyrim);
            pex2.DebugInfo.Should().NotBeNull();
            pex2.DebugInfo!.Functions.Should().HaveCount(pex.DebugInfo!.Functions.Count);
            pex2.DebugInfo!.Functions[^1].FunctionName.Should().Be(functionToAdd.FunctionName);
        }
    }
}
