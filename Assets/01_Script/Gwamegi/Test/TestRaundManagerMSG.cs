using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TestRaundManagerMSG : MonoBehaviour
{
    [SerializeField] private float _Raundtime;
    private float _time;
    public float Time
    {
        get
        {
            return _time;
        }
        set
        {
            if (value > 0)
            {
                _time = value;
            }
            else
                _time = 0;
        }

    }

    public UnityEvent RaundClear;

    private int _currentRaund = 1;

    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _currentRaundText;
    [SerializeField] private TMP_Text _raundStartText;

    private bool _isRaund;
    private void Awake()
    {
        StartCoroutine(RaundStart());
        Time = _Raundtime;
        _currentRaundText.text = $"현재 라운드 : {_currentRaund}";
    }


    public IEnumerator RaundStart()
    {
        _raundStartText.text = "1";
        yield return new WaitForSeconds(1);
        _raundStartText.text = "2";
        yield return new WaitForSeconds(1);
        _raundStartText.text = "3";
        yield return new WaitForSeconds(1);
        _raundStartText.text = ""; 
        Time = _Raundtime;
        _isRaund = true;
    }


    private void Update()
    {
        _timeText.text = $"남은 시간 : {(int)Time}";

        if (_isRaund)
        {
            if (Time <= 0)
            {
                _currentRaund += 1;
                _isRaund = false;
                StartCoroutine(RaundExit());
            }
            else
                Time -= UnityEngine.Time.deltaTime;
        }
    }

    private IEnumerator RaundExit()
    {
        yield return new WaitForSeconds(3);
        _currentRaundText.text = $"현재 라운드 : {_currentRaund}";
        RaundClear?.Invoke();
        StartCoroutine(RaundStart());
    }
}
