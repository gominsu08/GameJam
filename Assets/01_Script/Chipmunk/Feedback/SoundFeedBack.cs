using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundFeedBack : Feedback
{
    [SerializeField] AudioSource _audioSource;
    private void Awake() {
        if(_audioSource == null)
            _audioSource = GetComponent<AudioSource>();
    }
    public override void PlayFeedback()
    {
        _audioSource.Play();
    }

    public override void StopFeedback()
    {
        _audioSource.Stop();
    }
}
