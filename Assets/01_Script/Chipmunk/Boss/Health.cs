using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int maxhp = 100;
    [SerializeField]
    private int hp = 100;
    public int HP
    {
        get { return hp; }
        set
        {
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
