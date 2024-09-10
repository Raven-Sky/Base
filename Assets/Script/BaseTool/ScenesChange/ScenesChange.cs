using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenesChange : MonoBehaviour
{
    public GameObject loadPanel;
    public Slider slider;
    float tempProgress;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        tempProgress = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneChange("EventTest");
        }
    }
    public void SceneChange(string sceneName)
    {
        //ScenesMgr.GetInstance().LoadScene("EventTest",()=> {
        //    Debug.Log("场景加载完毕");
        //});
        loadPanel.SetActive(true);
        EventCenter.GetInstance().AddEventListener<float>("进度条更新", (o) => {
            UpdateProgess(o);
        });
        ScenesMgr.GetInstance().LoadSceneAsyn(sceneName, () =>
        {
            Debug.Log("场景加载完毕");
        });
    }
    public void UpdateProgess(float progessVal)
    {
        //tempProgress = Mathf.Lerp(tempProgress, progessVal,Time.deltaTime);
        tempProgress = progessVal;
        Debug.Log("接收到" + tempProgress);
        slider.value = tempProgress;
        text.text = tempProgress * 100 + "%";
    }
}
