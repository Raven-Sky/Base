using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.GetInstance().ShowPanel<LoginPanel>("LoginPanel", E_UI_Layer.Mid, showPanel);
    }
    void showPanel(LoginPanel loginPanel)
    {
        loginPanel.InitData();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

