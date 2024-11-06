using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStageTimer : MonoBehaviour
{ 

    private float time;
    private int maxRound;
    public float Times
    {
        get {  return time; } 
        set
        {
            if (value <= 0)
            {
                BossStageClear();
            }
            else
            {
                time = value;
            }
        } 
    }

    private void BossStageClear()
    {
        SaveManager.Instance.LoadPlayerData();
        maxRound = SaveManager.Instance.playerData.round;

        int i = DataManager.Instance.round >= maxRound ? DataManager.Instance.round : maxRound;
        if (i == DataManager.Instance.round)
        {
            i = DataManager.Instance.round + 1;
        }

        SaveManager.Instance.playerData.round = i;
        SettingManager.Instance.DataSave();
        SaveManager.Instance.SavePlayerDataToJson();
        SceneManager.LoadScene("InGameScene");
    }

    [SerializeField] private TMP_Text text;

    private void Start()
    {
        Times = DataManager.Instance.bossTime;
    }

    private void Update()
    {
        Times -= Time.deltaTime;

        text.text = $"남은시간 : {(int)Times}";


    }
}
