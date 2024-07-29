using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private Stack<Command> _undoStack = new Stack<Command>();
    private Stack<Command> _redoStack = new Stack<Command>();

    public void ExecuteCommand(Command command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }
    public void UndoCommand()
    {
        if (_undoStack.Count > 0)
        {
            Command undoCommand = _undoStack.Pop();
            _redoStack.Push(undoCommand);
            undoCommand.Undo();
        }
    }
    public void RedoCommand()
    {
        if (_redoStack.Count > 0)
        {
            Command redoCommand = _redoStack.Pop();
            _undoStack.Push(redoCommand);
            redoCommand.Redo();
        }
    }
}
