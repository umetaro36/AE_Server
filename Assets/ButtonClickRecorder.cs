using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ButtonClickRecorder : MonoBehaviour
{
    private struct ButtonClickRecord
    {
        public string buttonName;
        public float timestamp;
        public string fileName;
    }

    private List<ButtonClickRecord> clickRecords = new List<ButtonClickRecord>();
    private string csvFilePath = "Assets/" + fileName + ".csv";

    void Start()
    {
        // 全てのボタンに対してクリック時のイベントを登録
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button.gameObject.name));
        }
    }

    void OnButtonClick(string buttonName)
    {
        // ボタンがクリックされたときのタイムスタンプを取得
        float timestamp = Time.time;

        // レコードを作成
        ButtonClickRecord record = new ButtonClickRecord
        {
            buttonName = buttonName,
            timestamp = timestamp
        };

        // レコードをリストに追加
        clickRecords.Add(record);

        // CSVファイルに記録
        WriteRecordToCSV(record);

        // デバッグ表示
        Debug.Log($"Button {buttonName} Clicked at Timestamp: {timestamp}");
    }

    private void WriteRecordToCSV(ButtonClickRecord record)
    {
        // CSVファイルが存在しない場合はヘッダーを書き込む
        if (!File.Exists(csvFilePath))
        {
            using (StreamWriter sw = new StreamWriter(csvFilePath, true))
            {
                sw.WriteLine("ButtonName,Timestamp");
            }
        }

        // レコードをCSVファイルに追加
        using (StreamWriter sw = new StreamWriter(csvFilePath, true))
        {
            sw.WriteLine($"{record.buttonName},{record.timestamp}");
        }
    }
}
