using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景切换模块
/// 知识点
/// 1.场景异步加载
/// 2.协程
/// 3.委托
/// </summary>
public class ScenesMgr : BaseManager<ScenesMgr>
{
    /// <summary>
    /// 切换场景 同步
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name, UnityAction fun)
    {
        //场景同步加载
        SceneManager.LoadScene(name);
        //加载完成过后 才会去执行fun
        fun();
    }

    /// <summary>
    /// 提供给外部的 异步加载的接口方法
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fun"></param>
    public void LoadSceneAsyn(string name, UnityAction fun)
    {
        MonoMgr.GetInstance().StartCoroutine(ReallyLoadSceneAsyn(name, fun));
    }

    /// <summary>
    /// 协程异步加载场景
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fun"></param>
    /// <returns></returns>
    private IEnumerator ReallyLoadSceneAsyn(string name, UnityAction fun)
    {
        float disProgress = 0;
        float currentProgress = 0;

        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        ao.allowSceneActivation = false;


        while (currentProgress < 0.9f)
        {
            currentProgress = ao.progress;
            while (disProgress < currentProgress)
            {
                disProgress += 0.01f;
                EventCenter.GetInstance().EventTrigger("进度条更新", disProgress);
            }
            yield return currentProgress;
        }

        while (disProgress <= 1)
        {
            disProgress += 0.01f;
            EventCenter.GetInstance().EventTrigger("进度条更新", disProgress);
            yield return disProgress;

        }
        //ao.allowSceneActivation = true;
        //可以得到场景加载的一个进度
        while (!ao.isDone)
        {
            //事件中心 向外分发 进度情况  外面想用就用
            EventCenter.GetInstance().EventTrigger("进度条更新", 1f);
            if (disProgress >= 0.9f)
            {
                ao.allowSceneActivation = true;

            }
            //这里面去更新进度条
            yield return ao.progress;
        }
        //加载完成过后 才会去执行fun
        fun();
    }
}

