using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossNumber : MonoBehaviour
{  
    private int _bossNum;
    [SerializeField] TMP_Text bossNumText;
    [SerializeField] RoundManager roundManager;

    private void Start()
    {
        BossNumRand();
    }

    public void BossNumRand()
    {
        _bossNum = Random.Range(1, 99);
        bossNumText.text = $"BossNum [ {_bossNum} ]";
    }


}
