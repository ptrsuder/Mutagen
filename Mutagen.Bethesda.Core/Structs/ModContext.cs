﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda
{
    public struct ModContext<TMod, TMajorSetter, TMajorGetter>
    {
        private readonly Func<TMod, TMajorGetter, TMajorSetter> _getOrAddAsOverride;
        public readonly TMajorGetter Record;

        public ModContext(TMajorGetter record, Func<TMod, TMajorGetter, TMajorSetter> getter)
        {
            Record = record;
            _getOrAddAsOverride = getter;
        }

        public static implicit operator TMajorGetter(ModContext<TMod, TMajorSetter, TMajorGetter> context)
        {
            return context.Record;
        }

        public TMajorSetter GetOrAddAsOverride(TMod mod)
        {
            return _getOrAddAsOverride(mod, Record);
        }
    }
}
