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

        LoadPlayerData(); // 게임 시작 시 데이터 로드
    }

    [ContextMenu("To Json Data")] // 컴포넌트 메뉴에 아래 함수를 호출하는 To Json Data 라는 명령어가 생성됨
    public void SavePlayerDataToJson()
    {
        EasyToJson.ToJson(playerData, "PlayerData", true);
    }

    [ContextMenu("Load Json Data")]
    public void LoadPlayerData()
    {
        playerData = EasyToJson.FromJson<SaveData>("PlayerData");

        // 만약 파일이 존재하지 않아서 playerData가 null이면,
        // 기본값으로 초기화하고 저장합니다.
        if (playerData == null)
        {
            playerData = new SaveData();
            SavePlayerDataToJson();
            Debug.Log("새로운 세이브 파일을 생성했습니다.");
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
