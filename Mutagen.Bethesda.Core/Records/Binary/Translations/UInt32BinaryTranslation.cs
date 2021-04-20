using Mutagen.Bethesda.Records.Binary.Streams;

namespace Mutagen.Bethesda.Records.Binary.Translations
{
    public class UInt32BinaryTranslation : PrimitiveBinaryTranslation<uint>
    {
        public readonly static UInt32BinaryTranslation Instance = new UInt32BinaryTranslation();
        public override int ExpectedLength => 4;

        public override uint ParseValue(MutagenFrame reader)
        {
            return reader.Reader.ReadUInt32();
        }

        public override void Write(MutagenWriter writer, uint item)
        {
            writer.Write(item);
        }
    }
}