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

    [SerializeField] private bool _isEndRound = false;
    [SerializeField] public bool isRoundWin = false;
    [SerializeField] private int _round = 0;
    [SerializeField] TMP_Text stageText;

    public void Update()
    {
        if (_isEndRound) // ¶ó¿îµå ³¡
        {
            timer.TimerStop();
            if (isRoundWin) // ÀÌ±è ¤»RoundClear != null & 
            {
                RoundClear.Invoke();
                RoundWin.Invoke();
                _round++;
                stageText.text = $"stage [ {_round} ]";
                timer.TimerFlow();
                _isEndRound = false;
            }
            else if (!isRoundWin) // Áü ¤Ð¤Ð
            {
                RoundClear.Invoke();
                Roundlose.Invoke();
                Debug.Log("ming");
                _isEndRound = false;

            }
        }
    }

    public void EndRound()
    {
        _isEndRound = true;
    }

    public void ResetRound()
    {
        _round = 0; 
    }
}
