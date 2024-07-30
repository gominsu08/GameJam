using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    protected override void Awake()
    {
        var obj = FindObjectsOfType<DataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int round;
    private int hp = 40;
    public int time;
    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            if (value + 40 < 0)
                hp = 1;
            else
                hp = value + 60;

        }
    }
}
