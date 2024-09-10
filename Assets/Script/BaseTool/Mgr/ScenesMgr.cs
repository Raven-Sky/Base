using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// �����л�ģ��
/// ֪ʶ��
/// 1.�����첽����
/// 2.Э��
/// 3.ί��
/// </summary>
public class ScenesMgr : BaseManager<ScenesMgr>
{
    /// <summary>
    /// �л����� ͬ��
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(string name, UnityAction fun)
    {
        //����ͬ������
        SceneManager.LoadScene(name);
        //������ɹ��� �Ż�ȥִ��fun
        fun();
    }

    /// <summary>
    /// �ṩ���ⲿ�� �첽���صĽӿڷ���
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fun"></param>
    public void LoadSceneAsyn(string name, UnityAction fun)
    {
        MonoMgr.GetInstance().StartCoroutine(ReallyLoadSceneAsyn(name, fun));
    }

    /// <summary>
    /// Э���첽���س���
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
                EventCenter.GetInstance().EventTrigger("����������", disProgress);
            }
            yield return currentProgress;
        }

        while (disProgress <= 1)
        {
            disProgress += 0.01f;
            EventCenter.GetInstance().EventTrigger("����������", disProgress);
            yield return disProgress;

        }
        //ao.allowSceneActivation = true;
        //���Եõ��������ص�һ������
        while (!ao.isDone)
        {
            //�¼����� ����ַ� �������  �������þ���
            EventCenter.GetInstance().EventTrigger("����������", 1f);
            if (disProgress >= 0.9f)
            {
                ao.allowSceneActivation = true;

            }
            //������ȥ���½�����
            yield return ao.progress;
        }
        //������ɹ��� �Ż�ȥִ��fun
        fun();
    }
}

