using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public enum BrightValue
{
    VeryLow, Low, High, VeryHigh
}

public class SettingManager : MonoBehaviour
{
    [SerializeField] private GameObject _window, _creditWindow;
    [SerializeField] private Image _effectOn, _effectOff, _veryLow, _low, _high, _veryHigh;
    [SerializeField] private Sprite _btnOn, _btnOff;
    [SerializeField] private Scrollbar _musicBar, _sfxBar;
    [SerializeField] private AudioSource _music;
    [SerializeField] private BrightValue _brightValue = BrightValue.High;
    [SerializeField] private Volume _volume;
    [SerializeField] private Bloom _bloom;
    [SerializeField] private float _musicVolume = 50, _sfxVolume = 50;
    public bool effect = true;

    private void Start()
    {
        _volume.profile.TryGet<Bloom>(out _bloom);
        SettingReset();
        _window?.SetActive(false);
        _creditWindow?.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&_window.active)
        {
            Time.timeScale = 1.0f;
            Close();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
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
    }

    public void Close()
    {
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

    public void BrightChanged(string value)
    {
        BrightReset();
        _brightValue = (BrightValue)Enum.Parse(typeof(BrightValue), value);
        VolumeChange(_brightValue);
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

        if (effect)
        {
            _effectOn.sprite = _btnOn;
            _effectOff.sprite = _btnOff;
        }
        else
        {
            _effectOn.sprite = _btnOff;
            _effectOff.sprite = _btnOn;
        }

        BrightReset();
        BrightChanged(_brightValue.ToString());
    }
}
