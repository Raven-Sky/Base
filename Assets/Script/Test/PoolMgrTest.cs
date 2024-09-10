using UnityEngine;
public class PoolMgrTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoolMgr.GetInstance().GetObj("Prefabs/Cube", (o) => {
                Debug.Log(o.name + "加载成功！");
            });
        }
        if (Input.GetMouseButtonDown(1))
        {
            PoolMgr.GetInstance().GetObj("Prefabs/Sphere", (o) => {
                o.transform.position = new Vector3(2f, 0, 0);
                Debug.Log(o.name + "加载成功！");
            });
        }
    }
}

