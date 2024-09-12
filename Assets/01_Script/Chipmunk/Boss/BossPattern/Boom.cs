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

        int flashCount = Mathf.Max(1, Mathf.FloorToInt(_duration));
        float initialtime = _duration / flashCount;

        for (int i = 1; i <= flashCount; i++)
        {
            float time = (float) initialtime / i;
            _sequence.Append(_spriteRenderer.DOColor(Color.red, time / 3));
            _sequence.Join(transform.DOShakePosition(time / 3, new Vector2(0.01f, 0.01f) * i));
            _sequence.Append(_spriteRenderer.DOColor(_defaultColor, time / 3));
            _sequence.AppendInterval(time);
        }
        _sequence.OnComplete(() => _spriteRenderer.enabled = false);
        base.Pattern();
    }
    private IEnumerator WaitForParticle()
    {
        _particle.Play();
        yield return new WaitWhile(() => _particle.isPlaying);
        base.EndPattern();
    }
    public override void EndPattern()
    {
        Attack();
        StartCoroutine(WaitForParticle());
    }
}
