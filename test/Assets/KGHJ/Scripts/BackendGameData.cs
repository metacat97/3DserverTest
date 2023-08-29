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


    //�����͸� ������ϱ� ���� �Լ��Դϴ�. ( Debug.Log(UserData);)
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"level : {level}");
        result.AppendLine($"attack: {atk}");
        result.AppendLine($"info : {info}");

        result.AppendLine($"inventory");
        foreach( var itemKey in inventory.Keys)
        {
            result.AppendLine($"| {itemKey} : {inventory[itemKey]}��");
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
        //�������� ���� �����ϱ�
        if (userData == null)
        {
            userData = new UserData();
        }

        Debug.Log("�����͸� �ʱ�ȭ�մϴ�.");
        userData.level = 1;
        userData.atk = 3.5f;
        userData.info = "�Ƴ翰�ϼ��� ���� �����Դϴ�/";

        userData.equipment.Add("����������");
        userData.equipment.Add("��ö ����");
        userData.equipment.Add("�츣�޽��� ��ȭ");

        userData.inventory.Add("��������",3);
        userData.inventory.Add("�Ͼ�����", 3);
        userData.inventory.Add("�Ķ�����", 3);

        Debug.Log("�ڳ� ������Ʈ ��Ͽ� �ش� �����͵��� �߰��մϴ�.");
        Param param = new Param();
        param.Add("level", userData.level);
        param.Add("atk", userData.atk);
        param.Add("info", userData.info);
        param.Add("equipment", userData.equipment);
        param.Add("inventory", userData.inventory);

        Debug.Log("�������� ������ ������ ��û�մϴ�.");
        var bro = Backend.GameData.Insert("USER_DATA", param);

        if(bro.IsSuccess())
        {
            Debug.LogFormat("�������� ������ ���Կ� �����߽��ϴ�. : {0}", bro);

            //������ ���������� �������Դϴ�.
            gameDataRowInDate = bro.GetInDate();
        }
        else
        {
            Debug.LogErrorFormat("�������� ������ ���Կ� �����߽�����. :{0} " , bro);
        }
    }

    public void GameDataGet()
    {
        //�������� �ҷ�����
    }

    public void LevelUp()
    {
        //���� ���� ���� �����ϱ�
    }

    public void GameDateUpdate()
    {
        //���� ���� ���� �����ϱ�
    }

}
