// 参考:https://zenn.dev/kd_gamegikenblg/articles/30b2b1139b213c

using System.Collections.Generic;
using UnityEngine;

// AIの目印となるWayPointのデータ
[System.Serializable]
public class WayPoint
{
    public enum TagTypes
    {
        None,
        Start,
        Treasure,
        Goal,
    }

    public Vector3 Position = Vector3.zero;
    public TagTypes Tag = TagTypes.None;
}

// WayPointのデータをまとめたScriptableObject
[CreateAssetMenu(fileName = "WayPoints", menuName = "MyGame/WayPoints", order = 1)]
public class WayPoints : ScriptableObject
{
    [field: SerializeField]
    public List<WayPoint> Points { get; private set; } = new List<WayPoint>();
}