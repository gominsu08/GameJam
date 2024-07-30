using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity, IPoolable
{
    public static List<Enemy> enemies = new();

    public string poolName;
    public string PoolName => poolName;

    public GameObject ObjectPrefab => gameObject;

    [SerializeField] private ParticleSystem _particleSystem;


    public void Initialize()
    {
        #region 프로토타입 코드
        #endregion
    }
    protected override void Awake()
    {
        base.Awake();
        
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if (enemies.Contains(this))
            enemies.Remove(this);
    }
    public virtual void MoveVertical() { }

    public void ResetItem()
    {
        gameObject.SetActive(true);
        if (!enemies.Contains(this))
            enemies.Add(this);
    }

    public void Effect()
    {
        Instantiate(_particleSystem, transform.position, Quaternion.identity);
    }
}
