using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackEnd;
using System.Text;

public class UserData
{
    public int level = 1;
    public float atk = 3.5f;
    public string info = string.Empty;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public List<string> equipment = new List<string>();


    //데이터를 디버깅하기 위한 함수입니다. ( Debug.Log(UserData);)
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"level : {level}");
        result.AppendLine($"attack: {atk}");
        result.AppendLine($"info : {info}");

        result.AppendLine($"inventory");
        foreach( var itemKey in inventory.Keys)
        {
            result.AppendLine($"| {itemKey} : {inventory[itemKey]}개");
        }

        result.AppendLine($"equipment");
        foreach (var equip in equipment ) 
        {
            result.AppendLine($"|{equip}");
        }
        return result.ToString();
    }
}

public class BackendGameData
{
    private static BackendGameData _instance = null;

    public static BackendGameData Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new BackendGameData();
            }

            return _instance;
        }
    }
    public static UserData userData;

    private string gameDataRowInDate = string.Empty;


    public void GameDataInsert()
    {
        //게임정보 삽입 구현하기
        if (userData == null)
        {
            userData = new UserData();
        }

        Debug.Log("데이터를 초기화합니다.");
        userData.level = 1;
        userData.atk = 3.5f;
        userData.info = "아녕염하세요 인포 정보입니다/";

        userData.equipment.Add("전사의투구");
        userData.equipment.Add("강철 갑옷");
        userData.equipment.Add("헤르메스의 군화");

        userData.inventory.Add("빨간포션",3);
        userData.inventory.Add("하얀포션", 3);
        userData.inventory.Add("파란포션", 3);

        Debug.Log("뒤끝 업데이트 목록에 해당 데이터들을 추가합니다.");
        Param param = new Param();
        param.Add("level", userData.level);
        param.Add("atk", userData.atk);
        param.Add("info", userData.info);
        param.Add("equipment", userData.equipment);
        param.Add("inventory", userData.inventory);

        Debug.Log("게임정보 데이터 삽입을 요청합니다.");
        var bro = Backend.GameData.Insert("USER_DATA", param);

        if(bro.IsSuccess())
        {
            Debug.LogFormat("게임정보 데이터 삽입에 성공했습니다. : {0}", bro);

            //삽입한 게임정보의 고유값입니다.
            gameDataRowInDate = bro.GetInDate();
        }
        else
        {
            Debug.LogErrorFormat("게임정보 데이터 삽입에 실패했습ㄴ디ㅏ. :{0} " , bro);
        }
    }

    public void GameDataGet()
    {
        //게임정보 불러오기
    }

    public void LevelUp()
    {
        //게임 정보 수정 구현하기
    }

    public void GameDateUpdate()
    {
        //게임 정보 수정 구현하기
    }

}
