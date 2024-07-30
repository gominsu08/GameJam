using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoSingleton<SFXPlayer>
{
    private AudioSource _audioSource;
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
}
