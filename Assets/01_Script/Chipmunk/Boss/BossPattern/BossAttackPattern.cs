using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossAttackPattern : BossPattern
{
    [SerializeField] protected Attacker _attacker;
    [SerializeField] public int damage = 5;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    public static Dictionary<Vector2Int, BossPattern> patternDictionary = new Dictionary<Vector2Int, BossPattern>();
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
        Vector2Int randomPos;
        randomPos = Vector2Int.RoundToInt(GetRandomPosition());
        int tryCount = 0;
        while (patternDictionary.ContainsKey(randomPos) && tryCount < 99)
        {
            tryCount++;
            randomPos = Vector2Int.RoundToInt(GetRandomPosition());
        }
        transform.position = (Vector2) randomPos;
        patternDictionary.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y), this);
    }
    public virtual void Pattern(Vector2 position)
    {
        transform.position = position;
        Pattern();
    }
    override public void EndPattern()
    {
        base.EndPattern();
        patternDictionary.Remove(new Vector2Int((int)transform.position.x, (int)transform.position.y));
    }
    public void Attack()
    {
        _attacker.Attack(damage);
    }
    public virtual Vector2 GetRandomPosition()
    {
        return new Vector2Int(Random.Range(-4, 5), Random.Range(-4, 5));
    }
}
