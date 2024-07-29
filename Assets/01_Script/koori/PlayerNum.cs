using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNum : MonoBehaviour
{
    public int pc1Num { get { return pc1Num; } set { if (value >= 100) { pc1Num = 99; } else { pc1Num = value; } } }
    public int pc2Num { get {return pc2Num; } set { if (value >= 100) { pc2Num = 99; } else { pc2Num = value; } } }
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
