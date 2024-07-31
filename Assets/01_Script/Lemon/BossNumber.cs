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
        _bossNum = Random.Range(StageManager.Instance.minBossNum, StageManager.Instance.maxBossNum + 1);
        bossNumText.text = $"목표숫자 [ {_bossNum} ]";
    }


}
