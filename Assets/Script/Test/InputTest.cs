using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputMgr.GetInstance().StartOrEndCheck(true);

        EventCenter.GetInstance().AddEventListener<KeyCode>("ĳ������", CheckInputDown);
    }

    private void CheckInputDown(KeyCode arg0)
    {
        switch (arg0)
        {

            case KeyCode.W:
                Debug.Log("ǰ��");
                break;
            case KeyCode.A:
                Debug.Log("����");
                break;
            case KeyCode.S:
                Debug.Log("����");
                break;
            case KeyCode.D:
                Debug.Log("����");
                break;
            default:
                Debug.Log("δ֪");
                break;
        }
    }
}

