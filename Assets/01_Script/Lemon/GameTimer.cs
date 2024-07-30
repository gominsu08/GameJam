using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float SetTime = 60.0f;
    [SerializeField] float CountDown123 = 0.0f;
    [SerializeField] bool isTimeFlow = true;
    [SerializeField] TMP_Text timerText;
    [SerializeField] private NumCalculate _numCalculate;

    [SerializeField] private RoundManager roundManager;



    private bool isTileMapCreate;
     
    private void Start()
    {        
        timerText.text = $"Time [ {Mathf.Round(CountDown123)} ]";
        StageManager.Instance.TileSetCoroutineStart();

    }

    private void Update()
    {
        if (isTimeFlow == true)
        {
            if (Mathf.Round(CountDown123) <= 3 && isTileMapCreate)
            {
                InputReader.Instance.controls.Default.Disable();

                timerText.text = $"Time [ {Mathf.Round(CountDown123)} ]";
                CountDown123 += Time.deltaTime;
            }
            else if (Mathf.Round(CountDown123) > 3 && isTileMapCreate)
            {
                if (SetTime <= 0) return;
                InputReader.Instance.controls.Default.Enable();
                timerText.text = $"Time [ {Mathf.Round(SetTime)} ]";
                SetTime -= Time.deltaTime;
                
            }
        }

        if (SetTime <= 0 )
        {
            TimeReset();
            _numCalculate.StageClear();
            isTileMapCreate = false;
        }
    }

    public void TileSet()
    {
        isTileMapCreate = true;
    }

    public void TimeReset()
    {
        SetTime = 60;
        CountDown123 = 0.0f;
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
