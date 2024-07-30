using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BrightValue
{
    VeryLow, Low, High, VeryHigh
}

public class SettingManager : MonoBehaviour
{
    [SerializeField] private GameObject _window, _creditWindow, _goTiltleBtn;
    [SerializeField] private Image _effectOn, _effectOff, _veryLow, _low, _high, _veryHigh;
    [SerializeField] private Sprite _btnOn, _btnOff;
    [SerializeField] private Scrollbar _musicBar, _sfxBar;
    [SerializeField] private AudioSource _music;
    [SerializeField] private BrightValue _brightValue;
    [SerializeField] private Volume _volume;
    [SerializeField] private Bloom _bloom;
    [SerializeField] private float _musicVolume, _sfxVolume;
    [SerializeField] private bool _isTitle;
    public bool effect;

    private void Start()
    {
        SaveManager.Instance.LoadPlayerData();
        _musicVolume = SaveManager.Instance.playerData.musicVolume;
        _sfxVolume = SaveManager.Instance.playerData.sfxVolume;
        effect = SaveManager.Instance.playerData.effectOn;
        _brightValue = SaveManager.Instance.playerData.bright;
        _volume.profile.TryGet<Bloom>(out _bloom);
        SettingReset();
        _window?.SetActive(false);
        _creditWindow?.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&_window.active)
        {
            Close();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Open();
        }

    }

    public void OpenCredit()
    {
        _creditWindow?.SetActive(true);
    }

    public void CloseCredit()
    {
        _creditWindow.SetActive(false);
    }

    public void Open()
    {
        _window?.SetActive(true);
        if (_isTitle)
        {
            _goTiltleBtn.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void Close()
    {
        if (!_isTitle)
        {
            Time.timeScale = 1.0f;
        }
        _window?.SetActive(false);
    }

    public void EffectOn()
    {
        if (!effect)
        {
            _effectOn.sprite = _btnOn;
            _effectOff.sprite = _btnOff;
            effect = true;
            VolumeChange(_brightValue);
        }
    }
    public void EffectOff()
    {
        if (effect)
        {
            _effectOff.sprite = _btnOn;
            _effectOn.sprite = _btnOff;
            effect = false;
            _bloom.intensity.value = 0;
        }
    }

    public void MusicVolumeChanged()
    {
        _musicVolume = _musicBar.value * 100;
        _music.volume = _musicBar.value;
    }

    public void SFXVolumeChanged()
    {
        _sfxVolume = _sfxBar.value * 100;
    }

    public void GoToTitle()
    {
        Time.timeScale = 1.0f;
        SaveManager.Instance.SavePlayerDataToJson();
        SceneManager.LoadScene("Title");
    }

    public void BrightChanged(string value)
    {
        BrightReset();
        _brightValue = (BrightValue)Enum.Parse(typeof(BrightValue), value);
        if (effect)
        {
            VolumeChange(_brightValue);
        }
        switch (_brightValue)
        {
            case BrightValue.VeryLow:
                _veryLow.sprite = _btnOn;  break;
            case BrightValue.Low:
                _low.sprite = _btnOn; break;
            case BrightValue.High:
                _high.sprite = _btnOn; break;
            case BrightValue.VeryHigh:
                _veryHigh.sprite = _btnOn; break;
        }
    }

    private void VolumeChange(BrightValue value)
    {
        switch (value)
        {
            case BrightValue.VeryLow :
                _bloom.intensity.value = 1; break;
            case BrightValue.Low :
                _bloom.intensity.value = 2; break;
            case BrightValue.High :
                _bloom.intensity.value = 3; break;
            case BrightValue.VeryHigh :
                _bloom.intensity.value = 4; break;
        }
    }

    private void BrightReset()
    {
        _veryLow.sprite = _btnOff;
        _low.sprite = _btnOff;
        _high.sprite = _btnOff;
        _veryHigh.sprite = _btnOff;
    }

    private void SettingReset()
    {
        _musicBar.value = _musicVolume / 100;
        _sfxBar.value = _sfxVolume / 100;
        MusicVolumeChanged();
        SFXVolumeChanged();

        if (effect)
        {
            _effectOn.sprite = _btnOn;
            _effectOff.sprite = _btnOff;
            effect = true;
            VolumeChange(_brightValue);
        }
        else
        {
            _effectOff.sprite = _btnOn;
            _effectOn.sprite = _btnOff;
            effect = false;
            _bloom.intensity.value = 0;
        }

        BrightReset();
        BrightChanged(_brightValue.ToString());
    }
}
