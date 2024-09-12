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
        SceneManager.LoadScene("GMSBoosScene");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
        InputReader.Instance.controls.Default.Disable();
    }

    public void Title()
    {
        Time.timeScale = 1;
        DataManager.Instance.round = 0;
        SettingManager.Instance.DataSave();
        SceneManager.LoadScene("Title");
    }

    public void ReStart()
    {
        //재시작
        Time.timeScale = 1;
        DataManager.Instance.round = 0;
        InputReader.Instance.controls.Default.Enable();
        SettingManager.Instance.DataSave();
        SceneManager.LoadScene("InGameScene");
    }
}
