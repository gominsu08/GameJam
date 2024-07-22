using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private CommandInvoker commandInvoker = new CommandInvoker();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.up));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.down));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.left));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.right));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            commandInvoker.UndoCommand();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            commandInvoker.RedoCommand();
        }
    }
}
