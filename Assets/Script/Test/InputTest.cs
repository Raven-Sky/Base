using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputMgr.GetInstance().StartOrEndCheck(true);

        EventCenter.GetInstance().AddEventListener<KeyCode>("某键按下", CheckInputDown);
    }

    private void CheckInputDown(KeyCode arg0)
    {
        switch (arg0)
        {

            case KeyCode.W:
                Debug.Log("前进");
                break;
            case KeyCode.A:
                Debug.Log("向左");
                break;
            case KeyCode.S:
                Debug.Log("后退");
                break;
            case KeyCode.D:
                Debug.Log("向右");
                break;
            default:
                Debug.Log("未知");
                break;
        }
    }
}

