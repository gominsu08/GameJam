using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    public void BossScene()
    {
        SceneManager.LoadScene("GMSBoosScene");
        //이동막는거 넣어야함
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
