using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public float SetTime;
    [SerializeField] float CountDown123 = 0.0f;
    [SerializeField] bool isTimeFlow = true;
    [SerializeField] TMP_Text timerText;
    [SerializeField] private NumCalculate _numCalculate;

    [SerializeField] private RoundManager roundManager;



    private bool isTileMapCreate;
     
    private void Start()
    {        
        timerText.text = $"남은시간 [ {Mathf.Round(CountDown123)} ]";
        StageManager.Instance.TileSetCoroutineStart();
        SetTime = StageManager.Instance.roundTime;

    }

    private void Update()
    {
        if (isTimeFlow == true)
        {
            if (Mathf.Round(CountDown123) <= 3 && isTileMapCreate)
            {
                InputReader.Instance.controls.Default.Disable();

                timerText.text = $"남은시간 [ {Mathf.Round(CountDown123)} ]";
                CountDown123 += Time.deltaTime;
            }
            else if (Mathf.Round(CountDown123) > 3 && isTileMapCreate)
            {
                if (SetTime <= 0) return;
                InputReader.Instance.controls.Default.Enable();
                timerText.text = $"남은시간 [ {Mathf.Round(SetTime)} ]";
                SetTime -= Time.deltaTime;
                
            }
        }

        if (SetTime <= 0 )
        {
            TimeReset();
            
            isTileMapCreate = false;
        }
    }

    public void TileSet()
    {
        isTileMapCreate = true;
    }

    public void TimeReset()
    {
        SetTime = StageManager.Instance.roundTime;
        CountDown123 = 0.0f;
        isTimeFlow = false;
        _numCalculate.StageClear();
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
