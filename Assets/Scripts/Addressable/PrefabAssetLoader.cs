using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabAssetLoader : MonoBehaviour
{
    AddressableAssetManager<string, GameObject> assetManager = new AddressableAssetManager<string, GameObject>();

    private async void Start()
    {
        await assetManager.LoadAssetAsync("tree");
        var tree = assetManager.GetValue("tree");
        GameObjectExtension.InstantiateSafe(tree);
    }
}
