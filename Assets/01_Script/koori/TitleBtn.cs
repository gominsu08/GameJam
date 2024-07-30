using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBtn : MonoBehaviour
{
    [SerializeField] private SettingManager _settingManager;
    public void GameStart()
    {
        _settingManager.DataSave();
       
        SceneManager.LoadScene("InGameScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
