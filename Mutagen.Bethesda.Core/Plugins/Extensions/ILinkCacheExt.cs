using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda.Cache.Implementations;
using Mutagen.Bethesda.Plugins.Order;
using Noggog;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Plugins.Records;

namespace Mutagen.Bethesda
{
    public static class ILinkCacheExt
    {
        /// <summary>
        /// Creates a Link Cache using a single mod as its link target. <br/>
        /// Modification of the target Mod is not safe.  Internal caches can become incorrect if 
        /// modifications occur on content already cached.
        /// </summary>
        /// <param name="mod">Mod to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given mod</returns>
        public static ImmutableModLinkCache ToUntypedImmutableLinkCache(
            this IModGetter mod,
            LinkCachePreferences? prefs = null)
        {
            return new ImmutableModLinkCache(mod, prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a new linking package relative to a load order.<br/>
        /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
        /// Modification of the target LoadOrder, or Mods on the LoadOrder is not safe.  Internal caches can become
        /// incorrect if modifications occur on content already cached.
        /// </summary>
        /// <param name="loadOrder">LoadOrder to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static ImmutableLoadOrderLinkCache ToUntypedImmutableLinkCache(
            this LoadOrder<IModGetter> loadOrder,
            LinkCachePreferences? prefs = null)
        {
            return new ImmutableLoadOrderLinkCache(loadOrder.ListedOrder, prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a new linking package relative to a load order.<br/>
        /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
        /// Modification of the target LoadOrder, or Mods on the LoadOrder is not safe.  Internal caches can become
        /// incorrect if modifications occur on content already cached.
        /// </summary>
        /// <param name="loadOrder">LoadOrder to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static ImmutableLoadOrderLinkCache ToUntypedImmutableLinkCache(
            this LoadOrder<IModListing<IModGetter>> loadOrder,
            LinkCachePreferences? prefs = null)
        {
            return new ImmutableLoadOrderLinkCache(
                loadOrder
                    .Select(listing => listing.Value.Mod)
                    .NotNull(),
                prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a new linking package relative to a load order.<br/>
        /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
        /// Modification of the target LoadOrder, or Mods on the LoadOrder is not safe.  Internal caches can become
        /// incorrect if modifications occur on content already cached.
        /// </summary>
        /// <param name="loadOrder">LoadOrder to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static ImmutableLoadOrderLinkCache ToUntypedImmutableLinkCache(
            this IEnumerable<IModListing<IModGetter>> loadOrder,
            LinkCachePreferences? prefs = null)
        {
            return new ImmutableLoadOrderLinkCache(
                loadOrder
                    .Select(listing => listing.Mod)
                    .NotNull(),
                prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a new linking package relative to a load order.<br/>
        /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
        /// Modification of mods on the load order is not safe.  Internal caches can become
        /// incorrect if modifications occur on content already cached.
        /// </summary>
        /// <param name="loadOrder">Enumerable of mods to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static ImmutableLoadOrderLinkCache ToImmutableLinkCache(
            this IEnumerable<IModGetter> loadOrder,
            LinkCachePreferences? prefs = null)
        {
            return new ImmutableLoadOrderLinkCache(loadOrder, prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a Link Cache using a single mod as its link target. <br/>
        /// Modification of the target Mod is not safe.  Internal caches can become incorrect if 
        /// modifications occur on content already cached.
        /// </summary>
        /// <param name="mod">Mod to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given mod</returns>
        public static ImmutableModLinkCache<TMod, TModGetter> ToImmutableLinkCache<TMod, TModGetter>(
            this TModGetter mod,
            LinkCachePreferences? prefs = null)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new ImmutableModLinkCache<TMod, TModGetter>(mod, prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a Link Cache using a single mod as its link target.  Mod is allowed to be modified afterwards, but
        /// this comes at a performance cost of not allowing much caching to be done.  If the mod is not expected to
        /// be modified afterwards, use ImmutableModLinkCache instead.<br/>
        /// </summary>
        /// <param name="mod">Mod to construct the package relative to</param>
        /// <returns>LinkPackage attached to given mod</returns>
        public static MutableModLinkCache<TMod, TModGetter> ToMutableLinkCache<TMod, TModGetter>(
            this TModGetter mod)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new MutableModLinkCache<TMod, TModGetter>(mod);
        }

        /// <summary>
        /// Creates a new linking package relative to a load order.<br/>
        /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
        /// Modification of the target LoadOrder, or Mods on the LoadOrder is not safe.  Internal caches can become
        /// incorrect if modifications occur on content already cached.
        /// </summary>
        /// <param name="loadOrder">LoadOrder to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static ImmutableLoadOrderLinkCache<TMod, TModGetter> ToImmutableLinkCache<TMod, TModGetter>(
            this LoadOrder<TModGetter> loadOrder,
            LinkCachePreferences? prefs = null)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new ImmutableLoadOrderLinkCache<TMod, TModGetter>(loadOrder.ListedOrder, prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a new linking package relative to a load order.<br/>
        /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
        /// Modification of the target LoadOrder, or Mods on the LoadOrder is not safe.  Internal caches can become
        /// incorrect if modifications occur on content already cached.
        /// </summary>
        /// <param name="loadOrder">LoadOrder to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static ImmutableLoadOrderLinkCache<TMod, TModGetter> ToImmutableLinkCache<TMod, TModGetter>(
            this LoadOrder<IModListing<TModGetter>> loadOrder,
            LinkCachePreferences? prefs = null)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new ImmutableLoadOrderLinkCache<TMod, TModGetter>(
                loadOrder
                    .Select(listing => listing.Value.Mod)
                    .NotNull(),
                prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a new linking package relative to a load order.<br/>
        /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
        /// Modification of the target LoadOrder, or Mods on the LoadOrder is not safe.  Internal caches can become
        /// incorrect if modifications occur on content already cached.
        /// </summary>
        /// <param name="loadOrder">LoadOrder to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static ImmutableLoadOrderLinkCache<TMod, TModGetter> ToImmutableLinkCache<TMod, TModGetter>(
            this IEnumerable<IModListing<TModGetter>> loadOrder,
            LinkCachePreferences? prefs = null)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new ImmutableLoadOrderLinkCache<TMod, TModGetter>(
                loadOrder
                    .Select(listing => listing.Mod)
                    .NotNull(),
                prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a new linking package relative to a load order.<br/>
        /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
        /// Modification of mods on the load order is not safe.  Internal caches can become
        /// incorrect if modifications occur on content already cached.
        /// </summary>
        /// <param name="loadOrder">Enumerable of mods to construct the package relative to</param>
        /// <param name="prefs">Caching preferences</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static ImmutableLoadOrderLinkCache<TMod, TModGetter> ToImmutableLinkCache<TMod, TModGetter>(
            this IEnumerable<TModGetter> loadOrder,
            LinkCachePreferences? prefs = null)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new ImmutableLoadOrderLinkCache<TMod, TModGetter>(loadOrder, prefs ?? LinkCachePreferences.Default);
        }

        /// <summary>
        /// Creates a mutable load order link cache by combining an existing immutable load order cache,
        /// plus a set of mods to be put at the end of the load order and allow to be mutable.
        /// </summary>
        /// <param name="immutableBaseCache">LoadOrderCache to use as the immutable base</param>
        /// <param name="mutableMods">Set of mods to place at the end of the load order, which are allowed to be modified afterwards</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static MutableLoadOrderLinkCache<TMod, TModGetter> ToMutableLinkCache<TMod, TModGetter>(
            this LoadOrder<TModGetter> immutableBaseCache,
            params TMod[] mutableMods)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new MutableLoadOrderLinkCache<TMod, TModGetter>(
                immutableBaseCache.ToImmutableLinkCache<TMod, TModGetter>(),
                mutableMods);
        }

        /// <summary>
        /// Creates a mutable load order link cache by combining an existing immutable load order cache,
        /// plus a set of mods to be put at the end of the load order and allow to be mutable.
        /// </summary>
        /// <param name="immutableBaseCache">LoadOrderCache to use as the immutable base</param>
        /// <param name="mutableMods">Set of mods to place at the end of the load order, which are allowed to be modified afterwards</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static MutableLoadOrderLinkCache<TMod, TModGetter> ToMutableLinkCache<TMod, TModGetter>(
            this LoadOrder<IModListing<TModGetter>> immutableBaseCache,
            params TMod[] mutableMods)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new MutableLoadOrderLinkCache<TMod, TModGetter>(
                immutableBaseCache.ToImmutableLinkCache<TMod, TModGetter>(),
                mutableMods);
        }

        /// <summary>
        /// Creates a mutable load order link cache by combining an existing immutable load order cache,
        /// plus a set of mods to be put at the end of the load order and allow to be mutable.
        /// </summary>
        /// <param name="immutableBaseCache">LoadOrderCache to use as the immutable base</param>
        /// <param name="mutableMods">Set of mods to place at the end of the load order, which are allowed to be modified afterwards</param>
        /// <returns>LinkPackage attached to given LoadOrder</returns>
        public static MutableLoadOrderLinkCache<TMod, TModGetter> ToMutableLinkCache<TMod, TModGetter>(
            this IEnumerable<TModGetter> immutableBaseCache,
            params TMod[] mutableMods)
            where TMod : class, IContextMod<TMod, TModGetter>, TModGetter
            where TModGetter : class, IContextGetterMod<TMod, TModGetter>
        {
            return new MutableLoadOrderLinkCache<TMod, TModGetter>(
                immutableBaseCache.ToImmutableLinkCache<TMod, TModGetter>(),
                mutableMods);
        }
    }
}