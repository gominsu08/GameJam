using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public int round = 1;
    private int hp;
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
                hp = value + 40;

        }
    }
}
