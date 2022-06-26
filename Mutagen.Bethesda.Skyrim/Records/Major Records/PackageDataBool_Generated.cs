/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Interfaces;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Aspects;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Internals;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Skyrim.Internals;
using Mutagen.Bethesda.Translations.Binary;
using Noggog;
using Noggog.StructuredStrings;
using Noggog.StructuredStrings.CSharp;
using RecordTypeInts = Mutagen.Bethesda.Skyrim.Internals.RecordTypeInts;
using RecordTypes = Mutagen.Bethesda.Skyrim.Internals.RecordTypes;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Reactive.Linq;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Skyrim
{
    #region Class
    public partial class PackageDataBool :
        APackageData,
        IEquatable<IPackageDataBoolGetter>,
        ILoquiObjectSetter<PackageDataBool>,
        IPackageDataBool
    {
        #region Ctor
        public PackageDataBool()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Data
        public Boolean Data { get; set; } = default;
        #endregion

        #region To String

        public override void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            PackageDataBoolMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IPackageDataBoolGetter rhs) return false;
            return ((PackageDataBoolCommon)((IPackageDataBoolGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IPackageDataBoolGetter? obj)
        {
            return ((PackageDataBoolCommon)((IPackageDataBoolGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((PackageDataBoolCommon)((IPackageDataBoolGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            APackageData.Mask<TItem>,
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem initialValue)
            : base(initialValue)
            {
                this.Data = initialValue;
            }

            public Mask(
                TItem Name,
                TItem Flags,
                TItem Data)
            : base(
                Name: Name,
                Flags: Flags)
            {
                this.Data = Data;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Data;
            #endregion

            #region Equals
            public override bool Equals(object? obj)
            {
                if (!(obj is Mask<TItem> rhs)) return false;
                return Equals(rhs);
            }

            public bool Equals(Mask<TItem>? rhs)
            {
                if (rhs == null) return false;
                if (!base.Equals(rhs)) return false;
                if (!object.Equals(this.Data, rhs.Data)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Data);
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                if (!eval(this.Data)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                if (eval(this.Data)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new PackageDataBool.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
                obj.Data = eval(this.Data);
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public string Print(PackageDataBool.Mask<bool>? printMask = null)
            {
                var sb = new StructuredStringBuilder();
                Print(sb, printMask);
                return sb.ToString();
            }

            public void Print(StructuredStringBuilder sb, PackageDataBool.Mask<bool>? printMask = null)
            {
                sb.AppendLine($"{nameof(PackageDataBool.Mask<TItem>)} =>");
                using (sb.Brace())
                {
                    if (printMask?.Data ?? true)
                    {
                        sb.AppendItem(Data, "Data");
                    }
                }
            }
            #endregion

        }

        public new class ErrorMask :
            APackageData.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Data;
            #endregion

            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                PackageDataBool_FieldIndex enu = (PackageDataBool_FieldIndex)index;
                switch (enu)
                {
                    case PackageDataBool_FieldIndex.Data:
                        return Data;
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                PackageDataBool_FieldIndex enu = (PackageDataBool_FieldIndex)index;
                switch (enu)
                {
                    case PackageDataBool_FieldIndex.Data:
                        this.Data = ex;
                        break;
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                PackageDataBool_FieldIndex enu = (PackageDataBool_FieldIndex)index;
                switch (enu)
                {
                    case PackageDataBool_FieldIndex.Data:
                        this.Data = (Exception?)obj;
                        break;
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                if (Data != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public override void Print(StructuredStringBuilder sb, string? name = null)
            {
                sb.AppendLine($"{(name ?? "ErrorMask")} =>");
                using (sb.Brace())
                {
                    if (this.Overall != null)
                    {
                        sb.AppendLine("Overall =>");
                        using (sb.Brace())
                        {
                            sb.AppendLine($"{this.Overall}");
                        }
                    }
                    PrintFillInternal(sb);
                }
            }
            protected override void PrintFillInternal(StructuredStringBuilder sb)
            {
                base.PrintFillInternal(sb);
                {
                    sb.AppendItem(Data, "Data");
                }
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Data = this.Data.Combine(rhs.Data);
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static new ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public new class TranslationMask :
            APackageData.TranslationMask,
            ITranslationMask
        {
            #region Members
            public bool Data;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
                this.Data = defaultOn;
            }

            #endregion

            protected override void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                base.GetCrystal(ret);
                ret.Add((Data, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => PackageDataBoolBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((PackageDataBoolBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #region Binary Create
        public new static PackageDataBool CreateFromBinary(
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            var ret = new PackageDataBool();
            ((PackageDataBoolSetterCommon)((IPackageDataBoolGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                translationParams: translationParams);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out PackageDataBool item,
            TypedParseParams translationParams = default)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(
                frame: frame,
                translationParams: translationParams);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        void IClearable.Clear()
        {
            ((PackageDataBoolSetterCommon)((IPackageDataBoolGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new PackageDataBool GetNew()
        {
            return new PackageDataBool();
        }

    }
    #endregion

    #region Interface
    public partial interface IPackageDataBool :
        IAPackageData,
        ILoquiObjectSetter<IPackageDataBool>,
        INamed,
        INamedRequired,
        IPackageDataBoolGetter
    {
        new Boolean Data { get; set; }
    }

    public partial interface IPackageDataBoolGetter :
        IAPackageDataGetter,
        IBinaryItem,
        ILoquiObject<IPackageDataBoolGetter>,
        INamedGetter,
        INamedRequiredGetter
    {
        static new ILoquiRegistration StaticRegistration => PackageDataBool_Registration.Instance;
        Boolean Data { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class PackageDataBoolMixIn
    {
        public static void Clear(this IPackageDataBool item)
        {
            ((PackageDataBoolSetterCommon)((IPackageDataBoolGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static PackageDataBool.Mask<bool> GetEqualsMask(
            this IPackageDataBoolGetter item,
            IPackageDataBoolGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((PackageDataBoolCommon)((IPackageDataBoolGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string Print(
            this IPackageDataBoolGetter item,
            string? name = null,
            PackageDataBool.Mask<bool>? printMask = null)
        {
            return ((PackageDataBoolCommon)((IPackageDataBoolGetter)item).CommonInstance()!).Print(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void Print(
            this IPackageDataBoolGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            PackageDataBool.Mask<bool>? printMask = null)
        {
            ((PackageDataBoolCommon)((IPackageDataBoolGetter)item).CommonInstance()!).Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IPackageDataBoolGetter item,
            IPackageDataBoolGetter rhs,
            PackageDataBool.TranslationMask? equalsMask = null)
        {
            return ((PackageDataBoolCommon)((IPackageDataBoolGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IPackageDataBool lhs,
            IPackageDataBoolGetter rhs,
            out PackageDataBool.ErrorMask errorMask,
            PackageDataBool.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((PackageDataBoolSetterTranslationCommon)((IPackageDataBoolGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = PackageDataBool.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IPackageDataBool lhs,
            IPackageDataBoolGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((PackageDataBoolSetterTranslationCommon)((IPackageDataBoolGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static PackageDataBool DeepCopy(
            this IPackageDataBoolGetter item,
            PackageDataBool.TranslationMask? copyMask = null)
        {
            return ((PackageDataBoolSetterTranslationCommon)((IPackageDataBoolGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static PackageDataBool DeepCopy(
            this IPackageDataBoolGetter item,
            out PackageDataBool.ErrorMask errorMask,
            PackageDataBool.TranslationMask? copyMask = null)
        {
            return ((PackageDataBoolSetterTranslationCommon)((IPackageDataBoolGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static PackageDataBool DeepCopy(
            this IPackageDataBoolGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((PackageDataBoolSetterTranslationCommon)((IPackageDataBoolGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IPackageDataBool item,
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            ((PackageDataBoolSetterCommon)((IPackageDataBoolGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                translationParams: translationParams);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim
{
    #region Field Index
    internal enum PackageDataBool_FieldIndex
    {
        Name = 0,
        Flags = 1,
        Data = 2,
    }
    #endregion

    #region Registration
    internal partial class PackageDataBool_Registration : ILoquiRegistration
    {
        public static readonly PackageDataBool_Registration Instance = new PackageDataBool_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 387,
            version: 0);

        public const string GUID = "d00a40a9-2f39-4a0e-afb2-396dfe024205";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 3;

        public static readonly Type MaskType = typeof(PackageDataBool.Mask<>);

        public static readonly Type ErrorMaskType = typeof(PackageDataBool.ErrorMask);

        public static readonly Type ClassType = typeof(PackageDataBool);

        public static readonly Type GetterType = typeof(IPackageDataBoolGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IPackageDataBool);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Skyrim.PackageDataBool";

        public const string Name = "PackageDataBool";

        public const string Namespace = "Mutagen.Bethesda.Skyrim";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static RecordTriggerSpecs TriggerSpecs => _recordSpecs.Value;
        private static readonly Lazy<RecordTriggerSpecs> _recordSpecs = new Lazy<RecordTriggerSpecs>(() =>
        {
            var all = RecordCollection.Factory(
                RecordTypes.BNAM,
                RecordTypes.PNAM);
            return new RecordTriggerSpecs(allRecordTypes: all);
        });
        public static readonly Type BinaryWriteTranslation = typeof(PackageDataBoolBinaryWriteTranslation);
        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        ushort ILoquiRegistration.FieldCount => FieldCount;
        ushort ILoquiRegistration.AdditionalFieldCount => AdditionalFieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.SetterType => SetterType;
        Type? ILoquiRegistration.InternalSetterType => InternalSetterType;
        Type ILoquiRegistration.GetterType => GetterType;
        Type? ILoquiRegistration.InternalGetterType => InternalGetterType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type? ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => throw new NotImplementedException();
        string ILoquiRegistration.GetNthName(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsNthDerivative(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsProtected(ushort index) => throw new NotImplementedException();
        Type ILoquiRegistration.GetNthType(ushort index) => throw new NotImplementedException();
        #endregion

    }
    #endregion

    #region Common
    internal partial class PackageDataBoolSetterCommon : APackageDataSetterCommon
    {
        public new static readonly PackageDataBoolSetterCommon Instance = new PackageDataBoolSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IPackageDataBool item)
        {
            ClearPartial();
            item.Data = default;
            base.Clear(item);
        }
        
        public override void Clear(IAPackageData item)
        {
            Clear(item: (IPackageDataBool)item);
        }
        
        #region Mutagen
        public void RemapLinks(IPackageDataBool obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IPackageDataBool item,
            MutagenFrame frame,
            TypedParseParams translationParams)
        {
            PluginUtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                translationParams: translationParams,
                fillStructs: PackageDataBoolBinaryCreateTranslation.FillBinaryStructs,
                fillTyped: PackageDataBoolBinaryCreateTranslation.FillBinaryRecordTypes);
        }
        
        public override void CopyInFromBinary(
            IAPackageData item,
            MutagenFrame frame,
            TypedParseParams translationParams)
        {
            CopyInFromBinary(
                item: (PackageDataBool)item,
                frame: frame,
                translationParams: translationParams);
        }
        
        #endregion
        
    }
    internal partial class PackageDataBoolCommon : APackageDataCommon
    {
        public new static readonly PackageDataBoolCommon Instance = new PackageDataBoolCommon();

        public PackageDataBool.Mask<bool> GetEqualsMask(
            IPackageDataBoolGetter item,
            IPackageDataBoolGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new PackageDataBool.Mask<bool>(false);
            ((PackageDataBoolCommon)((IPackageDataBoolGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IPackageDataBoolGetter item,
            IPackageDataBoolGetter rhs,
            PackageDataBool.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            ret.Data = item.Data == rhs.Data;
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string Print(
            IPackageDataBoolGetter item,
            string? name = null,
            PackageDataBool.Mask<bool>? printMask = null)
        {
            var sb = new StructuredStringBuilder();
            Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
            return sb.ToString();
        }
        
        public void Print(
            IPackageDataBoolGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            PackageDataBool.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                sb.AppendLine($"PackageDataBool =>");
            }
            else
            {
                sb.AppendLine($"{name} (PackageDataBool) =>");
            }
            using (sb.Brace())
            {
                ToStringFields(
                    item: item,
                    sb: sb,
                    printMask: printMask);
            }
        }
        
        protected static void ToStringFields(
            IPackageDataBoolGetter item,
            StructuredStringBuilder sb,
            PackageDataBool.Mask<bool>? printMask = null)
        {
            APackageDataCommon.ToStringFields(
                item: item,
                sb: sb,
                printMask: printMask);
            if (printMask?.Data ?? true)
            {
                sb.AppendItem(item.Data, "Data");
            }
        }
        
        public static PackageDataBool_FieldIndex ConvertFieldIndex(APackageData_FieldIndex index)
        {
            switch (index)
            {
                case APackageData_FieldIndex.Name:
                    return (PackageDataBool_FieldIndex)((int)index);
                case APackageData_FieldIndex.Flags:
                    return (PackageDataBool_FieldIndex)((int)index);
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IPackageDataBoolGetter? lhs,
            IPackageDataBoolGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            if (!base.Equals((IAPackageDataGetter)lhs, (IAPackageDataGetter)rhs, crystal)) return false;
            if ((crystal?.GetShouldTranslate((int)PackageDataBool_FieldIndex.Data) ?? true))
            {
                if (lhs.Data != rhs.Data) return false;
            }
            return true;
        }
        
        public override bool Equals(
            IAPackageDataGetter? lhs,
            IAPackageDataGetter? rhs,
            TranslationCrystal? crystal)
        {
            return Equals(
                lhs: (IPackageDataBoolGetter?)lhs,
                rhs: rhs as IPackageDataBoolGetter,
                crystal: crystal);
        }
        
        public virtual int GetHashCode(IPackageDataBoolGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Data);
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IAPackageDataGetter item)
        {
            return GetHashCode(item: (IPackageDataBoolGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return PackageDataBool.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> EnumerateFormLinks(IPackageDataBoolGetter obj)
        {
            foreach (var item in base.EnumerateFormLinks(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        #endregion
        
    }
    internal partial class PackageDataBoolSetterTranslationCommon : APackageDataSetterTranslationCommon
    {
        public new static readonly PackageDataBoolSetterTranslationCommon Instance = new PackageDataBoolSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IPackageDataBool item,
            IPackageDataBoolGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IAPackageData)item,
                (IAPackageDataGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
            if ((copyMask?.GetShouldTranslate((int)PackageDataBool_FieldIndex.Data) ?? true))
            {
                item.Data = rhs.Data;
            }
        }
        
        
        public override void DeepCopyIn(
            IAPackageData item,
            IAPackageDataGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IPackageDataBool)item,
                rhs: (IPackageDataBoolGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public PackageDataBool DeepCopy(
            IPackageDataBoolGetter item,
            PackageDataBool.TranslationMask? copyMask = null)
        {
            PackageDataBool ret = (PackageDataBool)((PackageDataBoolCommon)((IPackageDataBoolGetter)item).CommonInstance()!).GetNew();
            ((PackageDataBoolSetterTranslationCommon)((IPackageDataBoolGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public PackageDataBool DeepCopy(
            IPackageDataBoolGetter item,
            out PackageDataBool.ErrorMask errorMask,
            PackageDataBool.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            PackageDataBool ret = (PackageDataBool)((PackageDataBoolCommon)((IPackageDataBoolGetter)item).CommonInstance()!).GetNew();
            ((PackageDataBoolSetterTranslationCommon)((IPackageDataBoolGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = PackageDataBool.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public PackageDataBool DeepCopy(
            IPackageDataBoolGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            PackageDataBool ret = (PackageDataBool)((PackageDataBoolCommon)((IPackageDataBoolGetter)item).CommonInstance()!).GetNew();
            ((PackageDataBoolSetterTranslationCommon)((IPackageDataBoolGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: true);
            return ret;
        }
        
    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim
{
    public partial class PackageDataBool
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => PackageDataBool_Registration.Instance;
        public new static ILoquiRegistration StaticRegistration => PackageDataBool_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => PackageDataBoolCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return PackageDataBoolSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => PackageDataBoolSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim
{
    public partial class PackageDataBoolBinaryWriteTranslation :
        APackageDataBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new static readonly PackageDataBoolBinaryWriteTranslation Instance = new();

        public static void WriteEmbedded(
            IPackageDataBoolGetter item,
            MutagenWriter writer)
        {
        }

        public void Write(
            MutagenWriter writer,
            IPackageDataBoolGetter item,
            TypedWriteParams translationParams)
        {
            WriteEmbedded(
                item: item,
                writer: writer);
            APackageDataBinaryWriteTranslation.WriteRecordTypes(
                item: item,
                writer: writer,
                translationParams: translationParams);
        }

        public override void Write(
            MutagenWriter writer,
            object item,
            TypedWriteParams translationParams = default)
        {
            Write(
                item: (IPackageDataBoolGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

        public override void Write(
            MutagenWriter writer,
            IAPackageDataGetter item,
            TypedWriteParams translationParams)
        {
            Write(
                item: (IPackageDataBoolGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    internal partial class PackageDataBoolBinaryCreateTranslation : APackageDataBinaryCreateTranslation
    {
        public new static readonly PackageDataBoolBinaryCreateTranslation Instance = new PackageDataBoolBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IPackageDataBool item,
            MutagenFrame frame)
        {
        }

    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class PackageDataBoolBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim
{
    internal partial class PackageDataBoolBinaryOverlay :
        APackageDataBinaryOverlay,
        IPackageDataBoolGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => PackageDataBool_Registration.Instance;
        public new static ILoquiRegistration StaticRegistration => PackageDataBool_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => PackageDataBoolCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => PackageDataBoolSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => PackageDataBoolBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((PackageDataBoolBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected PackageDataBoolBinaryOverlay(
            MemoryPair memoryPair,
            BinaryOverlayFactoryPackage package)
            : base(
                memoryPair: memoryPair,
                package: package)
        {
            this.CustomCtor();
        }

        public static IPackageDataBoolGetter PackageDataBoolFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            TypedParseParams translationParams = default)
        {
            stream = ExtractTypelessSubrecordRecordMemory(
                stream: stream,
                meta: package.MetaData.Constants,
                translationParams: translationParams,
                memoryPair: out var memoryPair,
                offset: out var offset,
                finalPos: out var finalPos);
            var ret = new PackageDataBoolBinaryOverlay(
                memoryPair: memoryPair,
                package: package);
            ret.FillTypelessSubrecordTypes(
                stream: stream,
                finalPos: stream.Length,
                offset: offset,
                translationParams: translationParams,
                fill: ret.FillRecordType);
            return ret;
        }

        public static IPackageDataBoolGetter PackageDataBoolFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            TypedParseParams translationParams = default)
        {
            return PackageDataBoolFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                translationParams: translationParams);
        }

        #region To String

        public override void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            PackageDataBoolMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IPackageDataBoolGetter rhs) return false;
            return ((PackageDataBoolCommon)((IPackageDataBoolGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IPackageDataBoolGetter? obj)
        {
            return ((PackageDataBoolCommon)((IPackageDataBoolGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((PackageDataBoolCommon)((IPackageDataBoolGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

