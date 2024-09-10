using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LoginPanel : BasePanel
{
    public void InitData()
    {
        Debug.Log("初始化信息！");
    }
    // Start is called before the first frame update
    void Start()
    {
        //GetControl<Button>("btnLogin").onClick.AddListener(()=> {
        //    Debug.Log("我被点击了");
        //});

        //  GetControl<Button>("btnExit").onClick.AddListener(()=> {
        //      Debug.Log("我要退出了");
        //      this.gameObject.SetActive(false);
        //  });

        UIManager.AddCustomEventListener(GetControl<Button>("btnLogin"), EventTriggerType.PointerEnter, (data) =>
        {
            Debug.Log("我要进入了");
        });
        UIManager.AddCustomEventListener(GetControl<Button>("btnExit"), EventTriggerType.PointerExit, (data) =>
        {
            Debug.Log("我要退出了");
        });
    }
    protected override void OnClick(string btnName)
    {
        switch (btnName)
        {
            case "btnLogin":
                Debug.Log("我被点击了");
                break;
            case "btnExit":
                Debug.Log("我要退出了");
                break;
            default:
                break;
        }
    }

    public override void ShowMe()
    {

        Debug.Log("我显示出来了！");
    }
    public override void HideMe()
    {
        Debug.Log("我要隐藏了！");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
