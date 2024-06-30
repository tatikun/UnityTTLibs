using UnityEngine;

public static class GameObjectExtension
{
    public static void InstantiateSafe(Object prefab, Vector3 position = default, Quaternion rotation = default, Transform parent = default)
    {
        if (prefab == null)
        {
#if DEBUG
            Debug.LogError("Prefab is null.");
#endif
            return;
        }
        var go = Object.Instantiate(prefab, position, rotation, parent);
        go.name = prefab.name;
    }
}
