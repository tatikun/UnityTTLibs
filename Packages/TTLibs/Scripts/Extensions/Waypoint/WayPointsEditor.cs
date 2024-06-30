// 参考:https://zenn.dev/kd_gamegikenblg/articles/30b2b1139b213c

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WayPoints))]
public class WayPointsEditor : Editor
{
    // 操作する対象のScriptableObject
    private static WayPoints instance = null;

    // 選択されたとき
    private void OnEnable()
    {
        instance = target as WayPoints;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    // 選択が解除されたとき
    private void OnDisable()
    {
        instance = null;
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    // SceneViewのGUIを描画する
    private static void OnSceneGUI(SceneView sceneView)
    {
        if (instance == null) return;

        // WayPointの位置をSceneView上で変更できるハンドルを表示する
        for (int i = 0; i < instance.Points.Count; i++)
        {
            var wayPoint = instance.Points[i];

            // WayPointの位置を取得する
            Vector3 pos = wayPoint.Position;

            // ハンドルを表示する
            EditorGUI.BeginChangeCheck();
            pos = Handles.PositionHandle(pos, Quaternion.identity);

            // WayPointの位置が変更されたら反映する
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(instance, "Move WayPoint");
                wayPoint.Position = pos;
                EditorUtility.SetDirty(instance);
            }
        }

        // ラベルを表示する
        for (int i = 0; i < instance.Points.Count; i++)
        {
            var wayPoint = instance.Points[i];
            
            // WayPointの位置を取得する
            Vector3 pos = wayPoint.Position;

            // WayPointの位置にラベルを表示する
            GUIStyle style = new GUIStyle();
            switch (wayPoint.Tag)
            {
                case WayPoint.TagTypes.None:
                    style.normal.textColor = Color.white;
                    break;
                case WayPoint.TagTypes.Start:
                    style.normal.textColor = Color.green;
                    break;
                case WayPoint.TagTypes.Treasure:
                    style.normal.textColor = Color.yellow;
                    break;
                case WayPoint.TagTypes.Goal:
                    style.normal.textColor = Color.red;
                    break;
            }
            Handles.Label(pos, $"\n\n{i}: {wayPoint.Tag}", style);

            Handles.BeginGUI();

            // コンボボックス
            // スクリーン座標に変換する
            var screenPos = HandleUtility.WorldToGUIPointWithDepth(pos);
            // カメラの後ろには表示しない
            if (screenPos.z < 0) continue;

            // コンボボックスを表示する
            EditorGUI.BeginChangeCheck();
            var rect = new Rect(screenPos.x, screenPos.y + 10, 100, 20);
            var editedTag = (WayPoint.TagTypes)EditorGUI.EnumPopup(rect, wayPoint.Tag);
            // 変更されたら反映する
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(instance, "Edit Destination");
                wayPoint.Tag = editedTag;
                EditorUtility.SetDirty(instance);
            }

            Handles.EndGUI();
        }
    }
}