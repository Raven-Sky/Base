using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class myTest
{
    public myTest()
    {
        MonoMgr.GetInstance().StartCoroutine(Start());
    }
    public void Update()
    {
        Debug.Log("�����ˣ�");
    }
    IEnumerator Start()
    {

        yield return new WaitForSeconds(1f);
        Debug.Log("Э��ִ���ˣ�");
    }

}
public class MonoTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myTest test = new myTest();
        MonoMgr.GetInstance().AddUpdateListener(test.Update);
    }
}
