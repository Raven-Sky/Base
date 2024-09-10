using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//C#�� ����֪ʶ��
//���ģʽ ����ģʽ��֪ʶ��
//�̳��� MonoBehaviour �� ����ģʽ���� ��Ҫ�����Լ���֤����Ψһ��
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T GetInstance()
    {
        //�̳���Mono�Ľű� ���ܹ�ֱ��new
        //ֻ��ͨ���϶��������� ���� ͨ�� �ӽű���api AddComponentȥ�ӽű�
        //U3D�ڲ���������ʵ������
        return instance;
    }
    protected virtual void Awake()
    {
        instance = this as T;
        Debug.Log(1);
    }
}
