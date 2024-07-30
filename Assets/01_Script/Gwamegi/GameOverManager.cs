using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    public void GameOver()
    {
        //�̵����°� �־����
        _gameOverPanel.SetActive(true);
        InputReader.Instance.controls.Default.Disable();
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void ReStart()
    {
        //�����
        InputReader.Instance.controls.Default.Enable();
        SceneManager.LoadScene("InGameScene");
    }
}
