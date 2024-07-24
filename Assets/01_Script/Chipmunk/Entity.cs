using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected CommandInvoker commandInvoker = new CommandInvoker();
    private void Update()
    {
    }
    public virtual void Move(Vector3 direction)
    {
        commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + direction));
    }
}
