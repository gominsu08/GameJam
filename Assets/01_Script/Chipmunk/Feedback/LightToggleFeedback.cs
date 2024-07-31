using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightToggleFeedback : Feedback
{
    [SerializeField] private float _blinkTime = 0.05f;
    [SerializeField] private Light2D _tagerLight;
    private WaitForSeconds _ws;
    private void Awake() {
        _ws = new WaitForSeconds(_blinkTime);
    }

    public override void PlayFeedback()
    {
        StartCoroutine(ToggleCoroutine());
    }

    private IEnumerator ToggleCoroutine()
    {
        _tagerLight.enabled = true;
        yield return _ws;
        _tagerLight.enabled = false;

    }

    public override void StopFeedback()
    {
        StopAllCoroutines();
    }
}
