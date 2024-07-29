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
                timerText.text = $"Time [ {Mathf.Round(CountDown123)} ]";
                CountDown123 += Time.deltaTime;
            }
            else if (Mathf.Round(CountDown123) > 3 && isTileMapCreate)
            {
                if (SetTime <= 0) return;
                timerText.text = $"Time [ {Mathf.Round(SetTime)} ]";
                SetTime -= Time.deltaTime;

            }
        }

        if (SetTime <= 0 )
        {
            roundManager.EndRound();
            TimeReset();
            StageManager.Instance.TileSetCoroutineStart();
            isTileMapCreate = false;
        }
    }

    public void TileSet()
    {
        isTileMapCreate = true;
    }

    public void TimeReset()
    {
        SetTime = 5;
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
