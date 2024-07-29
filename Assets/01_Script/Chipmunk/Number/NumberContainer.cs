using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumOperator
{
    addition, subtraction, multiplication, division, square
}
public class NumberContainer : MonoBehaviour
{
    [SerializeField] public EnumOperator operatorType = EnumOperator.addition;
    [SerializeField] public int number;
}
