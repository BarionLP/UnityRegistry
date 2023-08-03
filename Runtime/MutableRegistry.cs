using System.Collections.Generic;
using Ametrin.Utils;

namespace Ametrin.Registry{
    public class MutableRegistry<TKey, TValue> : IRegistry<TKey, TValue> where TValue : UnityEngine.Object{
        private readonly IDictionary<TKey, TValue> Entries;
        public int Count => Entries.Count;
        public IEnumerable<TKey> Keys => Entries.Keys;
        public TValue this[TKey key] => Entries[key];

        public MutableRegistry(IDictionary<TKey, TValue> entries){
            Entries = entries;
        }

        public Result<TValue> TryGet(TKey key){
            if (Entries.TryGetValue(key, out var value)){
                return value;
            }
            return ResultStatus.NotFound;
        }

        public Result TryRegister(TKey key, TValue value){
            if (Entries.TryAdd(key, value)){
                return ResultStatus.Succeeded;
            }

            return ResultStatus.AlreadyExists;
        }
    }
}