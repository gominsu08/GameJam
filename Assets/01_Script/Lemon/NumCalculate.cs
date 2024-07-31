using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCalculate : MonoBehaviour
{
    private int pc1num; // �÷��̾� �� ���� �ʿ�
    private int pc2num; // �÷��̾� �� ���� �ʿ�
    [SerializeField] BossNumber bossNumber;
    [SerializeField] RoundManager roundManager;
    [SerializeField] private PlayerNum playerNum;

    [SerializeField] private GameObject _player1; 
    [SerializeField] private GameObject _player2;

    private void Awake()
    {
        
    }

    private void Update()
    {
        pc1num = playerNum.Pc1Num;
        pc2num = playerNum.Pc2Num;
        if (((pc1num <= bossNumber._bossNum && bossNumber._bossNum <= pc2num) || (pc2num <= bossNumber._bossNum & bossNumber._bossNum <= pc1num)) && StageManager.Instance.isEnemyReset)
        {
            roundManager.timer.TimeSet();
            roundManager.timer.RoundEnd();
            StageManager.Instance.isEnemyReset = false;
        }
    }

    public void StageClear() 
    {
        Grid.Instance.Reset();

        if ((pc1num <= bossNumber._bossNum && bossNumber._bossNum <= pc2num) || (pc2num <= bossNumber._bossNum & bossNumber._bossNum <= pc1num))
        {
            StartCoroutine(Clear());
            InputReader.Instance.controls.Default.Disable();
        }
        else 
        {
            roundManager.isRoundWin = false;
            DataManager.Instance.Hp = pc1num + pc2num;
            DataManager.Instance.bossTime = 
                ((pc1num > pc2num ? pc1num : pc2num) < bossNumber._bossNum ?
                bossNumber._bossNum - (pc1num > pc2num ? pc1num : pc2num) : (pc1num > pc2num ? pc2num : pc1num) - bossNumber._bossNum) + 10;
            roundManager.EndRound();
        }
    }

    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(1);
        _player1.transform.position = new Vector3(0,1,0);
        _player2.transform.position = new Vector3(2,1,0);
        roundManager.isRoundWin = true;
        DataManager.Instance.round++;

        StageManager.Instance.StageReset();
        roundManager.timer.SetTime = StageManager.Instance.roundTime;
        StageManager.Instance.TileSetCoroutineStart();
        roundManager.EndRound();
        bossNumber.BossNumRand();


    }
}
