using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 뒤끝 SDK namespace 추가
using BackEnd;
using UnityEditor.PackageManager;
using System.Threading.Tasks;

public class BackendManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var bro = Backend.Initialize(true); //뒤끝 초기화 

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.LogFormat("초기화 성공: {0} ", bro); //성공일 경우 statusCode 204 Success
        }
        else 
        {
            Debug.LogErrorFormat("초기화 실패: {0} ", bro);  // 실패일 경우 statusCode 400대 에러 발생 
        }

        Test();
    }


    async void Test()
    {
        await Task.Run(() =>
        {
            //추후 테스트 케이스 추가
            //BackendLogin.Instance.CustomSignUp("user1", "1234"); //  [HJ 추가] 뒤끝 회원가입 함수
            BackendLogin.Instance.CustomLogin("user1", "1234"); //[HJ 추가] 뒤끝 로그인 함수
            //BackendLogin.Instance.UpdateNickname("형준닉 변경이올시다"); //[HJ 추가] 뒤끝 닉네임 변경
            //게임 정보 기능 구현 로직 추가
            BackendGameData.Instance.GameDataInsert(); //[HJ 추가] 데이터 삽입 함수

            Debug.Log("테스트를 종료합니다.");
        });
    }
}
