using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class RoundManager : MonoBehaviour
{
    public GameTimer timer;    

    public UnityEvent RoundClear;
    public UnityEvent RoundWin;
    public UnityEvent Roundlose;

    public bool isEndRound = false;
    [SerializeField] public bool isRoundWin = false;
    public int round = 1;
    [SerializeField] TMP_Text stageText;

    public void Update()
    {
        if (isEndRound) // ¶ó¿îµå ³¡
        {
            InputReader.Instance.controls.Default.Disable();
            timer.TimerStop();
            if (isRoundWin) // ÀÌ±è ¤»RoundClear != null & 
            {
                RoundClear.Invoke();
                RoundWin.Invoke();
                stageText.text = $"¶ó¿îµå [ {round} ]";
                timer.TimerFlow();
                isEndRound = false;
            }
            else if (!isRoundWin) // Áü ¤Ð¤Ð
            {
                RoundClear.Invoke();
                Roundlose.Invoke();
                Debug.Log("ming");
                isEndRound = false;

            }
        }
    }

    public void EndRound()
    {
        isEndRound = true;
    }

    public void ResetRound()
    {
        round = 0; 
    }
}
