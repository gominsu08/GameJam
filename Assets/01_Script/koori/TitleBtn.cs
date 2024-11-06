using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleBtn : MonoBehaviour
{
    [SerializeField] private SettingManager _settingManager;
    [SerializeField] private TMP_Text _bestScore;

    private void Awake()
    {
        _bestScore.gameObject.SetActive(false);
    }
    private void Start()
    {
        if (SaveManager.Instance.playerData.round != 0)
        {
            _bestScore.gameObject.SetActive(true);
            _bestScore.text = $"최고 기록: {SaveManager.Instance.playerData.round}";
        }
    }
    public void GameStart()
    {
        SFXPlayer.Instance.PlayClick();
        _settingManager.DataSave();
       
        SceneManager.LoadScene("InGameScene");
    }

    public void GameExit()
    {
        SFXPlayer.Instance.PlayClick();
        Application.Quit();
    }
}
