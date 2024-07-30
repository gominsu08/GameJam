using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMana : MonoBehaviour
{
    private void Awake()
    {
        DataManager.Instance.round = 0;
    }
}
