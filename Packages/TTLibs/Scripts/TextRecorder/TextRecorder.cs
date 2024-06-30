using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// カウント集計結果をテキストに保存するクラス
/// </summary>
public class TextRecorder 
{
    /// <summary>
    /// テキストファイルに書き込む
    /// </summary>
    /// <param name="textList">書き込むテキストのリスト</param>
    void WriteText(IReadOnlyList<string> textList) 
    {
        StreamWriter streamWriter = new StreamWriter("Assets/TTLibs/Scripts/TextRecorder/TextRecorder.txt");
        foreach (var text in textList)
        {
            streamWriter.WriteLine(text);
        }
        streamWriter.Close();
    }
}
