using Loqui;
using Loqui.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Generation
{
    public class GameEnvironmentStateModule : GenerationModule
    {
        List<ObjectGeneration> mods = new List<ObjectGeneration>();


        public override async Task PreLoad(ObjectGeneration obj)
        {
            if (obj.GetObjectType() == Binary.ObjectType.Mod)
            {
                mods.Add(obj);
            }
        }

        public override async Task FinalizeGeneration(ProtocolGeneration proto)
        {
            await base.FinalizeGeneration(proto);

            if (proto.Protocol.Namespace != "All") return;
            await Task.WhenAll(proto.Gen.Protocols.Values.SelectMany(p => p.ObjectGenerationsByID.Values.Select(o => o.LoadingCompleteTask.Task)));

            FileGeneration fg = new FileGeneration();

            foreach (var modObj in mods)
            {
                fg.AppendLine($"using Mutagen.Bethesda.{modObj.ProtoGen.Protocol.Namespace};");
            }
            fg.AppendLine();

            using (new NamespaceWrapper(fg, "Mutagen.Bethesda"))
            {
                using (var c = new ClassWrapper(fg, "GameEnvironmentMixIn"))
                {
                    c.Static = true;
                }
                using (new BraceWrapper(fg))
                {
                    foreach (var modObj in mods)
                    {
                        var relStr = modObj.GetObjectData().HasMultipleReleases ? $"{modObj.GetObjectData().GameCategory}Release gameRelease" : string.Empty;
                        var retType = $"GameEnvironmentState<I{modObj.Name}, I{modObj.Name}Getter>";
                        using (var args = new FunctionWrapper(fg,
                            $"public static {retType} {modObj.ProtoGen.Protocol.Namespace}"))
                        {
                            args.Add($"this {nameof(GameEnvironment)} env");
                            if (modObj.GetObjectData().HasMultipleReleases)
                            {
                                args.Add(modObj.GetObjectData().HasMultipleReleases ? $"{modObj.GetObjectData().GameCategory}Release gameRelease" : string.Empty);
                            }
                            args.Add($"{nameof(LinkCachePreferences)}? linkCachePrefs = null");
                        }
                        using (new BraceWrapper(fg))
                        {
                            fg.AppendLine($"return env.Construct<I{modObj.Name}, I{modObj.Name}Getter>({(modObj.GetObjectData().HasMultipleReleases ? "gameRelease.ToGameRelease()" : $"GameRelease.{modObj.ProtoGen.Protocol.Namespace}")}, linkCachePrefs);");
                        }
                        fg.AppendLine();
                    }
                }
            }

            var path = Path.Combine(proto.DefFileLocation.FullName, $"../Utility/GameEnvironmentMixIn{Loqui.Generation.Constants.AutogeneratedMarkerString}.cs");
            fg.Generate(path);
            proto.GeneratedFiles.Add(path, ProjItemType.Compile);
        }
    }
}