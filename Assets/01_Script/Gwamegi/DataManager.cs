using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public int round;
    private int hp = 40;

    private int time;
    public int bossTime
    {
        get 
        { 
            return time; 
        }
        set 
        {
            if(value >= 35)
            {
                time = 35;
            }
            else
            {
                time = value;
            }
        }
    }
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
