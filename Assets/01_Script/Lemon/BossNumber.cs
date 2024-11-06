using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossNumber : MonoBehaviour
{  
    public int _bossNum { get; private set; }
    [SerializeField] TMP_Text bossNumText;
    [SerializeField] RoundManager roundManager;

    private void Start()
    {
        BossNumRand();
    }

    public void BossNumRand()
    {
        int rend = Random.Range(StageManager.Instance.minBossNum, StageManager.Instance.maxBossNum + 1);
        if (1 >= rend && 9 <= rend)
        {
            BossNumRand();
            return;
        }
        _bossNum = rend;
        bossNumText.text = $"목표숫자 [ {_bossNum} ]";
    }


}
