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

    [SerializeField] bool isEndRound = false;
    [SerializeField] bool isRoundWin = false;
    [SerializeField] int round = 0;
    [SerializeField] TMP_Text stageText;

    private void Awake()
    {
        timer = GetComponent<GameTimer>();
    }

    public void Update()
    {
        if (isEndRound)
        {
            if (RoundClear != null & isRoundWin)
            {
                RoundClear.Invoke();
                RoundWin.Invoke();
                round++;
                stageText.text = $"stage [ {round} ]";
                isEndRound = false; 
            }
            else if (RoundClear != null & !isRoundWin) 
            {
                RoundClear.Invoke();
                Roundlose.Invoke();
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
