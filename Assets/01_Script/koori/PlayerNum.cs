using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerNum : MonoBehaviour
{
    private int _pc1Num;
    private int _pc2Num;

    public int Pc1Num 
    {
        get 
        { 
            return _pc1Num; 
        }
        set
        { 
            if (value >= 100) 
            {
                _pc1Num = 99; 
            }
            else 
            {
                _pc1Num = value; 
            }
        }
    }


    public int Pc2Num { get {return _pc2Num; } set { if (value >= 100) { _pc2Num = 99; } else { _pc2Num = value; } } }
    [SerializeField] TMP_Text pc1NumText, pc2NumText;

    private void Start()
    {
        PCNumChange(StageManager.Instance.player1, StageManager.Instance.player1);
    }

    public void PCNumChange(int num1, int num2)
    {
        _pc1Num = num1;
        _pc2Num = num2;
        pc1NumText.text = ($"{_pc1Num}");
        pc2NumText.text = ($"{_pc2Num}");
    }
}
