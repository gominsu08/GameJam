using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity, IPoolable
{
    public static List<Enemy> enemies = new();

    public string poolName;
    public string PoolName => poolName;

    public GameObject ObjectPrefab => gameObject;

    public void Initialize()
    {
        #region 프로토타입 코드
        #endregion
    }
    protected override void Awake()
    {
        base.Awake();
        if (!enemies.Contains(this))
            enemies.Add(this);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (enemies.Contains(this))
            enemies.Remove(this);
    }
    public virtual void MoveVertical() { }

    public void ResetItem()
    {
        gameObject.SetActive(true);
    }
}
