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
        if (_visualTrm == null)
            _visualTrm = transform.Find("Visual");
        if (!enemies.Contains(this))
            enemies.Add(this);
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
        if (_visualTrm == null)
            _visualTrm = transform.Find("Visual");
        if (!Grid.Instance.set(this, transform.position))
            Debug.Log($"entity : {transform.position}!!!");
        else
            Debug.Log("entity : {transform.position} 성공");
        if (!enemies.Contains(this))
            enemies.Add(this);
    }

    public void Effect()
    {
        gameObject.SetActive(true);
        Instantiate(_particleSystem, transform.position, Quaternion.identity);
        PoolManager.Instance.Push(this);
    }
}
