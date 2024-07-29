using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum EnumOperator
{
    Plus, Minus, Multiply, Division,
}
public class NumberContainer : MonoBehaviour
{
    [SerializeField] public EnumOperator operatorType = EnumOperator.Plus;
    [SerializeField] public TMP_Text text;
    [SerializeField] public int number;

    private void OnEnable()
    {
        switch (operatorType)
        {
            case EnumOperator.Plus:
                text.text = $"+{number}"; break;
            case EnumOperator.Minus:
                text.text = $"-{number}"; break;
            case EnumOperator.Division:
                text.text = $"/{number}"; break;
            case EnumOperator.Multiply:
                text.text = $"X{number}"; break;
        }
    }
}
