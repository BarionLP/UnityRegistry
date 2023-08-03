using System;
using System.Linq;
using System.Collections.Generic;
using Ametrin.Utils;

namespace Ametrin.Registry{
    public class Registry<TKey, TValue> : IRegistry<TKey, TValue> where TValue : UnityEngine.Object{
        private readonly IReadOnlyDictionary<TKey, TValue> Entries;
        public int Count => Entries.Count;
        public IEnumerable<TKey> Keys => Entries.Keys;
        public TValue this[TKey key] => Entries[key];

        public Registry(IReadOnlyDictionary<TKey, TValue> entries) {
            Entries = entries;
        }
        public Registry(IEnumerable<TValue> values, Func<TValue, TKey> keyProvider) : this(values.ToDictionary(keyProvider)){}

        public Result<TValue> TryGet(TKey key){
            if (Entries.TryGetValue(key, out var value)){
                return value;
            }
            return ResultStatus.NotFound;
        }
    }
}