using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossAttackPattern : BossPattern
{
    [SerializeField] protected Attacker _attacker;
    [SerializeField] public int damage = 5;
    [SerializeField] protected SpriteRenderer _spriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (_attacker == null)
        {
            _attacker = transform.GetComponent<Attacker>();
        }
    }
    public override void Pattern()
    {
        base.Pattern();
        transform.position = GetRandomPosition();
    }
    public virtual void Pattern(Vector2 position)
    {
        transform.position = position;
        Pattern();
    }
    public void Attack()
    {
        _attacker.Attack(damage);
    }
    public virtual Vector2 GetRandomPosition()
    {
        return new Vector2Int(Random.Range(-3, 4), Random.Range(-3, 4));
    }
}
