using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SingletonAutoMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            GameObject obj = new GameObject();
            //���ö��������Ϊ�ű���
            obj.name = typeof(T).ToString();
            //���������ģʽ���� ������ ���Ƴ�
            //��Ϊ ����ģʽ���� ���� �Ǵ��������������������е�
            DontDestroyOnLoad(obj);
            instance = obj.AddComponent<T>();
        }
        return instance;
    }
}
