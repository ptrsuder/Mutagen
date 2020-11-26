using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Mutagen.Bethesda
{
    /// <summary>
    /// A link cache that allows a top set of mods on the load order to be modified without
    /// invalidating the cache.  This comes at a performance cost of needing to query those mods
    /// for every request.
    /// </summary>
    public class MutableLoadOrderLinkCache<TMod, TModGetter> : ILinkCache
        where TMod : class, IMod
        where TModGetter : class, IModGetter
    {
        public ImmutableLoadOrderLinkCache<TModGetter> WrappedImmutableCache { get; }
        private readonly List<MutableModLinkCache<TMod>> _mutableMods;

        /// <summary>
        /// Constructs a mutable load order link cache by combining an existing immutable load order cache,
        /// plus a set of mods to be put at the end of the load order and allow to be mutable.
        /// </summary>
        /// <param name="immutableBaseCache">LoadOrderCache to use as the immutable base</param>
        /// <param name="mutableMods">Set of mods to place at the end of the load order, which are allowed to be modified afterwards</param>
        public MutableLoadOrderLinkCache(ImmutableLoadOrderLinkCache<TModGetter> immutableBaseCache, params TMod[] mutableMods)
        {
            WrappedImmutableCache = immutableBaseCache;
            _mutableMods = mutableMods.Select(m => m.ToMutableLinkCache()).ToList();
        }

        /// <inheritdoc />
        public IReadOnlyList<IModGetter> ListedOrder => throw new NotImplementedException();

        /// <inheritdoc />
        public IReadOnlyList<IModGetter> PriorityOrder => throw new NotImplementedException();

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public bool TryResolve(FormKey formKey, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            for (int i = _mutableMods.Count - 1; i >= 0; i--)
            {
                if (_mutableMods[i].TryResolve(formKey, out majorRec)) return true;
            }
            return WrappedImmutableCache.TryResolve(formKey, out majorRec);
        }

        /// <inheritdoc />
        public bool TryResolve<TMajor>(FormKey formKey, [MaybeNullWhen(false)] out TMajor majorRec)
            where TMajor : class, IMajorRecordCommonGetter
        {
            for (int i = _mutableMods.Count - 1; i >= 0; i--)
            {
                if (_mutableMods[i].TryResolve<TMajor>(formKey, out majorRec)) return true;
            }
            return WrappedImmutableCache.TryResolve<TMajor>(formKey, out majorRec);
        }

        /// <inheritdoc />
        public bool TryResolve(FormKey formKey, Type type, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            for (int i = _mutableMods.Count - 1; i >= 0; i--)
            {
                if (_mutableMods[i].TryResolve(formKey, type, out majorRec)) return true;
            }
            return WrappedImmutableCache.TryResolve(formKey, type, out majorRec);
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(FormKey formKey)
        {
            if (TryResolve<IMajorRecordCommonGetter>(formKey, out var majorRec)) return majorRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(FormKey formKey, Type type)
        {
            if (TryResolve(formKey, type, out var commonRec)) return commonRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }

        /// <inheritdoc />
        public TMajor Resolve<TMajor>(FormKey formKey)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (TryResolve<TMajor>(formKey, out var commonRec)) return commonRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }

        /// <summary>
        /// Adds a mutable mod to the end of the load order
        /// </summary>
        /// <param name="mod">Mod that is safe to mutate to add to end of load order</param>
        public void Add(TMod mod)
        {
            _mutableMods.Add(mod.ToMutableLinkCache());
        }
    }
}
