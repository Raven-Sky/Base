using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LoginPanel : BasePanel
{
    public void InitData()
    {
        Debug.Log("��ʼ����Ϣ��");
    }
    // Start is called before the first frame update
    void Start()
    {
        //GetControl<Button>("btnLogin").onClick.AddListener(()=> {
        //    Debug.Log("�ұ������");
        //});

        //  GetControl<Button>("btnExit").onClick.AddListener(()=> {
        //      Debug.Log("��Ҫ�˳���");
        //      this.gameObject.SetActive(false);
        //  });

        UIManager.AddCustomEventListener(GetControl<Button>("btnLogin"), EventTriggerType.PointerEnter, (data) =>
        {
            Debug.Log("��Ҫ������");
        });
        UIManager.AddCustomEventListener(GetControl<Button>("btnExit"), EventTriggerType.PointerExit, (data) =>
        {
            Debug.Log("��Ҫ�˳���");
        });
    }
    protected override void OnClick(string btnName)
    {
        switch (btnName)
        {
            case "btnLogin":
                Debug.Log("�ұ������");
                break;
            case "btnExit":
                Debug.Log("��Ҫ�˳���");
                break;
            default:
                break;
        }
    }

    public override void ShowMe()
    {

        Debug.Log("����ʾ�����ˣ�");
    }
    public override void HideMe()
    {
        Debug.Log("��Ҫ�����ˣ�");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
