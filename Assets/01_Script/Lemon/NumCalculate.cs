using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCalculate : MonoBehaviour
{
    private int pc1num; // 플레이어 넘 연결 필요
    private int pc2num; // 플레이어 넘 연결 필요
    [SerializeField] BossNumber bossNumber;
    [SerializeField] RoundManager roundManager;
    [SerializeField] private PlayerNum playerNum;

    private void Update()
    {
        pc1num = playerNum.Pc1Num;
        pc2num = playerNum.Pc2Num;
    }

    public void StageClear() 
    {

        if ((pc1num <= bossNumber._bossNum && bossNumber._bossNum <= pc2num) || (pc2num <= bossNumber._bossNum & bossNumber._bossNum <= pc1num))
        {
            StartCoroutine(Clear());
        }
        else 
        {
            roundManager.isRoundWin = false;
            roundManager.EndRound();
        }

        
    }

    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(1);
        roundManager.isRoundWin = true;
        StageManager.Instance.StageReset();
        roundManager.EndRound();
        bossNumber.BossNumRand();


    }
}
