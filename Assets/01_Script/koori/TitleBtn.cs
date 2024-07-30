using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBtn : MonoBehaviour
{

    public void GameStart()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
