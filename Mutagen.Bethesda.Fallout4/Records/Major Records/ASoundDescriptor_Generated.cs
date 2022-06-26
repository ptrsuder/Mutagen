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
    /// <summary>
    /// Implemented by: [SoundDescriptorStandardData, SoundDescriptorCompoundData, SoundDescriptorAutoweaponData]
    /// </summary>
    public abstract partial class ASoundDescriptor :
        IASoundDescriptor,
        IEquatable<IASoundDescriptorGetter>,
        ILoquiObjectSetter<ASoundDescriptor>
    {
        #region Ctor
        public ASoundDescriptor()
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
            ASoundDescriptorMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IASoundDescriptorGetter rhs) return false;
            return ((ASoundDescriptorCommon)((IASoundDescriptorGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IASoundDescriptorGetter? obj)
        {
            return ((ASoundDescriptorCommon)((IASoundDescriptorGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((ASoundDescriptorCommon)((IASoundDescriptorGetter)this).CommonInstance()!).GetHashCode(this);

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
                var ret = new ASoundDescriptor.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public string Print(ASoundDescriptor.Mask<bool>? printMask = null)
            {
                var sb = new StructuredStringBuilder();
                Print(sb, printMask);
                return sb.ToString();
            }

            public void Print(StructuredStringBuilder sb, ASoundDescriptor.Mask<bool>? printMask = null)
            {
                sb.AppendLine($"{nameof(ASoundDescriptor.Mask<TItem>)} =>");
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
                ASoundDescriptor_FieldIndex enu = (ASoundDescriptor_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public virtual void SetNthException(int index, Exception ex)
            {
                ASoundDescriptor_FieldIndex enu = (ASoundDescriptor_FieldIndex)index;
                switch (enu)
                {
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public virtual void SetNthMask(int index, object obj)
            {
                ASoundDescriptor_FieldIndex enu = (ASoundDescriptor_FieldIndex)index;
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
        public virtual IEnumerable<IFormLinkGetter> EnumerateFormLinks() => ASoundDescriptorCommon.Instance.EnumerateFormLinks(this);
        public virtual void RemapLinks(IReadOnlyDictionary<FormKey, FormKey> mapping) => ASoundDescriptorSetterCommon.Instance.RemapLinks(this, mapping);
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual object BinaryWriteTranslator => ASoundDescriptorBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((ASoundDescriptorBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        void IClearable.Clear()
        {
            ((ASoundDescriptorSetterCommon)((IASoundDescriptorGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static ASoundDescriptor GetNew()
        {
            throw new ArgumentException("New called on an abstract class.");
        }

    }
    #endregion

    #region Interface
    /// <summary>
    /// Implemented by: [SoundDescriptorStandardData, SoundDescriptorCompoundData, SoundDescriptorAutoweaponData]
    /// </summary>
    public partial interface IASoundDescriptor :
        IASoundDescriptorGetter,
        IFormLinkContainer,
        ILoquiObjectSetter<IASoundDescriptor>
    {
    }

    /// <summary>
    /// Implemented by: [SoundDescriptorStandardData, SoundDescriptorCompoundData, SoundDescriptorAutoweaponData]
    /// </summary>
    public partial interface IASoundDescriptorGetter :
        ILoquiObject,
        IBinaryItem,
        IFormLinkContainerGetter,
        ILoquiObject<IASoundDescriptorGetter>
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration StaticRegistration => ASoundDescriptor_Registration.Instance;

    }

    #endregion

    #region Common MixIn
    public static partial class ASoundDescriptorMixIn
    {
        public static void Clear(this IASoundDescriptor item)
        {
            ((ASoundDescriptorSetterCommon)((IASoundDescriptorGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static ASoundDescriptor.Mask<bool> GetEqualsMask(
            this IASoundDescriptorGetter item,
            IASoundDescriptorGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((ASoundDescriptorCommon)((IASoundDescriptorGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string Print(
            this IASoundDescriptorGetter item,
            string? name = null,
            ASoundDescriptor.Mask<bool>? printMask = null)
        {
            return ((ASoundDescriptorCommon)((IASoundDescriptorGetter)item).CommonInstance()!).Print(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void Print(
            this IASoundDescriptorGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            ASoundDescriptor.Mask<bool>? printMask = null)
        {
            ((ASoundDescriptorCommon)((IASoundDescriptorGetter)item).CommonInstance()!).Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IASoundDescriptorGetter item,
            IASoundDescriptorGetter rhs,
            ASoundDescriptor.TranslationMask? equalsMask = null)
        {
            return ((ASoundDescriptorCommon)((IASoundDescriptorGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IASoundDescriptor lhs,
            IASoundDescriptorGetter rhs)
        {
            ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IASoundDescriptor lhs,
            IASoundDescriptorGetter rhs,
            ASoundDescriptor.TranslationMask? copyMask = null)
        {
            ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IASoundDescriptor lhs,
            IASoundDescriptorGetter rhs,
            out ASoundDescriptor.ErrorMask errorMask,
            ASoundDescriptor.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = ASoundDescriptor.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IASoundDescriptor lhs,
            IASoundDescriptorGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static ASoundDescriptor DeepCopy(
            this IASoundDescriptorGetter item,
            ASoundDescriptor.TranslationMask? copyMask = null)
        {
            return ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static ASoundDescriptor DeepCopy(
            this IASoundDescriptorGetter item,
            out ASoundDescriptor.ErrorMask errorMask,
            ASoundDescriptor.TranslationMask? copyMask = null)
        {
            return ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static ASoundDescriptor DeepCopy(
            this IASoundDescriptorGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IASoundDescriptor item,
            MutagenFrame frame,
            TypedParseParams translationParams = default)
        {
            ((ASoundDescriptorSetterCommon)((IASoundDescriptorGetter)item).CommonSetterInstance()!).CopyInFromBinary(
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
    internal enum ASoundDescriptor_FieldIndex
    {
    }
    #endregion

    #region Registration
    internal partial class ASoundDescriptor_Registration : ILoquiRegistration
    {
        public static readonly ASoundDescriptor_Registration Instance = new ASoundDescriptor_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Fallout4.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Fallout4.ProtocolKey,
            msgID: 640,
            version: 0);

        public const string GUID = "7547e927-38c6-4107-9efe-6f4305fb616e";

        public const ushort AdditionalFieldCount = 0;

        public const ushort FieldCount = 0;

        public static readonly Type MaskType = typeof(ASoundDescriptor.Mask<>);

        public static readonly Type ErrorMaskType = typeof(ASoundDescriptor.ErrorMask);

        public static readonly Type ClassType = typeof(ASoundDescriptor);

        public static readonly Type GetterType = typeof(IASoundDescriptorGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IASoundDescriptor);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Fallout4.ASoundDescriptor";

        public const string Name = "ASoundDescriptor";

        public const string Namespace = "Mutagen.Bethesda.Fallout4";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(ASoundDescriptorBinaryWriteTranslation);
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
    internal partial class ASoundDescriptorSetterCommon
    {
        public static readonly ASoundDescriptorSetterCommon Instance = new ASoundDescriptorSetterCommon();

        partial void ClearPartial();
        
        public virtual void Clear(IASoundDescriptor item)
        {
            ClearPartial();
        }
        
        #region Mutagen
        public void RemapLinks(IASoundDescriptor obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IASoundDescriptor item,
            MutagenFrame frame,
            TypedParseParams translationParams)
        {
        }
        
        #endregion
        
    }
    internal partial class ASoundDescriptorCommon
    {
        public static readonly ASoundDescriptorCommon Instance = new ASoundDescriptorCommon();

        public ASoundDescriptor.Mask<bool> GetEqualsMask(
            IASoundDescriptorGetter item,
            IASoundDescriptorGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new ASoundDescriptor.Mask<bool>(false);
            ((ASoundDescriptorCommon)((IASoundDescriptorGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IASoundDescriptorGetter item,
            IASoundDescriptorGetter rhs,
            ASoundDescriptor.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
        }
        
        public string Print(
            IASoundDescriptorGetter item,
            string? name = null,
            ASoundDescriptor.Mask<bool>? printMask = null)
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
            IASoundDescriptorGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            ASoundDescriptor.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                sb.AppendLine($"ASoundDescriptor =>");
            }
            else
            {
                sb.AppendLine($"{name} (ASoundDescriptor) =>");
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
            IASoundDescriptorGetter item,
            StructuredStringBuilder sb,
            ASoundDescriptor.Mask<bool>? printMask = null)
        {
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IASoundDescriptorGetter? lhs,
            IASoundDescriptorGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            return true;
        }
        
        public virtual int GetHashCode(IASoundDescriptorGetter item)
        {
            var hash = new HashCode();
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public virtual object GetNew()
        {
            return ASoundDescriptor.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> EnumerateFormLinks(IASoundDescriptorGetter obj)
        {
            yield break;
        }
        
        #endregion
        
    }
    internal partial class ASoundDescriptorSetterTranslationCommon
    {
        public static readonly ASoundDescriptorSetterTranslationCommon Instance = new ASoundDescriptorSetterTranslationCommon();

        #region DeepCopyIn
        public virtual void DeepCopyIn(
            IASoundDescriptor item,
            IASoundDescriptorGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
        }
        
        #endregion
        
        public ASoundDescriptor DeepCopy(
            IASoundDescriptorGetter item,
            ASoundDescriptor.TranslationMask? copyMask = null)
        {
            ASoundDescriptor ret = (ASoundDescriptor)((ASoundDescriptorCommon)((IASoundDescriptorGetter)item).CommonInstance()!).GetNew();
            ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public ASoundDescriptor DeepCopy(
            IASoundDescriptorGetter item,
            out ASoundDescriptor.ErrorMask errorMask,
            ASoundDescriptor.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ASoundDescriptor ret = (ASoundDescriptor)((ASoundDescriptorCommon)((IASoundDescriptorGetter)item).CommonInstance()!).GetNew();
            ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = ASoundDescriptor.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public ASoundDescriptor DeepCopy(
            IASoundDescriptorGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            ASoundDescriptor ret = (ASoundDescriptor)((ASoundDescriptorCommon)((IASoundDescriptorGetter)item).CommonInstance()!).GetNew();
            ((ASoundDescriptorSetterTranslationCommon)((IASoundDescriptorGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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
    public partial class ASoundDescriptor
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => ASoundDescriptor_Registration.Instance;
        public static ILoquiRegistration StaticRegistration => ASoundDescriptor_Registration.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonInstance() => ASoundDescriptorCommon.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonSetterInstance()
        {
            return ASoundDescriptorSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected virtual object CommonSetterTranslationInstance() => ASoundDescriptorSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IASoundDescriptorGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object IASoundDescriptorGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object IASoundDescriptorGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Fallout4
{
    public partial class ASoundDescriptorBinaryWriteTranslation : IBinaryWriteTranslator
    {
        public static readonly ASoundDescriptorBinaryWriteTranslation Instance = new();

        public virtual void Write(
            MutagenWriter writer,
            IASoundDescriptorGetter item,
            TypedWriteParams translationParams)
        {
        }

        public virtual void Write(
            MutagenWriter writer,
            object item,
            TypedWriteParams translationParams = default)
        {
            Write(
                item: (IASoundDescriptorGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    internal partial class ASoundDescriptorBinaryCreateTranslation
    {
        public static readonly ASoundDescriptorBinaryCreateTranslation Instance = new ASoundDescriptorBinaryCreateTranslation();

    }

}
namespace Mutagen.Bethesda.Fallout4
{
    #region Binary Write Mixins
    public static class ASoundDescriptorBinaryTranslationMixIn
    {
        public static void WriteToBinary(
            this IASoundDescriptorGetter item,
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((ASoundDescriptorBinaryWriteTranslation)item.BinaryWriteTranslator).Write(
                item: item,
                writer: writer,
                translationParams: translationParams);
        }

    }
    #endregion


}
namespace Mutagen.Bethesda.Fallout4
{
    internal abstract partial class ASoundDescriptorBinaryOverlay :
        PluginBinaryOverlay,
        IASoundDescriptorGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => ASoundDescriptor_Registration.Instance;
        public static ILoquiRegistration StaticRegistration => ASoundDescriptor_Registration.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonInstance() => ASoundDescriptorCommon.Instance;
        [DebuggerStepThrough]
        protected virtual object CommonSetterTranslationInstance() => ASoundDescriptorSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IASoundDescriptorGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object? IASoundDescriptorGetter.CommonSetterInstance() => null;
        [DebuggerStepThrough]
        object IASoundDescriptorGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        public virtual IEnumerable<IFormLinkGetter> EnumerateFormLinks() => ASoundDescriptorCommon.Instance.EnumerateFormLinks(this);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected virtual object BinaryWriteTranslator => ASoundDescriptorBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams translationParams = default)
        {
            ((ASoundDescriptorBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected ASoundDescriptorBinaryOverlay(
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
            ASoundDescriptorMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IASoundDescriptorGetter rhs) return false;
            return ((ASoundDescriptorCommon)((IASoundDescriptorGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IASoundDescriptorGetter? obj)
        {
            return ((ASoundDescriptorCommon)((IASoundDescriptorGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((ASoundDescriptorCommon)((IASoundDescriptorGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

