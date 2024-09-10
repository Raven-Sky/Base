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
        Debug.Log("更新了！");
    }
    IEnumerator Start()
    {

        yield return new WaitForSeconds(1f);
        Debug.Log("协程执行了！");
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
