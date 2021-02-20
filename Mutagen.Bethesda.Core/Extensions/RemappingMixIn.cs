using System;
using System.Collections.Generic;
using System.Text;
using Noggog;

namespace Mutagen.Bethesda
{
    public static class RemappingMixIn
    {
        public static void Relink<TMajorGetter>(this IFormLink<TMajorGetter> link, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (!link.IsNull
                && mapping.TryGetValue(link.FormKey, out var replacement))
            {
                link.SetTo(replacement);
            }
        }

        private static IFormLinkGetter<TMajorGetter> RelinkToNew<TMajorGetter>(this IFormLinkGetter<TMajorGetter> link, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (!link.IsNull
                && mapping.TryGetValue(link.FormKey, out var replacement))
            {
                return new FormLink<TMajorGetter>(replacement);
            }
            return link;
        }

        private static IFormLinkNullableGetter<TMajorGetter> RelinkToNew<TMajorGetter>(this IFormLinkNullableGetter<TMajorGetter> link, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (link.FormKeyNullable.HasValue
                && !link.IsNull
                && mapping.TryGetValue(link.FormKey, out var replacement))
            {
                return new FormLinkNullable<TMajorGetter>(replacement);
            }
            return link;
        }

        public static void RemapLinks<TMajorGetter>(this IList<IFormLinkGetter<TMajorGetter>> linkList, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            for (int i = 0; i < linkList.Count; i++)
            {
                linkList[i] = linkList[i].RelinkToNew(mapping);
            }
        }

        public static void RemapLinks<TItem>(this IList<TItem> linkList, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TItem : IFormLinkContainer
        {
            foreach (var item in linkList)
            {
                item.RemapLinks(mapping);
            }
        }

        public static void RemapLinks<TItem>(this IGenderedItemGetter<TItem?> gendered, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TItem : class, IFormLinkContainer
        {
            gendered.Male?.RemapLinks(mapping);
            gendered.Female?.RemapLinks(mapping);
        }

        public static void RemapLinks<TMajorGetter>(this IGenderedItem<IFormLinkGetter<TMajorGetter>> gendered, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            gendered.Male = gendered.Male.RelinkToNew(mapping);
            gendered.Female = gendered.Female.RelinkToNew(mapping);
        }

        public static void RemapLinks<TMajorGetter>(this IGenderedItem<IFormLinkNullableGetter<TMajorGetter>> gendered, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            gendered.Male = gendered.Male.RelinkToNew(mapping);
            gendered.Female = gendered.Female.RelinkToNew(mapping);
        }

        public static void RemapLinks<TMajorGetter>(this IReadOnlyCache<TMajorGetter, FormKey> cache, IReadOnlyDictionary<FormKey, FormKey> mapping)
            where TMajorGetter : class, IMajorRecordCommonGetter, IFormLinkContainer
        {
            foreach (var item in cache.Items)
            {
                item.RemapLinks(mapping);
            }
        }
    }
}
