using System.Collections.Generic;
using System.Linq;

namespace Ametrin.Registry.Unity{
    public sealed class MutableAssetRegistry<T> : MutableRegistry<string, T> where T : UnityEngine.Object{
        public MutableAssetRegistry() : base(new Dictionary<string, T>()){}
        public MutableAssetRegistry(IEnumerable<T> assets) : base(assets.ToDictionary(asset => asset.name)) {}
    }
}
