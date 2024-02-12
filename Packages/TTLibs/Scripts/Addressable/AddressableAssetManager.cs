using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableAssetManager<Tkey, TValue> : IDisposable
{
    Dictionary<Tkey, AsyncOperationHandle<TValue>> assetDict = new ();
    public TValue GetValue(Tkey key)
    {
        if (assetDict.ContainsKey(key))
        {
            return assetDict[key].Result;
        }
        else
        {
            return default;
        }
    }

    public async Task<bool> LoadAssetAsync(Tkey key)
    {
        if(!assetDict.ContainsKey(key))
        {
            var handle = Addressables.LoadAssetAsync<TValue>(key.ToString());
            await handle.Task;
            if(handle.Status == AsyncOperationStatus.Succeeded)
            {
                assetDict.Add(key, handle);
                return true;
            }
        }
        Debug.LogError("Load asset failed: " + key);
        return false;
    }
    public void Dispose()
    {
        assetDict.Clear();
        foreach (var handle in assetDict.Values)
        {
            Addressables.Release(handle);
        }
    }
}
