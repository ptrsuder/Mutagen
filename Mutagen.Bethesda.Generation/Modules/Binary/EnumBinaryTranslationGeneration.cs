using Loqui;
using Loqui.Generation;
using Mutagen.Bethesda.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noggog;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Generation
{
    public class EnumBinaryTranslationGeneration : BinaryTranslationGeneration
    {
        public override string GetTranslatorInstance(TypeGeneration typeGen, bool getter)
        {
            var eType = typeGen as EnumType;
            return $"EnumBinaryTranslation<{eType.NoNullTypeName}>.Instance";
        }

        public override bool AllowDirectWrite(
            ObjectGeneration objGen,
            TypeGeneration typeGen) => false;
        public override bool AllowDirectParse(
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            bool squashedRepeatedList) => false;

        public override void GenerateWrite(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor writerAccessor,
            Accessor itemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationMaskAccessor)
        {
            var eType = typeGen as EnumType;
            var data = typeGen.CustomData[Constants.DataKey] as MutagenFieldData;
            using (var args = new ArgsWrapper(fg,
                $"{Namespace}EnumBinaryTranslation<{eType.NoNullTypeName}>.Instance.Write"))
            {
                args.Add(writerAccessor.DirectAccess);
                args.Add($"{itemAccessor.DirectAccess}");
                args.Add($"length: {eType.ByteLength}");
                if (this.DoErrorMasks)
                {
                    if (typeGen.HasIndex)
                    {
                        args.Add($"fieldIndex: (int){typeGen.IndexEnumName}");
                    }
                    args.Add($"errorMask: {errorMaskAccessor}");
                }
                if (data.RecordType.HasValue)
                {
                    args.Add($"header: recordTypeConverter.ConvertToCustom({objGen.RecordTypeHeaderName(data.RecordType.Value)})");
                    args.Add($"nullable: {(data.Optional ? "true" : "false")}");
                }
            }
        }

        public override void GenerateCopyIn(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration typeGen,
            Accessor frameAccessor,
            Accessor itemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationMaskAccessor)
        {
            var data = typeGen.CustomData[Constants.DataKey] as MutagenFieldData;
            var eType = typeGen as EnumType;
            if (data.HasTrigger)
            {
                fg.AppendLine($"{frameAccessor}.Position += {frameAccessor}.{nameof(MutagenBinaryReadStream.MetaData)}.{nameof(MetaDataConstants.SubConstants)}.{nameof(RecordConstants.HeaderLength)};");
            }

            TranslationGeneration.WrapParseCall(
                new TranslationWrapParseArgs()
                {
                    FG = fg,
                    TypeGen = typeGen,
                    TranslatorLine = $"EnumBinaryTranslation<{eType.NoNullTypeName}>.Instance",
                    MaskAccessor = errorMaskAccessor,
                    ItemAccessor = itemAccessor,
                    TranslationMaskAccessor = null,
                    IndexAccessor = typeGen.IndexEnumInt,
                    ExtraArgs = $"frame: {frameAccessor}{(data.HasTrigger ? ".SpawnWithLength(contentLength)" : $".SpawnWithLength({eType.ByteLength})")}".Single(),
                    SkipErrorMask = !this.DoErrorMasks
                });
        }

        public override void GenerateCopyInRet(
            FileGeneration fg,
            ObjectGeneration objGen,
            TypeGeneration targetGen,
            TypeGeneration typeGen,
            Accessor nodeAccessor,
            AsyncMode asyncMode,
            Accessor retAccessor,
            Accessor outItemAccessor,
            Accessor errorMaskAccessor,
            Accessor translationAccessor)
        {
            var eType = typeGen as EnumType;
            using (var args = new ArgsWrapper(fg,
                $"{retAccessor}{this.Namespace}EnumBinaryTranslation<{eType.NoNullTypeName}>.Instance.Parse"))
            {
                args.Add($"frame: {nodeAccessor}.SpawnWithLength({eType.ByteLength})");
                if (asyncMode == AsyncMode.Off)
                {
                    args.Add($"item: out {outItemAccessor.DirectAccess}");
                }
                if (this.DoErrorMasks)
                {
                    args.Add($"errorMask: {errorMaskAccessor}");
                }
            }
        }

        public override void GenerateWrapperFields(
            FileGeneration fg,
            ObjectGeneration objGen, 
            TypeGeneration typeGen, 
            Accessor dataAccessor,
            int currentPosition,
            DataType dataType)
        {
            var eType = typeGen as EnumType;
            var data = typeGen.GetFieldData();
            switch (data.BinaryWrapperFallback)
            {
                case BinaryGenerationType.Normal:
                    break;
                case BinaryGenerationType.DoNothing:
                case BinaryGenerationType.NoGeneration:
                    return;
                case BinaryGenerationType.Custom:
                    this.Module.CustomLogic.GenerateForCustomFlagWrapperFields(
                        fg,
                        objGen,
                        typeGen,
                        dataAccessor,
                        ref currentPosition,
                        dataType);
                    return;
                default:
                    throw new NotImplementedException();
            }

            if (data.HasTrigger)
            {
                fg.AppendLine($"private int? _{typeGen.Name}Location;");
                fg.AppendLine($"public bool {typeGen.Name}_IsSet => _{typeGen.Name}Location.HasValue;");
            }
            var posStr = dataType == null ? $"{currentPosition}" : $"_{typeGen.Name}Location";
            string slice;
            if (data.RecordType.HasValue)
            {
                slice = $"{nameof(HeaderTranslation)}.{nameof(HeaderTranslation.ExtractSubrecordSpan)}({dataAccessor}, _{typeGen.Name}Location.Value, _package.Meta)";
            }
            else
            {
                slice = $"{dataAccessor}.Span.Slice({posStr}, {eType.ByteLength})";
            }
            var getType = GenerateForTypicalWrapper(objGen, typeGen, slice, "_package");

            if (data.RecordType.HasValue)
            {
                fg.AppendLine($"public {eType.TypeName(getter: true)} {eType.Name} => {getType};");
            }
            else
            {
                if (dataType == null)
                {
                    fg.AppendLine($"public {eType.TypeName(getter: true)} {eType.Name} => {getType};");
                }
                else
                {
                    DataBinaryTranslationGeneration.GenerateWrapperExtraMembers(fg, dataType, objGen, typeGen, currentPosition);
                    fg.AppendLine($"public {eType.TypeName(getter: true)} {eType.Name} => _{typeGen.Name}_IsSet ? {getType} : default;");
                }
            }

        }

        public override int GetPassedAmount(ObjectGeneration objGen, TypeGeneration typeGen)
        {
            var data = typeGen.GetFieldData();
            if (!data.RecordType.HasValue)
            {
                return this.ExpectedLength(objGen, typeGen) ?? 0;
            }
            return 0;
        }

        public override int? ExpectedLength(ObjectGeneration objGen, TypeGeneration typeGen)
        {
            var eType = typeGen as EnumType;
            return eType.ByteLength;
        }

        public override string GenerateForTypicalWrapper(ObjectGeneration objGen, TypeGeneration typeGen, Accessor dataAccessor, Accessor packageAccessor)
        {
            var eType = typeGen as EnumType;
            switch (eType.ByteLength)
            {
                case 1:
                    return $"({eType.TypeName(getter: true)}){dataAccessor}[0]";
                case 2:
                    return $"({eType.TypeName(getter: true)})BinaryPrimitives.ReadUInt16LittleEndian({dataAccessor})";
                case 4:
                    return $"({eType.TypeName(getter: true)})BinaryPrimitives.ReadInt32LittleEndian({dataAccessor})";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
