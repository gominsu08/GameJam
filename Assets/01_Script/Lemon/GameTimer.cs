using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public float SetTime;
    float CountDown123 = 3f;
    [SerializeField] bool isTimeFlow = true;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text countDownText;
    [SerializeField] private NumCalculate _numCalculate;

    [SerializeField] private RoundManager roundManager;



    private bool isTileMapCreate;
     
    private void Start()
    {        
        StageManager.Instance.TileSetCoroutineStart();
        InputReader.Instance.controls.Default.Disable();
        SetTime = StageManager.Instance.roundTime;
        timerText.text = $"�����ð� [ {Mathf.Round(SetTime)} ]";

    }

    private void Update()
    {
        if (isTimeFlow == true)
        {
            if (Mathf.Round(CountDown123) <= 3  && Mathf.Round(CountDown123) >= 0 &&isTileMapCreate)
            {
                InputReader.Instance.controls.Default.Disable();

                countDownText.text = $"{Mathf.Round(CountDown123)}";
                CountDown123 -= Time.deltaTime;
            }
            else if (Mathf.Round(CountDown123) <= 0 && isTileMapCreate)
            {
                if (SetTime <= 0) return;
                countDownText.text = "";
                InputReader.Instance.controls.Default.Enable();
                timerText.text = $"�����ð� [ {Mathf.Round(SetTime)} ]";
                SetTime -= Time.deltaTime;
            }
        }

        if (SetTime <= 0)
        {
            TimeReset();
            _numCalculate.StageClear();
            isTileMapCreate = false;
        }
    }

    public void TimeSet()
    {
        SetTime = 0.1f;
    }

    public void TileSet()
    {
        isTileMapCreate = true;
    }

    public void TimeReset()
    {
        SetTime = StageManager.Instance.roundTime;
        CountDown123 = 3f;
        isTimeFlow = false;
    }

    public void TimerFlow()
    {
        isTimeFlow = true;
    }

    public void TimerStop()
    {
        isTimeFlow = false;
    }
}
