using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    private DemoController demoController;
    private float countUp_GazeOn = 0.0f;
    private float countUp_GazeOff = 0.0f;
    private float gazingTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update関数の中に関数を書いたらそれもupdateの性質持つのかな．そして，外から呼び出すことはできるのかな
        countUp_GazeOn += Time.deltaTime;
        if(countUp_GazeOn >= gazingTime)
        {
            demoController.OnLookAtPlayerSelected();
            countUp_GazeOn = 0.0f;
        }

        

    }
}
