using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// テキストに保存されたデータを読み出すクラス
/// </summary>
public class RecordReader 
{
    /// <summary>
    /// テキストファイルを読み込む
    /// </summary>
    /// <param name="filePath">ファイルのパス</param>
    List<string> ReadText(string filePath)
    {
        var textAsset = new StreamReader(filePath); 
        if (textAsset == null)
        {
            Debug.LogError("TextAsset is not found.");
            return null;
        }

        var textList = new List<string>();

        while (!textAsset.EndOfStream)
        {
            textList.Add(textAsset.ReadLine());
        }

        foreach (var text in textList)
        {
            Debug.Log(text);
        }

        return textList;
    }
}
