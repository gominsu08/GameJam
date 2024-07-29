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
}
