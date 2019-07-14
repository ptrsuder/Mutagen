﻿using Noggog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Binary
{
    public abstract class BinaryWrapperSetList<T>
    {
        public static IReadOnlySetList<T> FactoryByArray(
            ReadOnlyMemorySlice<byte> mem,
            BinaryWrapperFactoryPackage package,
            UtilityTranslation.BinaryWrapperSpanFactory<T> getter,
            int[] locs)
        {
            return new BinaryWrapperSetListByLocationArray(
                mem,
                package,
                getter,
                locs);
        }

        public static IReadOnlySetList<T> FactoryByStartIndex(
            ReadOnlyMemorySlice<byte> mem,
            BinaryWrapperFactoryPackage package,
            int itemLength,
            UtilityTranslation.BinaryWrapperSpanFactory<T> getter)
        {
            return new BinaryWrapperSetListByStartIndex(
                mem,
                package,
                getter,
                itemLength);
        }

        private class BinaryWrapperSetListByLocationArray : IReadOnlySetList<T>
        {
            private int[] _locations;
            BinaryWrapperFactoryPackage _package;
            private ReadOnlyMemorySlice<byte> _mem;
            private UtilityTranslation.BinaryWrapperSpanFactory<T> _getter;

            public BinaryWrapperSetListByLocationArray(
                ReadOnlyMemorySlice<byte> mem,
                BinaryWrapperFactoryPackage package,
                UtilityTranslation.BinaryWrapperSpanFactory<T> getter,
                int[] locs)
            {
                this._mem = mem;
                this._getter = getter;
                this._package = package;
                this._locations = locs;
            }

            public T this[int index] => _getter(_mem.Slice(_locations[index]), _package);

            public int Count => _locations.Length;

            public bool HasBeenSet => true;

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < _locations.Length; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        public class BinaryWrapperSetListByStartIndex : IReadOnlySetList<T>
        {
            private int _itemLength;
            BinaryWrapperFactoryPackage _package;
            private ReadOnlyMemorySlice<byte> _mem;
            private UtilityTranslation.BinaryWrapperSpanFactory<T> _getter;

            public BinaryWrapperSetListByStartIndex(
                ReadOnlyMemorySlice<byte> mem,
                BinaryWrapperFactoryPackage package,
                UtilityTranslation.BinaryWrapperSpanFactory<T> getter,
                int itemLength)
            {
                this._mem = mem;
                this._package = package;
                this._getter = getter;
                this._itemLength = itemLength;
            }

            public T this[int index]
            {
                get
                {
                    var startIndex = index * _itemLength;
                    return _getter(_mem.Slice(startIndex, startIndex + _itemLength), _package);
                }
            }

            public int Count => this._mem.Length / _itemLength;

            public bool HasBeenSet => true;

            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < this.Count; i++)
                {
                    yield return this[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}
