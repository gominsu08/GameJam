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
