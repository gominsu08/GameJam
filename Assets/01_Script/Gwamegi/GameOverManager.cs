using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private TMP_Text text;

    int maxRound;

    public void BossScene()
    {

        StartCoroutine(GotoBoss());
        //이동막는거 넣어야함
    }

    private IEnumerator GotoBoss()
    {
        text.text = "목표 숫자에 도달하지 \n못하였습니다";
        yield return new WaitForSeconds(1);
        text.text = "";
        RoundDataSave();
        SceneManager.LoadScene("GMSBoosScene");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
        RoundDataSave();
        InputReader.Instance.controls.Default.Disable();
    }

    public void Title()
    {
        Time.timeScale = 1;
        DataManager.Instance.round = 0;
        RoundDataSave();
        SceneManager.LoadScene("Title");
    }

    public void ReStart()
    {
        //재시작
        Time.timeScale = 1;
        DataManager.Instance.round = 0;
        InputReader.Instance.controls.Default.Enable();
        RoundDataSave();
        SceneManager.LoadScene("InGameScene");
    }

    public void RoundDataSave()
    {
        SaveManager.Instance.LoadPlayerData();
        maxRound = SaveManager.Instance.playerData.round;

        SaveManager.Instance.playerData.round = DataManager.Instance.round >= maxRound ? DataManager.Instance.round : maxRound;
        SettingManager.Instance.DataSave();

    }
}
