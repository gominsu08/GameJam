using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumDir
{
    Up,
    Down,
    Left,
    Right
}
public class GameManager : MonoSingleton<GameManager>
{
    public EventBus<EnumDir> eventBus = new EventBus<EnumDir>();
    public void HorPlayerMove(Vector2 dir)
    {
        if(dir.x != 0)
        Enemy.enemies.ForEach(enemy => enemy.Move(dir));
    }
    public void VirPlayerMove(Vector2 dir)
    {
        if(dir.y != 0)
        Enemy.enemies.ForEach(enemy => enemy.Move(dir));
    }
}
