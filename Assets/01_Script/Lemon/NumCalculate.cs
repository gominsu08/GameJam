using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCalculate : MonoBehaviour
{
    private int pc1num; // �÷��̾� �� ���� �ʿ�
    private int pc2num; // �÷��̾� �� ���� �ʿ�
    [SerializeField] BossNumber bossNumber;
    [SerializeField] RoundManager roundManager;

    public void StageClear(int pc1num , int pc2num , int bossnum) 
    {
        if ((pc1num <= bossnum & bossnum <= pc2num) || (pc2num <= bossnum & bossnum <= pc1num))
        {
            roundManager.isRoundWin = true;
        }
        else 
        {
            roundManager.isRoundWin = false; 
        }
    }
}
