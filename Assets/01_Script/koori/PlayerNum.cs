using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNum : MonoBehaviour
{
    private int _pc1Num, _pc2Num;
    [SerializeField] TMP_Text pc1NumText, pc2NumText;

    private void Start()
    {
        PCNumChange(0, 9);
    }

    public void PCNumChange(int num1, int num2)
    {
        _pc1Num = num1;
        _pc2Num = num2;
        pc1NumText.text = ($"{_pc1Num}");
        pc2NumText.text = ($"{_pc2Num}");
    }
}
