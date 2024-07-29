using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float SetTime = 60.0f;
    [SerializeField] float CountDown123 = 0.0f;
    [SerializeField] TextMeshProUGUI timerText;

    private void Start()
    {        
        timerText.text = $"Time [ {Mathf.Round(CountDown123)} ]";
    }

    private void Update()
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
