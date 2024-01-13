using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;

public class PushButton : MonoBehaviour
{
    string timeStamp;
    private StreamWriter streamWriter;
    private  string fileName = "aho";
    private GameObject buttonName;
    private string condition;
    private string logData;

    void Start()
    {
        Debug.Log(fileName);
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        streamWriter = new StreamWriter("Assets/" + fileName + ".csv");
        streamWriter.WriteLine("条件,タスク開始タイムスタンプ");
    }

    void Update()
    {
        Debug.Log(fileName);
        timeStamp = DateTime.Now.ToString("MM/dd HH:mm:ss:ff"); //0.01秒までのデータ
        logData = string.Format("{0},{1}", buttonName.name, timeStamp);
    }

    public void StartGaze100On()
    {
        streamWriter.WriteLine(logData);
        Debug.Log(logData);
    }

    void OnButtonClick()
    {
        string buttonName = gameObject.name;
        Debug.Log(buttonName);

    }

    void OnDestroy()
    {
        streamWriter.Close();
    }
}
