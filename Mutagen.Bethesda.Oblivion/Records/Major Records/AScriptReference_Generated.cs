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
using Mutagen.Bethesda.Oblivion.Internals;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Internals;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Mutagen.Bethesda.Translations.Binary;
using Noggog;
using Noggog.StructuredStrings;
using Noggog.StructuredStrings.CSharp;
using RecordTypeInts = Mutagen.Bethesda.Oblivion.Internals.RecordTypeInts;
using RecordTypes = Mutagen.Bethesda.Oblivion.Internals.RecordTypes;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Reactive.Linq;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Oblivion
{
    #region Class
    /// <summary>
    /// Implemented by: [ScriptVariableReference, ScriptObjectReference]
    /// </summary>
    public abstract partial class AScriptReference :
        IAScriptReference,
        IEquatable<IAScriptReferenceGetter>,
        ILoquiObjectSetter<AScriptReference>
    {
        #region Ctor
        public AScriptReference()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion


        #region To String

        public virtual void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            AScriptReferenceMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IAScriptReferenceGetter rhs) return false;
            return ((AScriptReferenceCommon)((IAScriptReferenceGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IAScriptReferenceGetter? obj)
        {
            return ((AScriptReferenceCommon)((IAScriptReferenceGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((AScriptReferenceCommon)((IAScriptReferenceGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public class Mask<TItem> :
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem initialValue)
            {
            }


            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

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
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public virtual bool All(Func<TItem, bool> eval)
            {
                return true;
            }
            #endregion

            #region Any
            public virtual bool Any(Func<TItem, bool> eval)
            {
                return false;
            }
            #endregion

            #region Translate
            public Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new AScriptReference.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public string Print(AScriptReference.Mask<bool>? printMask = null)
            {
                var sb = new StructuredStringBuilder();
                Print(sb, printMask);
                return sb.ToString();
            }

            public void Print(StructuredStringBuilder sb, AScriptReference.Mask<bool>? printMask = null)
            {
                sb.AppendLine($"{nameof(AScriptReference.Mask<TItem>)} =>");
                using (sb.Brace())
                {
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
            #endregion

            #region IErrorMask
            public virtual object? GetNthMask(int index)
            {
                AScriptReference_FieldIndex enu = (AScriptReference_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public virtual void SetNthException(int index, Exception ex)
            {
                AScriptReference_FieldIndex enu = (AScriptReference_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public virtual void SetNthMask(int index, object obj)
            {
                AScriptReference_FieldIndex enu = (AScriptReference_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public virtual bool IsInError()
            {
                if (Overall != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public virtual void Print(StructuredStringBuilder sb, string? name = null)
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
            protected virtual void PrintFillInternal(StructuredStringBuilder sb)
            {
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
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
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
            {
                this.DefaultOn = defaultOn;
                this.OnOverall = onOverall;
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

            protected virtual void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Mutagen
        public virtual IEnumerable<IFormLinkGetter> EnumerateFormLinks() => AScriptReferenceCommon.Instance.EnumerateFormLinks(this);
        public virtual void RemapLinks(IReadOnlyDictionary<FormKey, FormKey> mapping) => AScriptReferenceSetterCommon.Instance.RemapLinks(this, mapping);
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual object BinaryWriteTranslator => AScriptReferenceBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((AScriptReferenceBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        void IClearable.Clear()
        {
            ((AScriptReferenceSetterCommon)((IAScriptReferenceGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static AScriptReference GetNew()
        {
            throw new ArgumentException("New called on an abstract class.");
        }

    }
    #endregion

    #region Interface
    /// <summary>
    /// Implemented by: [ScriptVariableReference, ScriptObjectReference]
    /// </summary>
    public partial interface IAScriptReference :
        IAScriptReferenceGetter,
        IFormLinkContainer,
        ILoquiObjectSetter<IAScriptReference>
    {
    }

    /// <summary>
    /// Implemented by: [ScriptVariableReference, ScriptObjectReference]
    /// </summary>
    public partial interface IAScriptReferenceGetter :
        ILoquiObject,
        IBinaryItem,
        IFormLinkContainerGetter,
        ILoquiObject<IAScriptReferenceGetter>
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration StaticRegistration => AScriptReference_Registration.Instance;

    }

    #endregion

    #region Common MixIn
    public static partial class AScriptReferenceMixIn
    {
        public static void Clear(this IAScriptReference item)
        {
            ((AScriptReferenceSetterCommon)((IAScriptReferenceGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static AScriptReference.Mask<bool> GetEqualsMask(
            this IAScriptReferenceGetter item,
            IAScriptReferenceGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((AScriptReferenceCommon)((IAScriptReferenceGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string Print(
            this IAScriptReferenceGetter item,
            string? name = null,
            AScriptReference.Mask<bool>? printMask = null)
        {
            return ((AScriptReferenceCommon)((IAScriptReferenceGetter)item).CommonInstance()!).Print(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void Print(
            this IAScriptReferenceGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            AScriptReference.Mask<bool>? printMask = null)
        {
            ((AScriptReferenceCommon)((IAScriptReferenceGetter)item).CommonInstance()!).Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IAScriptReferenceGetter item,
            IAScriptReferenceGetter rhs,
            AScriptReference.TranslationMask? equalsMask = null)
        {
            return ((AScriptReferenceCommon)((IAScriptReferenceGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IAScriptReference lhs,
            IAScriptReferenceGetter rhs)
        {
            ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IAScriptReference lhs,
            IAScriptReferenceGetter rhs,
            AScriptReference.TranslationMask? copyMask = null)
        {
            ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IAScriptReference lhs,
            IAScriptReferenceGetter rhs,
            out AScriptReference.ErrorMask errorMask,
            AScriptReference.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = AScriptReference.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IAScriptReference lhs,
            IAScriptReferenceGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static AScriptReference DeepCopy(
            this IAScriptReferenceGetter item,
            AScriptReference.TranslationMask? copyMask = null)
        {
            return ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static AScriptReference DeepCopy(
            this IAScriptReferenceGetter item,
            out AScriptReference.ErrorMask errorMask,
            AScriptReference.TranslationMask? copyMask = null)
        {
            return ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static AScriptReference DeepCopy(
            this IAScriptReferenceGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IAScriptReference item,
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            ((AScriptReferenceSetterCommon)((IAScriptReferenceGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                translationParams: translationParams);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Oblivion
{
    #region Field Index
    internal enum AScriptReference_FieldIndex
    {
    }
    #endregion

    #region Registration
    internal partial class AScriptReference_Registration : ILoquiRegistration
    {
        public static readonly AScriptReference_Registration Instance = new AScriptReference_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Oblivion.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Oblivion.ProtocolKey,
            msgID: 50,
            version: 0);

        public const string GUID = "5eb6ddcc-5ba8-4da7-87f5-99b6038a61c7";

        public const ushort AdditionalFieldCount = 0;

        public const ushort FieldCount = 0;

        public static readonly Type MaskType = typeof(AScriptReference.Mask<>);

        public static readonly Type ErrorMaskType = typeof(AScriptReference.ErrorMask);

        public static readonly Type ClassType = typeof(AScriptReference);

        public static readonly Type GetterType = typeof(IAScriptReferenceGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IAScriptReference);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Oblivion.AScriptReference";

        public const string Name = "AScriptReference";

        public const string Namespace = "Mutagen.Bethesda.Oblivion";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static RecordTriggerSpecs TriggerSpecs => _recordSpecs.Value;
        private static readonly Lazy<RecordTriggerSpecs> _recordSpecs = new Lazy<RecordTriggerSpecs>(() =>
        {
            var all = RecordCollection.Factory(
                RecordTypes.SCRV,
                RecordTypes.SCRO);
            return new RecordTriggerSpecs(allRecordTypes: all);
        });
        public static readonly Type BinaryWriteTranslation = typeof(AScriptReferenceBinaryWriteTranslation);
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
    internal partial class AScriptReferenceSetterCommon
    {
        public static readonly AScriptReferenceSetterCommon Instance = new AScriptReferenceSetterCommon();

        partial void ClearPartial();
        
        public virtual void Clear(IAScriptReference item)
        {
            ClearPartial();
        }
        
        #region Mutagen
        public void RemapLinks(IAScriptReference obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IAScriptReference item,
            MutagenFrame frame,
            TypedParseParams translationParams)
        {
        }
        
        #endregion
        
    }
    internal partial class AScriptReferenceCommon
    {
        public static readonly AScriptReferenceCommon Instance = new AScriptReferenceCommon();

        public AScriptReference.Mask<bool> GetEqualsMask(
            IAScriptReferenceGetter item,
            IAScriptReferenceGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new AScriptReference.Mask<bool>(false);
            ((AScriptReferenceCommon)((IAScriptReferenceGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IAScriptReferenceGetter item,
            IAScriptReferenceGetter rhs,
            AScriptReference.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
        }
        
        public string Print(
            IAScriptReferenceGetter item,
            string? name = null,
            AScriptReference.Mask<bool>? printMask = null)
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
            IAScriptReferenceGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            AScriptReference.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                sb.AppendLine($"AScriptReference =>");
            }
            else
            {
                sb.AppendLine($"{name} (AScriptReference) =>");
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
            IAScriptReferenceGetter item,
            StructuredStringBuilder sb,
            AScriptReference.Mask<bool>? printMask = null)
        {
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IAScriptReferenceGetter? lhs,
            IAScriptReferenceGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            return true;
        }
        
        public virtual int GetHashCode(IAScriptReferenceGetter item)
        {
            var hash = new HashCode();
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public virtual object GetNew()
        {
            return AScriptReference.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> EnumerateFormLinks(IAScriptReferenceGetter obj)
        {
            yield break;
        }
        
        #endregion
        
    }
    internal partial class AScriptReferenceSetterTranslationCommon
    {
        public static readonly AScriptReferenceSetterTranslationCommon Instance = new AScriptReferenceSetterTranslationCommon();

        #region DeepCopyIn
        public virtual void DeepCopyIn(
            IAScriptReference item,
            IAScriptReferenceGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
        }
        
        #endregion
        
        public AScriptReference DeepCopy(
            IAScriptReferenceGetter item,
            AScriptReference.TranslationMask? copyMask = null)
        {
            AScriptReference ret = (AScriptReference)((AScriptReferenceCommon)((IAScriptReferenceGetter)item).CommonInstance()!).GetNew();
            ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public AScriptReference DeepCopy(
            IAScriptReferenceGetter item,
            out AScriptReference.ErrorMask errorMask,
            AScriptReference.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            AScriptReference ret = (AScriptReference)((AScriptReferenceCommon)((IAScriptReferenceGetter)item).CommonInstance()!).GetNew();
            ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = AScriptReference.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public AScriptReference DeepCopy(
            IAScriptReferenceGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            AScriptReference ret = (AScriptReference)((AScriptReferenceCommon)((IAScriptReferenceGetter)item).CommonInstance()!).GetNew();
            ((AScriptReferenceSetterTranslationCommon)((IAScriptReferenceGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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

namespace Mutagen.Bethesda.Oblivion
{
    public partial class AScriptReference
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => AScriptReference_Registration.Instance;
        public static ILoquiRegistration StaticRegistration => AScriptReference_Registration.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonInstance() => AScriptReferenceCommon.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonSetterInstance()
        {
            return AScriptReferenceSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected virtual object CommonSetterTranslationInstance() => AScriptReferenceSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IAScriptReferenceGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object IAScriptReferenceGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object IAScriptReferenceGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Oblivion
{
    public partial class AScriptReferenceBinaryWriteTranslation : IBinaryWriteTranslator
    {
        public static readonly AScriptReferenceBinaryWriteTranslation Instance = new();

        public virtual void Write(
            MutagenWriter writer,
            IAScriptReferenceGetter item,
            TypedWriteParams translationParams)
        {
        }

        public virtual void Write(
            MutagenWriter writer,
            object item,
            TypedWriteParams translationParams = default)
        {
            Write(
                item: (IAScriptReferenceGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    internal partial class AScriptReferenceBinaryCreateTranslation
    {
        public static readonly AScriptReferenceBinaryCreateTranslation Instance = new AScriptReferenceBinaryCreateTranslation();

    }

}
namespace Mutagen.Bethesda.Oblivion
{
    #region Binary Write Mixins
    public static class AScriptReferenceBinaryTranslationMixIn
    {
        public static void WriteToBinary(
            this IAScriptReferenceGetter item,
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((AScriptReferenceBinaryWriteTranslation)item.BinaryWriteTranslator).Write(
                item: item,
                writer: writer,
                translationParams: translationParams);
        }

    }
    #endregion


}
namespace Mutagen.Bethesda.Oblivion
{
    internal abstract partial class AScriptReferenceBinaryOverlay :
        PluginBinaryOverlay,
        IAScriptReferenceGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => AScriptReference_Registration.Instance;
        public static ILoquiRegistration StaticRegistration => AScriptReference_Registration.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonInstance() => AScriptReferenceCommon.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonSetterTranslationInstance() => AScriptReferenceSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IAScriptReferenceGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object? IAScriptReferenceGetter.CommonSetterInstance() => null;
        [DebuggerStepThrough]
        object IAScriptReferenceGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        public virtual IEnumerable<IFormLinkGetter> EnumerateFormLinks() => AScriptReferenceCommon.Instance.EnumerateFormLinks(this);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual object BinaryWriteTranslator => AScriptReferenceBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((AScriptReferenceBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected AScriptReferenceBinaryOverlay(
            MemoryPair memoryPair,
            BinaryOverlayFactoryPackage package)
            : base(
                memoryPair: memoryPair,
                package: package)
        {
            this.CustomCtor();
        }


        #region To String

        public virtual void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            AScriptReferenceMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IAScriptReferenceGetter rhs) return false;
            return ((AScriptReferenceCommon)((IAScriptReferenceGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IAScriptReferenceGetter? obj)
        {
            return ((AScriptReferenceCommon)((IAScriptReferenceGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((AScriptReferenceCommon)((IAScriptReferenceGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

