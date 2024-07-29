using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float SetTime = 60.0f;
    [SerializeField] float CountDown123 = 0.0f;
    [SerializeField] bool isTimeFlow = true;
    [SerializeField] TMP_Text timerText;

    private void Start()
    {        
        timerText.text = $"Time [ {Mathf.Round(CountDown123)} ]";
    }

    private void Update()
    {
        if (isTimeFlow == true)
        {
            if (Mathf.Round(CountDown123) <= 3)
            {
                timerText.text = $"Time [ {Mathf.Round(CountDown123)} ]";
                CountDown123 += Time.deltaTime;
            }
            else if (Mathf.Round(CountDown123) > 3)
            {
                timerText.text = $"Time [ {Mathf.Round(SetTime)} ]";
                SetTime -= Time.deltaTime;

            }
        }   
    }

    public void TimeReset()
    {
        SetTime = 60.0f;
        CountDown123 = 0.0f;
        isTimeFlow = false;
    }

    public void TimerFlow()
    {
        isTimeFlow = true;
    }
}
