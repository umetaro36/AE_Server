using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CalculateLog : MonoBehaviour
{
    public void StartCroutine()
    {
        Debug.Log("CalculateLogまできてる");

        StartCoroutine(WaitForSecondsCoroutine(0.5f, "Hello!"));
    }

    public IEnumerator WaitForSecondsCoroutine(float seconds, string message)
    {
        //指定秒数待つ
        Debug.Log("0.5sec待つよ");
        yield return new WaitForSeconds(seconds);

        //メッセージ出力
        Debug.Log(message);

        yield return null;
    }
}

