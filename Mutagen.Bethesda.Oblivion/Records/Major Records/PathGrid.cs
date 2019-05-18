using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Oblivion.Internals;
using Noggog;

namespace Mutagen.Bethesda.Oblivion.Internals
{
    public partial class PathGridBinaryTranslation
    {
        public static readonly RecordType PGRP = new RecordType("PGRP");
        public static readonly RecordType PGRR = new RecordType("PGRR");
        public const int POINT_LEN = 16;

        static partial void FillBinary_PointToPointConnections_Custom(MutagenFrame frame, PathGrid item, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
        {
            var nextRec = HeaderTranslation.ReadNextSubRecordType(frame.Reader, out var len);
            if (!nextRec.Equals(PathGrid_Registration.DATA_HEADER))
            {
                frame.Reader.Position -= Mutagen.Bethesda.Constants.RECORD_LENGTH;
                return;
            }
            uint ptCount = frame.Reader.ReadUInt16();

            nextRec = HeaderTranslation.ReadNextSubRecordType(frame.Reader, out var pointsLen);
            if (!nextRec.Equals(PGRP))
            {
                frame.Reader.Position -= Mutagen.Bethesda.Constants.RECORD_LENGTH;
                return;
            }
            var pointBytes = frame.Reader.ReadBytes(pointsLen);
            var bytePointsNum = pointBytes.Length / POINT_LEN;
            if (bytePointsNum != ptCount)
            {
                throw new ArgumentException($"Unexpected point byte length, when compared to expected point count. {pointBytes.Length} bytes: {bytePointsNum} != {ptCount} points.");
            }

            bool readPGRR = false;
            for (int recAttempt = 0; recAttempt < 2; recAttempt++)
            {
                if (frame.Reader.Complete) break;
                nextRec = HeaderTranslation.GetNextSubRecordType(frame.Reader, out len);
                switch (nextRec.TypeInt)
                {
                    case 0x47414750: //"PGAG":
                        frame.Reader.Position += Mutagen.Bethesda.Constants.SUBRECORD_LENGTH;
                        if (Mutagen.Bethesda.Binary.ByteArrayBinaryTranslation.Instance.Parse(
                           frame.SpawnWithLength(len, checkFraming: false),
                           item: out var unknownBytes))
                        {
                            item.Unknown = unknownBytes;
                        }
                        else
                        {
                            item.Unknown_Unset();
                        }
                        break;
                    case 0x52524750: // "PGRR":
                        frame.Reader.Position += Mutagen.Bethesda.Constants.SUBRECORD_LENGTH;
                        var connectionBytes = frame.Reader.ReadBytes(len);
                        using (var ptByteReader = new BinaryMemoryReadStream(pointBytes))
                        {
                            using (var connectionReader = new BinaryMemoryReadStream(connectionBytes))
                            {
                                item.PointToPointConnections.AddRange(
                                    EnumerableExt.For(0, pointBytes.Length, POINT_LEN)
                                    .Select(i =>
                                    {
                                        var pt = ReadPathGridPoint(ptByteReader, out var numConn);
                                        pt.Connections.AddRange(
                                            EnumerableExt.For(0, numConn)
                                                .Select(j => connectionReader.ReadInt16()));
                                        return pt;
                                    }));
                                if (!connectionReader.Complete)
                                {
                                    throw new ArgumentException("Connection reader did not complete as expected.");
                                }
                            }
                        }
                        readPGRR = true;
                        break;
                    default:
                        break;
                }
            }

            if (!readPGRR)
            {
                List<PathGridPoint> list = new List<PathGridPoint>();
                using (var ptByteReader = new BinaryMemoryReadStream(pointBytes))
                {
                    while (!ptByteReader.Complete)
                    {
                        list.Add(
                            ReadPathGridPoint(ptByteReader, out var numConn));
                    }
                }
                item.PointToPointConnections.AddRange(list);
            }
        }

        private static PathGridPoint ReadPathGridPoint(IBinaryReadStream reader, out byte numConn)
        {
            var pt = new PathGridPoint();
            pt.Point = new Noggog.P3Float(
                reader.ReadFloat(),
                reader.ReadFloat(),
                reader.ReadFloat());
            numConn = reader.ReadUInt8();
            pt.NumConnectionsFluffBytes = reader.ReadBytes(3);
            return pt;
        }

        static partial void WriteBinary_PointToPointConnections_Custom(MutagenWriter writer, IPathGridInternalGetter item, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
        {
            using (HeaderExport.ExportSubRecordHeader(writer, PathGrid_Registration.DATA_HEADER))
            {
                writer.Write((ushort)item.PointToPointConnections.Count);
            }

            bool anyConnections = false;
            using (HeaderExport.ExportSubRecordHeader(writer, PGRP))
            {
                foreach (var pt in item.PointToPointConnections)
                {
                    writer.Write(pt.Point.X);
                    writer.Write(pt.Point.Y);
                    writer.Write(pt.Point.Z);
                    writer.Write((byte)(pt.Connections.Count));
                    writer.Write(pt.NumConnectionsFluffBytes);
                    if (pt.Connections.Count > 0)
                    {
                        anyConnections = true;
                    }
                }
            }

            if (item.Unknown_IsSet)
            {
                using (HeaderExport.ExportSubRecordHeader(writer, PathGrid_Registration.PGAG_HEADER))
                {
                    writer.Write(item.Unknown);
                }
            }

            if (!anyConnections) return;
            using (HeaderExport.ExportSubRecordHeader(writer, PGRR))
            {
                foreach (var pt in item.PointToPointConnections)
                {
                    foreach (var conn in pt.Connections)
                    {
                        writer.Write(conn);
                    }
                }
            }
        }
    }
}
