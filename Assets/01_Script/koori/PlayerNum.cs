using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNum : MonoBehaviour
{
    public int pc1Num, pc2Num;
    [SerializeField] TMP_Text pc1NumText, pc2NumText;

    private void Start()
    {
        PCNumChange(0, 9);
    }

    public void PCNumChange(int num1, int num2)
    {
        pc1Num = num1;
        pc2Num = num2;
        pc1NumText.text = ($"{pc1Num}");
        pc2NumText.text = ($"{pc2Num}");
    }
}
