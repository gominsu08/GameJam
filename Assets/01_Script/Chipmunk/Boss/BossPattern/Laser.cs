using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Laser : BossAttackPattern
{
    [SerializeField] private float _duration = 1.5f;
    protected override void Awake()
    {
        base.Awake();
    }
    public override void Pattern()
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(_spriteRenderer.DOFade(0, 0));
        _sequence.Join(transform.DOScale(new Vector3(0.2f, transform.localScale.y, 1), 0));

        _sequence.Append(_spriteRenderer.DOFade(0.2f, _duration));

        //레이저 공격부분
        _sequence.Append(_spriteRenderer.DOFade(1, 0.3f));
        _sequence.Join(transform.DOScale(new Vector3(0.6f, transform.localScale.y, 1), _duration));
        _sequence.Join(DOVirtual.DelayedCall(0.05f, Attack).SetLoops((int)(_duration / 0.05f), LoopType.Restart));

        _sequence.Append(_spriteRenderer.DOFade(0, 0.1f));
        base.Pattern();
    }
    public override Vector2 GetRandomPosition()
    {
        Vector2 randomPos = base.GetRandomPosition();
        if (Random.Range(0, 2) == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            randomPos.x = 0;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            randomPos.y = 0;
        }
        return randomPos;
    }
}
