using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStageTimer : MonoBehaviour
{ 

    private float time;

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
       
        SceneManager.LoadScene("InGameScene");
    }

    [SerializeField] private TMP_Text text;

    private void Start()
    {
        Times = DataManager.Instance.time;
    }

    private void Update()
    {
        Times -= Time.deltaTime;

        text.text = $"남은시간 : {(int)Times}";


    }
}
