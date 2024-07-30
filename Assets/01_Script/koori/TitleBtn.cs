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
        SaveManager.Instance.SavePlayerDataToJson();
       
        SceneManager.LoadScene("InGameScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
