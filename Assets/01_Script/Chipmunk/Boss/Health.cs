using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int maxhp = 100;
    [SerializeField]
    private int hp;
    public int HP
    {
        get { return hp; }
        set
        {
            if (hp > value)
                onHitEvent?.Invoke();
            hp = value;
            if (hp <= 0)
            {
                hp = 0;
                Die();
            }
            else if (hp > maxhp)
            {
                hp = maxhp;
            }
        }
    }
    [SerializeField] UnityEvent onHitEvent;
    public void Initialize()
    {
        hp = maxhp;
    }
    private void Awake()
    {
        Initialize();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
