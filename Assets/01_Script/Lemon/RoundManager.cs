using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] TMP_Text stageText;

    private int maxRound;

    private void Awake()
    {
        DataManager.Instance.round = 1;
    }

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
                stageText.text = $"¶ó¿îµå [ {DataManager.Instance.round} ]";
                timer.TimerFlow();
                isEndRound = false;
            }
            else if (!isRoundWin) // Áü ¤Ð¤Ð
            {
                RoundClear.Invoke();
                Roundlose.Invoke();
                Debug.Log("ming");
                RoundDataSave();
                isEndRound = false;

            }
        }
    }

    public void RoundDataSave()
    {
        SaveManager.Instance.LoadPlayerData();
        maxRound = SaveManager.Instance.playerData.round;

        SaveManager.Instance.playerData.round = DataManager.Instance.round >= maxRound ? DataManager.Instance.round : maxRound;
        SettingManager.Instance.DataSave();

    }

    public void EndRound()
    {
        isEndRound = true;
    }

    public void ResetRound()
    {
        DataManager.Instance.round = 1; 
    }
}
