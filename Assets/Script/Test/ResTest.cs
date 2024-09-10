using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var obj = ResMgr.GetInstance().Load<GameObject>("Prefabs/Capsule");
            obj.transform.localScale *= 2;
            Debug.Log("资源加载成功！" + obj.name);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ResMgr.GetInstance().LoadAsync<GameObject>("Prefabs/Capsule", (obj) => {
                obj.transform.localScale *= 2;
                Debug.Log("资源加载成功！" + obj.name);
            });
            Debug.Log("没我啥事情！");
        }
    }
}

