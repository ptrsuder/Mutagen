using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Oblivion.Internals;

namespace Mutagen.Bethesda.Oblivion
{
    public partial class PlacedObject
    {
        [Flags]
        public enum ActionFlag
        {
            UseDefault = 0x001,
            Activate = 0x002,
            Open = 0x004,
            OpenByDefault = 0x008
        }
    }

    namespace Internals
    {
        public partial class PlacedObjectBinaryTranslation
        {
            static partial void FillBinary_OpenByDefault_Custom(MutagenFrame frame, PlacedObject item, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                item.OpenByDefault = true;
                frame.Position += Mutagen.Bethesda.Constants.SUBRECORD_LENGTH;
            }

            static partial void WriteBinary_OpenByDefault_Custom(MutagenWriter writer, IPlacedObjectInternalGetter item, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                if (item.OpenByDefault)
                {
                    using (HeaderExport.ExportSubRecordHeader(writer, PlacedObject_Registration.ONAM_HEADER))
                    {
                    }
                }
            }
        }
    }
}
