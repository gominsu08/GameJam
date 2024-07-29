using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public Action onCompleteAction;
    public abstract void Execute();
    public abstract void Undo();
    public abstract void Redo();
}
