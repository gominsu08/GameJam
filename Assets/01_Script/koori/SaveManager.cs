using EasySave.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoSingleton<SaveManager>
{
    public SaveData playerData;

    private void Awake()
    {
        playerData = new SaveData();

        LoadPlayerData(); // ���� ���� �� ������ �ε�
    }

    [ContextMenu("To Json Data")] // ������Ʈ �޴��� �Ʒ� �Լ��� ȣ���ϴ� To Json Data ��� ��ɾ ������
    public void SavePlayerDataToJson()
    {
        EasyToJson.ToJson(playerData, "PlayerData", true);
    }

    [ContextMenu("Load Json Data")]
    public void LoadPlayerData()
    {
        playerData = EasyToJson.FromJson<SaveData>("PlayerData");

        // ���� ������ �������� �ʾƼ� playerData�� null�̸�,
        // �⺻������ �ʱ�ȭ�ϰ� �����մϴ�.
        if (playerData == null)
        {
            playerData = new SaveData();
            SavePlayerDataToJson();
            Debug.Log("���ο� ���̺� ������ �����߽��ϴ�.");
        }
    }
}
[System.Serializable]

public class SaveData
{
    public float musicVolume = 50, sfxVolume = 50;
    public BrightValue bright = BrightValue.Low;
    public bool effectOn = true;
    public int round = 0;
    public bool isDeveloper = false;
}
