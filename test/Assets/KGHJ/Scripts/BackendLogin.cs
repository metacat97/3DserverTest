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
        //회원가입 구현하기
        Debug.Log("회원가입을 요청합니다.");

        var bro = Backend.BMember.CustomSignUp(username, password);


        if (bro.IsSuccess())
        {
            Debug.LogFormat("회원가입 성공 {0}", bro);
        }
        else
        {
            Debug.LogErrorFormat("회원가입 실패 {0}", bro);
        }
    }

    public void CustomLogin(string username, string password) 
    {
        //로그인 구현
        Debug.Log("로그인을 요청합니다.");

        var bro = Backend.BMember.CustomLogin(username, password);

        if (bro.IsSuccess()) 
        {
            Debug.LogFormat("로그인 성공 {0}", bro);
        }
        else  
        {
            Debug.LogErrorFormat("로그인  실패 {0}", bro);
        }
    }

    public void UpdateNickname(string nickname) 
    {
        //닉네임 변경 구현하기 
        Debug.Log("닉네임 변경을 요청합니다.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if(bro.IsSuccess()) 
        {
            Debug.LogFormat("' {1} '이걸로 변경 성공 {0}", bro,nickname);
        }
        else
        {
            Debug.LogErrorFormat("닉네임 변경  실패 {0}", bro);
        }
    }
    
}
