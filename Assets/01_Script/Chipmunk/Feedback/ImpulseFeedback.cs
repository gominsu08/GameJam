using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class ImpulseFeedback : Feedback
{
    [SerializeField] private Vector2 _impulsePower = Vector2.right;
    Tweener _shakeTween;
    public override void PlayFeedback()
    {
        _shakeTween = Camera.main.transform.DOShakePosition(0.5f, _impulsePower, 10, 90, false, true);
    }

    public override void StopFeedback()
    {
        _shakeTween.Kill();
    }
}
