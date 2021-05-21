﻿using System.IO;
using FluentAssertions;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Skyrim;
using Xunit;

namespace Mutagen.Bethesda.UnitTests
{
    public class SkyrimPerk_Test
    {
        [Fact]
        public void FunctionParametersTypeNone()
        {
            byte[] b = new byte[]
            {
                0x50, 0x45, 0x52, 0x4B, 0x3C, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x24, 0xE1, 0x0B, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x2C, 0x00, 0x0C, 0x00, 0x45, 0x44, 0x49, 0x44, 0x34, 0x00, 0x4F, 0x52, 0x44, 0x5F, 0x50, 0x69,
                0x63, 0x30, 0x30, 0x5F, 0x50, 0x69, 0x63, 0x6B, 0x70, 0x6F, 0x63, 0x6B, 0x65, 0x74, 0x4D, 0x61, 0x73, 0x74,
                0x65, 0x72, 0x79, 0x5F, 0x30, 0x30, 0x5F, 0x50, 0x65, 0x72, 0x6B, 0x5F, 0x57, 0x61, 0x73, 0x4C, 0x69, 0x67,
                0x68, 0x74, 0x46, 0x69, 0x6E, 0x67, 0x65, 0x72, 0x73, 0x00, 0x46, 0x55, 0x4C, 0x4C, 0x13, 0x00, 0x50, 0x69,
                0x63, 0x6B, 0x70, 0x6F, 0x63, 0x6B, 0x65, 0x74, 0x20, 0x4D, 0x61, 0x73, 0x74, 0x65, 0x72, 0x79, 0x00, 0x44, 
                0x45, 0x53, 0x43, 0x5E, 0x00, 0x41, 0x64, 0x64, 0x73, 0x20, 0x31, 0x25, 0x20, 0x74, 0x6F, 0x20, 0x79, 0x6F,
                0x75, 0x72, 0x20, 0x70, 0x69, 0x63, 0x6B, 0x70, 0x6F, 0x63, 0x6B, 0x65, 0x74, 0x20, 0x63, 0x68, 0x61, 0x6E, 
                0x63, 0x65, 0x20, 0x70, 0x65, 0x72, 0x20, 0x6C, 0x65, 0x76, 0x65, 0x6C, 0x20, 0x6F, 0x66, 0x20, 0x50, 0x69, 
                0x63, 0x6B, 0x70, 0x6F, 0x63, 0x6B, 0x65, 0x74, 0x2E, 0x20, 0x41, 0x6C, 0x73, 0x6F, 0x20, 0x69, 0x6E, 0x63, 
                0x72, 0x65, 0x61, 0x73, 0x65, 0x73, 0x20, 0x43, 0x61, 0x72, 0x72, 0x79, 0x20, 0x57, 0x65, 0x69, 0x67, 0x68,
                0x74, 0x20, 0x62, 0x79, 0x20, 0x32, 0x30, 0x2E, 0x00, 0x44, 0x41, 0x54, 0x41, 0x05, 0x00, 0x00, 0x00, 0x01,
                0x01, 0x00, 0x50, 0x52, 0x4B, 0x45, 0x03, 0x00, 0x01, 0x00, 0xC3, 0x44, 0x41, 0x54, 0x41, 0x04, 0x00, 0xDD, 
                0x85, 0x07, 0x03, 0x45, 0x50, 0x46, 0x54, 0x01, 0x00, 0x00, 0x50, 0x52, 0x4B, 0x46, 0x00, 0x00, 0x50, 0x52,
                0x4B, 0x45, 0x03, 0x00, 0x02, 0x00, 0xC8, 0x44, 0x41, 0x54, 0x41, 0x03, 0x00, 0x38, 0x0E, 0x03, 0x50, 0x52,
                0x4B, 0x43, 0x01, 0x00, 0x00, 0x43, 0x54, 0x44, 0x41, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0xC0, 0x01, 0x00, 0x00, 0x6A, 0x8E, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x45, 0x50, 0x46, 0x54, 0x01, 0x00, 0x02, 0x45, 0x50, 0x46, 0x44, 
                0x08, 0x00, 0x00, 0x00, 0x50, 0x41, 0x0A, 0xD7, 0x23, 0x3C, 0x50, 0x52, 0x4B, 0x46, 0x00, 0x00
            };

            var reader = new MutagenBinaryReadStream(new MemoryStream(b), ModKey.Null, GameRelease.SkyrimSE);
            var frame = new MutagenFrame(reader);
            var perk = Perk.CreateFromBinary(frame);
            perk.Effects.Should().HaveCount(2);
        }
    }
}