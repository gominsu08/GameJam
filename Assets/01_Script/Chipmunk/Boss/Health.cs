using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnDieEvent;

    [SerializeField]
    public int maxhp = 100;
    [SerializeField][Tooltip("무적기능")] bool invincibility = false;
    [SerializeField]
    private int hp;
    public int HP
    {
        get { return hp; }
        set
        {
            if (hp > value) { }
            onHitEvent?.Invoke();
            if (!invincibility)
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
        OnDieEvent?.Invoke();
        gameObject.SetActive(false); 
    }
}
