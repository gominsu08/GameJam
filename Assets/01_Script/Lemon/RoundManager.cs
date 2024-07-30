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
    public int round = 1;
    [SerializeField] TMP_Text stageText;

    public void Update()
    {
        if (_isEndRound) // ���� ��
        {
            timer.TimerStop();
            if (isRoundWin) // �̱� ��RoundClear != null & 
            {
                RoundClear.Invoke();
                RoundWin.Invoke();
                stageText.text = $"���� [ {round} ]";
                timer.TimerFlow();
                _isEndRound = false;
            }
            else if (!isRoundWin) // �� �Ф�
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
        round = 0; 
    }
}
