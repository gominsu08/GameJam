using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoSingleton<SFXPlayer>
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickSound, _closeSound, _enterSound, _playerMoveSound, _enemyDestorySound;
    private void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();

        // ��Ʈ: true�� ��� �Ҹ��� ���� ����
        _audioSource.mute = false;

        // ����: true�� ��� �ݺ� ���
        _audioSource.loop = false;

        // �ڵ� ���: true�� ��� �ڵ� ���
        _audioSource.playOnAwake = false;
    }

    public void PlaySFX(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void ChangeVolume(float volume)
    {
        _audioSource.volume = volume / 100;
    }

    public void PlayClick()
    {
        PlaySFX(_clickSound);
    }
    public void PlayClose()
    {
        PlaySFX(_closeSound);
    }
    public void PlayEnter()
    {
        PlaySFX(_enterSound);
    }
    public void PlayMove()
    {
        PlaySFX(_playerMoveSound);
    }
    public void PlayDestroy()
    {
        PlaySFX(_enemyDestorySound);
    }
}
