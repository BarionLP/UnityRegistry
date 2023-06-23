using System.Collections;
using System.Collections.Generic;
using Ametrin.AutoRegistry;
using UnityEngine;

public class RegistryTester : MonoBehaviour{
    private readonly ScriptableObjectRegistry<string, Item> ItemRegistry = new(item => item.name, false);

    private void Awake(){
        ItemRegistry.Init();
        print(ItemRegistry.Count);
    }
}
