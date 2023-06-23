using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

public sealed class ScriptableObjectRegistry<TKey, T> where T : ScriptableObject{
    private readonly Func<T, TKey> KeyProvider;
    private readonly Dictionary<TKey, T> Entries = new();

    public ScriptableObjectRegistry(Func<T, TKey> keyProvider, bool autoInit = false){
        KeyProvider = keyProvider;
        
        if(autoInit) Init();
    }    

    public void Init(){
        var values = AssetDatabase.FindAssets($"t: {typeof(T).Name}").Select(AssetDatabase.GUIDToAssetPath).Select((path)=> AssetDatabase.LoadAssetAtPath<T>(path));
        foreach(var item in values){
            Entries.Add(KeyProvider(item), item);
        }
    }
}
