using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaivour : MonoBehaviour
{
    public static SingletonMonoBehaivour Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
