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
    Dictionary<Tkey, TValue> assetDict = new Dictionary<Tkey, TValue>();
    private AsyncOperationHandle<TValue> handle;
    public TValue GetValue(Tkey key)
    {
        if (assetDict.ContainsKey(key))
        {
            return assetDict[key];
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
            handle = Addressables.LoadAssetAsync<TValue>(key.ToString());
            var result = await handle.Task;
            if(handle.Status == AsyncOperationStatus.Succeeded)
            {
                assetDict.Add(key, handle.Result);
                return true;
            }
        }
        Debug.LogError("Load asset failed: " + key);
        return false;
    }
    public void Dispose()
    {
        assetDict.Clear();
        Addressables.Release(handle);
    }
}
