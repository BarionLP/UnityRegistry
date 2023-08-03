using System.Collections;
using System.Collections.Generic;
using Ametrin.Registry;
using UnityEngine;

public class RegistryTester : MonoBehaviour{
    [SerializeField] private Item[] items;
    private AssetRegistry<Item> ItemRegistry;

    private void Awake(){
        ItemRegistry = new(items);
        items = null; //releasing the memory
        print(ItemRegistry.Count);
    }
}
