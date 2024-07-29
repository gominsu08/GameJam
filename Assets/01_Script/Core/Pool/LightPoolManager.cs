using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LightPool
{
    private Stack<IPoolable> _pool;
    private Transform _parentTrm;
    [SerializeField] public IPoolable poolable;
    public GameObject prefab;
    [SerializeField] private int count;
    public LightPool(Transform parent)
    {
        _parentTrm = parent;
    }
    public void Initailize()
    {
        poolable = prefab.GetComponent<IPoolable>();
        _pool = new Stack<IPoolable>(count);

        for (int i = 0; i < count; i++)
        {
            GameObject gameObj = GameObject.Instantiate(prefab, _parentTrm);
            gameObj.SetActive(false);
            gameObj.name = this.poolable.PoolName;
            IPoolable item = gameObj.GetComponent<IPoolable>();
            _pool.Push(item);
        }
    }
    public IPoolable Pop()
    {
        IPoolable item = null;
        if (_pool.Count == 0)
        {
            GameObject gameObj = GameObject.Instantiate(prefab, _parentTrm);
            gameObj.name = poolable.PoolName;
            item = gameObj.GetComponent<IPoolable>();
        }
        else
        {
            item = _pool.Pop();
            item.ObjectPrefab.SetActive(true);
        }
        return item;
    }
    public void Push(IPoolable item)
    {
        item.ObjectPrefab.SetActive(false);
        _pool.Push(item);
    }
}

public class LightPoolManager : MonoSingleton<PoolManager>
{

    [SerializeField] private List<LightPool> _poolableList = new();
    [SerializeField] private Dictionary<string, LightPool> _pools = new();
    protected override void Awake()
    {
        foreach (LightPool pool in _poolableList)
        {
            pool.Initailize();
            _pools.Add(pool.poolable.PoolName, pool);
        }
    }
    public IPoolable Pop(string itemName)
    {
        if (_pools.ContainsKey(itemName))
        {
            IPoolable item = _pools[itemName].Pop();
            item.ResetItem();
            return item;
        }
        Debug.LogError($"There is no pool {itemName}");
        return null;
    }

    public void Push(IPoolable item)
    {
        if (_pools.ContainsKey(item.PoolName))
        {
            _pools[item.PoolName].Push(item);
            return;
        }

        Debug.LogError($"There is no pool {item.PoolName}");
    }
}
