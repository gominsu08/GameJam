using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightEffectFeedback : Feedback
{
    [SerializeField] GameObject _effectPrefab;
    public override void PlayFeedback()
    {
        Debug.Log("밍글링");
        ParticleSystem particleSystem;
        if (_effectPrefab.scene.rootCount == 0)
        {
            GameObject effect = LightPoolManager.Instance.Pop(_effectPrefab);
            effect.transform.position = transform.position;
            particleSystem = effect.GetComponent<ParticleSystem>();
            Debug.Log("밍");
        }
        else
        {
            _effectPrefab.transform.position = transform.position;
            particleSystem = _effectPrefab.GetComponent<ParticleSystem>();
        }
        if (particleSystem != null)
            particleSystem.Play();
        else
            Debug.LogError("LightEffectFeedback : ParticleSystem is null");
    }

    public override void StopFeedback()
    {
    }
}
