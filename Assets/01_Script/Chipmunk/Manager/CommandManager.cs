using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoSingleton<CommandManager>
{
    public CommandInvoker commandInvoker = new CommandInvoker();
    private void Update()
    {
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
