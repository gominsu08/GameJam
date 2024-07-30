using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _health.HP = DataManager.Instance.Hp;
    }

    private void Update()
    {
        _text.text = $"HP : {_health.HP}";
    }
}
