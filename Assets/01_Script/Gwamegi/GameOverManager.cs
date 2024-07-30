using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    public void GameOver()
    {
        SceneManager.LoadScene("GMSBossScene");

        //�̵����°� �־����
        //_gameOverPanel.SetActive(true);
        //InputReader.Instance.controls.Default.Disable();

    }

    public void Title()
    {
        SettingManager.Instance.DataSave();
        SceneManager.LoadScene("Title");
    }

    public void ReStart()
    {
        //�����
        InputReader.Instance.controls.Default.Enable();
        SettingManager.Instance.DataSave();
        SceneManager.LoadScene("InGameScene");
    }
}
