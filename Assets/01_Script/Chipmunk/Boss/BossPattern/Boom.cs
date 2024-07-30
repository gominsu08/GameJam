using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Boom : BossAttackPattern
{
    [SerializeField] private float _duration = 1.5f;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] Color _defaultColor;
    protected override void Awake()
    {
        base.Awake();
        if (_defaultColor == null)
            _defaultColor = _spriteRenderer.color;
    }
    public override void Pattern()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(_spriteRenderer.DOColor(_spriteRenderer.color, 0));

        float time = _duration;
        for (int i = 1; i <= 10; i++)
        {
            time = _duration / (i * i);
            _sequence.Append(_spriteRenderer.DOColor(Color.red, 0.05f));
            _sequence.Join(transform.DOShakePosition(0.5f, new Vector2(0.01f, 0.01f) * i));
            _sequence.Append(_spriteRenderer.DOColor(_defaultColor, 0.05f));
            _sequence.AppendInterval(time);
        }
        base.Pattern();
    }
    public override void EndPattern()
    {
        base.EndPattern();
        Attack();
        _particle.Play();
    }
}
