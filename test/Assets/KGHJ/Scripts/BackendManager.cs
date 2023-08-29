using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ڳ� SDK namespace �߰�
using BackEnd;
using UnityEditor.PackageManager;
using System.Threading.Tasks;

public class BackendManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var bro = Backend.Initialize(true); //�ڳ� �ʱ�ȭ 

        // �ڳ� �ʱ�ȭ�� ���� ���䰪
        if (bro.IsSuccess())
        {
            Debug.LogFormat("�ʱ�ȭ ����: {0} ", bro); //������ ��� statusCode 204 Success
        }
        else 
        {
            Debug.LogErrorFormat("�ʱ�ȭ ����: {0} ", bro);  // ������ ��� statusCode 400�� ���� �߻� 
        }

        Test();
    }


    async void Test()
    {
        await Task.Run(() =>
        {
            //���� �׽�Ʈ ���̽� �߰�
            //BackendLogin.Instance.CustomSignUp("user1", "1234"); //  [HJ �߰�] �ڳ� ȸ������ �Լ�
            BackendLogin.Instance.CustomLogin("user1", "1234"); //[HJ �߰�] �ڳ� �α��� �Լ�
            //BackendLogin.Instance.UpdateNickname("���ش� �����̿ýô�"); //[HJ �߰�] �ڳ� �г��� ����
            //���� ���� ��� ���� ���� �߰�
            BackendGameData.Instance.GameDataInsert(); //[HJ �߰�] ������ ���� �Լ�

            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }
}
