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
using Mutagen.Bethesda.Fallout4.Internals;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Internals;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Mutagen.Bethesda.Translations.Binary;
using Noggog;
using Noggog.StructuredStrings;
using Noggog.StructuredStrings.CSharp;
using RecordTypeInts = Mutagen.Bethesda.Fallout4.Internals.RecordTypeInts;
using RecordTypes = Mutagen.Bethesda.Fallout4.Internals.RecordTypes;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Reactive.Linq;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Fallout4
{
    #region Class
    public partial class LandscapeMPCD :
        IEquatable<ILandscapeMPCDGetter>,
        ILandscapeMPCD,
        ILoquiObjectSetter<LandscapeMPCD>
    {
        #region Ctor
        public LandscapeMPCD()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region MPCD
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private MemorySlice<Byte> _MPCD = new byte[0];
        public MemorySlice<Byte> MPCD
        {
            get => _MPCD;
            set => this._MPCD = value;
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ReadOnlyMemorySlice<Byte> ILandscapeMPCDGetter.MPCD => this.MPCD;
        #endregion

        #region To String

        public void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            LandscapeMPCDMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not ILandscapeMPCDGetter rhs) return false;
            return ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(ILandscapeMPCDGetter? obj)
        {
            return ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public class Mask<TItem> :
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem MPCD)
            {
                this.MPCD = MPCD;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem MPCD;
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
                if (!object.Equals(this.MPCD, rhs.MPCD)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.MPCD);
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public bool All(Func<TItem, bool> eval)
            {
                if (!eval(this.MPCD)) return false;
                return true;
            }
            #endregion

            #region Any
            public bool Any(Func<TItem, bool> eval)
            {
                if (eval(this.MPCD)) return true;
                return false;
            }
            #endregion

            #region Translate
            public Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new LandscapeMPCD.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                obj.MPCD = eval(this.MPCD);
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public string Print(LandscapeMPCD.Mask<bool>? printMask = null)
            {
                var sb = new StructuredStringBuilder();
                Print(sb, printMask);
                return sb.ToString();
            }

            public void Print(StructuredStringBuilder sb, LandscapeMPCD.Mask<bool>? printMask = null)
            {
                sb.AppendLine($"{nameof(LandscapeMPCD.Mask<TItem>)} =>");
                using (sb.Brace())
                {
                    if (printMask?.MPCD ?? true)
                    {
                        sb.AppendItem(MPCD, "MPCD");
                    }
                }
            }
            #endregion

        }

        public class ErrorMask :
            IErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Overall { get; set; }
            private List<string>? _warnings;
            public List<string> Warnings
            {
                get
                {
                    if (_warnings == null)
                    {
                        _warnings = new List<string>();
                    }
                    return _warnings;
                }
            }
            public Exception? MPCD;
            #endregion

            #region IErrorMask
            public object? GetNthMask(int index)
            {
                LandscapeMPCD_FieldIndex enu = (LandscapeMPCD_FieldIndex)index;
                switch (enu)
                {
                    case LandscapeMPCD_FieldIndex.MPCD:
                        return MPCD;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthException(int index, Exception ex)
            {
                LandscapeMPCD_FieldIndex enu = (LandscapeMPCD_FieldIndex)index;
                switch (enu)
                {
                    case LandscapeMPCD_FieldIndex.MPCD:
                        this.MPCD = ex;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthMask(int index, object obj)
            {
                LandscapeMPCD_FieldIndex enu = (LandscapeMPCD_FieldIndex)index;
                switch (enu)
                {
                    case LandscapeMPCD_FieldIndex.MPCD:
                        this.MPCD = (Exception?)obj;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public bool IsInError()
            {
                if (Overall != null) return true;
                if (MPCD != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public void Print(StructuredStringBuilder sb, string? name = null)
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
            protected void PrintFillInternal(StructuredStringBuilder sb)
            {
                {
                    sb.AppendItem(MPCD, "MPCD");
                }
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.MPCD = this.MPCD.Combine(rhs.MPCD);
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public class TranslationMask : ITranslationMask
        {
            #region Members
            private TranslationCrystal? _crystal;
            public readonly bool DefaultOn;
            public bool OnOverall;
            public bool MPCD;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
            {
                this.DefaultOn = defaultOn;
                this.OnOverall = onOverall;
                this.MPCD = defaultOn;
            }

            #endregion

            public TranslationCrystal GetCrystal()
            {
                if (_crystal != null) return _crystal;
                var ret = new List<(bool On, TranslationCrystal? SubCrystal)>();
                GetCrystal(ret);
                _crystal = new TranslationCrystal(ret.ToArray());
                return _crystal;
            }

            protected void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                ret.Add((MPCD, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => LandscapeMPCDBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((LandscapeMPCDBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #region Binary Create
        public static LandscapeMPCD CreateFromBinary(
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            var ret = new LandscapeMPCD();
            ((LandscapeMPCDSetterCommon)((ILandscapeMPCDGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                translationParams: translationParams);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out LandscapeMPCD item,
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
            ((LandscapeMPCDSetterCommon)((ILandscapeMPCDGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static LandscapeMPCD GetNew()
        {
            return new LandscapeMPCD();
        }

    }
    #endregion

    #region Interface
    public partial interface ILandscapeMPCD :
        ILandscapeMPCDGetter,
        ILoquiObjectSetter<ILandscapeMPCD>
    {
        new MemorySlice<Byte> MPCD { get; set; }
    }

    public partial interface ILandscapeMPCDGetter :
        ILoquiObject,
        IBinaryItem,
        ILoquiObject<ILandscapeMPCDGetter>
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration StaticRegistration => LandscapeMPCD_Registration.Instance;
        ReadOnlyMemorySlice<Byte> MPCD { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class LandscapeMPCDMixIn
    {
        public static void Clear(this ILandscapeMPCD item)
        {
            ((LandscapeMPCDSetterCommon)((ILandscapeMPCDGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static LandscapeMPCD.Mask<bool> GetEqualsMask(
            this ILandscapeMPCDGetter item,
            ILandscapeMPCDGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string Print(
            this ILandscapeMPCDGetter item,
            string? name = null,
            LandscapeMPCD.Mask<bool>? printMask = null)
        {
            return ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)item).CommonInstance()!).Print(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void Print(
            this ILandscapeMPCDGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            LandscapeMPCD.Mask<bool>? printMask = null)
        {
            ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)item).CommonInstance()!).Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this ILandscapeMPCDGetter item,
            ILandscapeMPCDGetter rhs,
            LandscapeMPCD.TranslationMask? equalsMask = null)
        {
            return ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this ILandscapeMPCD lhs,
            ILandscapeMPCDGetter rhs)
        {
            ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this ILandscapeMPCD lhs,
            ILandscapeMPCDGetter rhs,
            LandscapeMPCD.TranslationMask? copyMask = null)
        {
            ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this ILandscapeMPCD lhs,
            ILandscapeMPCDGetter rhs,
            out LandscapeMPCD.ErrorMask errorMask,
            LandscapeMPCD.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = LandscapeMPCD.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this ILandscapeMPCD lhs,
            ILandscapeMPCDGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static LandscapeMPCD DeepCopy(
            this ILandscapeMPCDGetter item,
            LandscapeMPCD.TranslationMask? copyMask = null)
        {
            return ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static LandscapeMPCD DeepCopy(
            this ILandscapeMPCDGetter item,
            out LandscapeMPCD.ErrorMask errorMask,
            LandscapeMPCD.TranslationMask? copyMask = null)
        {
            return ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static LandscapeMPCD DeepCopy(
            this ILandscapeMPCDGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this ILandscapeMPCD item,
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            ((LandscapeMPCDSetterCommon)((ILandscapeMPCDGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                translationParams: translationParams);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Fallout4
{
    #region Field Index
    internal enum LandscapeMPCD_FieldIndex
    {
        MPCD = 0,
    }
    #endregion

    #region Registration
    internal partial class LandscapeMPCD_Registration : ILoquiRegistration
    {
        public static readonly LandscapeMPCD_Registration Instance = new LandscapeMPCD_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Fallout4.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Fallout4.ProtocolKey,
            msgID: 521,
            version: 0);

        public const string GUID = "c05c991d-cd3f-4e32-af36-741bdd6dec62";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 1;

        public static readonly Type MaskType = typeof(LandscapeMPCD.Mask<>);

        public static readonly Type ErrorMaskType = typeof(LandscapeMPCD.ErrorMask);

        public static readonly Type ClassType = typeof(LandscapeMPCD);

        public static readonly Type GetterType = typeof(ILandscapeMPCDGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(ILandscapeMPCD);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Fallout4.LandscapeMPCD";

        public const string Name = "LandscapeMPCD";

        public const string Namespace = "Mutagen.Bethesda.Fallout4";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly RecordType TriggeringRecordType = RecordTypes.MPCD;
        public static RecordTriggerSpecs TriggerSpecs => _recordSpecs.Value;
        private static readonly Lazy<RecordTriggerSpecs> _recordSpecs = new Lazy<RecordTriggerSpecs>(() =>
        {
            var all = RecordCollection.Factory(RecordTypes.MPCD);
            return new RecordTriggerSpecs(allRecordTypes: all);
        });
        public static readonly Type BinaryWriteTranslation = typeof(LandscapeMPCDBinaryWriteTranslation);
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
    internal partial class LandscapeMPCDSetterCommon
    {
        public static readonly LandscapeMPCDSetterCommon Instance = new LandscapeMPCDSetterCommon();

        partial void ClearPartial();
        
        public void Clear(ILandscapeMPCD item)
        {
            ClearPartial();
            item.MPCD = new byte[0];
        }
        
        #region Mutagen
        public void RemapLinks(ILandscapeMPCD obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            ILandscapeMPCD item,
            MutagenFrame frame,
            TypedParseParams translationParams)
        {
            frame = frame.SpawnWithFinalPosition(HeaderTranslation.ParseSubrecord(
                frame.Reader,
                translationParams.ConvertToCustom(RecordTypes.MPCD),
                translationParams.LengthOverride));
            PluginUtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                translationParams: translationParams,
                fillStructs: LandscapeMPCDBinaryCreateTranslation.FillBinaryStructs);
        }
        
        #endregion
        
    }
    internal partial class LandscapeMPCDCommon
    {
        public static readonly LandscapeMPCDCommon Instance = new LandscapeMPCDCommon();

        public LandscapeMPCD.Mask<bool> GetEqualsMask(
            ILandscapeMPCDGetter item,
            ILandscapeMPCDGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new LandscapeMPCD.Mask<bool>(false);
            ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            ILandscapeMPCDGetter item,
            ILandscapeMPCDGetter rhs,
            LandscapeMPCD.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            ret.MPCD = MemoryExtensions.SequenceEqual(item.MPCD.Span, rhs.MPCD.Span);
        }
        
        public string Print(
            ILandscapeMPCDGetter item,
            string? name = null,
            LandscapeMPCD.Mask<bool>? printMask = null)
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
            ILandscapeMPCDGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            LandscapeMPCD.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                sb.AppendLine($"LandscapeMPCD =>");
            }
            else
            {
                sb.AppendLine($"{name} (LandscapeMPCD) =>");
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
            ILandscapeMPCDGetter item,
            StructuredStringBuilder sb,
            LandscapeMPCD.Mask<bool>? printMask = null)
        {
            if (printMask?.MPCD ?? true)
            {
                sb.AppendLine($"MPCD => {SpanExt.ToHexString(item.MPCD)}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            ILandscapeMPCDGetter? lhs,
            ILandscapeMPCDGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            if ((crystal?.GetShouldTranslate((int)LandscapeMPCD_FieldIndex.MPCD) ?? true))
            {
                if (!MemoryExtensions.SequenceEqual(lhs.MPCD.Span, rhs.MPCD.Span)) return false;
            }
            return true;
        }
        
        public virtual int GetHashCode(ILandscapeMPCDGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.MPCD);
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public object GetNew()
        {
            return LandscapeMPCD.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> EnumerateFormLinks(ILandscapeMPCDGetter obj)
        {
            yield break;
        }
        
        #endregion
        
    }
    internal partial class LandscapeMPCDSetterTranslationCommon
    {
        public static readonly LandscapeMPCDSetterTranslationCommon Instance = new LandscapeMPCDSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            ILandscapeMPCD item,
            ILandscapeMPCDGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            if ((copyMask?.GetShouldTranslate((int)LandscapeMPCD_FieldIndex.MPCD) ?? true))
            {
                item.MPCD = rhs.MPCD.ToArray();
            }
        }
        
        #endregion
        
        public LandscapeMPCD DeepCopy(
            ILandscapeMPCDGetter item,
            LandscapeMPCD.TranslationMask? copyMask = null)
        {
            LandscapeMPCD ret = (LandscapeMPCD)((LandscapeMPCDCommon)((ILandscapeMPCDGetter)item).CommonInstance()!).GetNew();
            ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public LandscapeMPCD DeepCopy(
            ILandscapeMPCDGetter item,
            out LandscapeMPCD.ErrorMask errorMask,
            LandscapeMPCD.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            LandscapeMPCD ret = (LandscapeMPCD)((LandscapeMPCDCommon)((ILandscapeMPCDGetter)item).CommonInstance()!).GetNew();
            ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = LandscapeMPCD.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public LandscapeMPCD DeepCopy(
            ILandscapeMPCDGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            LandscapeMPCD ret = (LandscapeMPCD)((LandscapeMPCDCommon)((ILandscapeMPCDGetter)item).CommonInstance()!).GetNew();
            ((LandscapeMPCDSetterTranslationCommon)((ILandscapeMPCDGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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

namespace Mutagen.Bethesda.Fallout4
{
    public partial class LandscapeMPCD
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => LandscapeMPCD_Registration.Instance;
        public static ILoquiRegistration StaticRegistration => LandscapeMPCD_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => LandscapeMPCDCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterInstance()
        {
            return LandscapeMPCDSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => LandscapeMPCDSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object ILandscapeMPCDGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object ILandscapeMPCDGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object ILandscapeMPCDGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Fallout4
{
    public partial class LandscapeMPCDBinaryWriteTranslation : IBinaryWriteTranslator
    {
        public static readonly LandscapeMPCDBinaryWriteTranslation Instance = new();

        public static void WriteEmbedded(
            ILandscapeMPCDGetter item,
            MutagenWriter writer)
        {
            ByteArrayBinaryTranslation<MutagenFrame, MutagenWriter>.Instance.Write(
                writer: writer,
                item: item.MPCD);
        }

        public void Write(
            MutagenWriter writer,
            ILandscapeMPCDGetter item,
            TypedWriteParams translationParams)
        {
            using (HeaderExport.Subrecord(
                writer: writer,
                record: translationParams.ConvertToCustom(RecordTypes.MPCD),
                overflowRecord: translationParams.OverflowRecordType,
                out var writerToUse))
            {
                WriteEmbedded(
                    item: item,
                    writer: writerToUse);
            }
        }

        public void Write(
            MutagenWriter writer,
            object item,
            TypedWriteParams translationParams = default)
        {
            Write(
                item: (ILandscapeMPCDGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    internal partial class LandscapeMPCDBinaryCreateTranslation
    {
        public static readonly LandscapeMPCDBinaryCreateTranslation Instance = new LandscapeMPCDBinaryCreateTranslation();

        public static void FillBinaryStructs(
            ILandscapeMPCD item,
            MutagenFrame frame)
        {
            item.MPCD = ByteArrayBinaryTranslation<MutagenFrame, MutagenWriter>.Instance.Parse(reader: frame);
        }

    }

}
namespace Mutagen.Bethesda.Fallout4
{
    #region Binary Write Mixins
    public static class LandscapeMPCDBinaryTranslationMixIn
    {
        public static void WriteToBinary(
            this ILandscapeMPCDGetter item,
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((LandscapeMPCDBinaryWriteTranslation)item.BinaryWriteTranslator).Write(
                item: item,
                writer: writer,
                translationParams: translationParams);
        }

    }
    #endregion


}
namespace Mutagen.Bethesda.Fallout4
{
    internal partial class LandscapeMPCDBinaryOverlay :
        PluginBinaryOverlay,
        ILandscapeMPCDGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => LandscapeMPCD_Registration.Instance;
        public static ILoquiRegistration StaticRegistration => LandscapeMPCD_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => LandscapeMPCDCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => LandscapeMPCDSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object ILandscapeMPCDGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object? ILandscapeMPCDGetter.CommonSetterInstance() => null;
        [DebuggerStepThrough]
        object ILandscapeMPCDGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => LandscapeMPCDBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((LandscapeMPCDBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        #region MPCD
        public ReadOnlyMemorySlice<Byte> MPCD => _structData.Span.ToArray();
        protected int MPCDEndingPos;
        #endregion
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected LandscapeMPCDBinaryOverlay(
            MemoryPair memoryPair,
            BinaryOverlayFactoryPackage package)
            : base(
                memoryPair: memoryPair,
                package: package)
        {
            this.CustomCtor();
        }

        public static ILandscapeMPCDGetter LandscapeMPCDFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            TypedParseParams translationParams = default)
        {
            stream = ExtractSubrecordStructMemory(
                stream: stream,
                meta: package.MetaData.Constants,
                translationParams: translationParams,
                memoryPair: out var memoryPair,
                offset: out var offset,
                finalPos: out var finalPos);
            var ret = new LandscapeMPCDBinaryOverlay(
                memoryPair: memoryPair,
                package: package);
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static ILandscapeMPCDGetter LandscapeMPCDFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            TypedParseParams translationParams = default)
        {
            return LandscapeMPCDFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                translationParams: translationParams);
        }

        #region To String

        public void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            LandscapeMPCDMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not ILandscapeMPCDGetter rhs) return false;
            return ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(ILandscapeMPCDGetter? obj)
        {
            return ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((LandscapeMPCDCommon)((ILandscapeMPCDGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

