using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackEnd;

public class BackendLogin
{
    private static BackendLogin _instance = null;

    public static BackendLogin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendLogin();
            }
            return _instance; 
        }

    }
    public void CustomSignUp(string username, string password)
    {
        //ȸ������ �����ϱ�
        Debug.Log("ȸ�������� ��û�մϴ�.");

        var bro = Backend.BMember.CustomSignUp(username, password);


        if (bro.IsSuccess())
        {
            Debug.LogFormat("ȸ������ ���� {0}", bro);
        }
        else
        {
            Debug.LogErrorFormat("ȸ������ ���� {0}", bro);
        }
    }

    public void CustomLogin(string username, string password) 
    {
        //�α��� ����
        Debug.Log("�α����� ��û�մϴ�.");

        var bro = Backend.BMember.CustomLogin(username, password);

        if (bro.IsSuccess()) 
        {
            Debug.LogFormat("�α��� ���� {0}", bro);
        }
        else  
        {
            Debug.LogErrorFormat("�α���  ���� {0}", bro);
        }
    }

    public void UpdateNickname(string nickname) 
    {
        //�г��� ���� �����ϱ� 
        Debug.Log("�г��� ������ ��û�մϴ�.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if(bro.IsSuccess()) 
        {
            Debug.LogFormat("' {1} '�̰ɷ� ���� ���� {0}", bro,nickname);
        }
        else
        {
            Debug.LogErrorFormat("�г��� ����  ���� {0}", bro);
        }
    }
    
}
