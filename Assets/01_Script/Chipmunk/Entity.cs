using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float _moveSpace = 1f;
    CommandInvoker commandInvoker { get => CommandManager.Instance.commandInvoker; }
    public bool isMoveing { get; protected set; }
    protected virtual void Awake()
    {

    }
    private void Update()
    {
    }
    public virtual void Move(Vector2 direction)
    {
        if (isMoveing) return;
        isMoveing = true;
        MoveCommand command = new MoveCommand(transform, 1 / _speed, (Vector2)transform.position + direction);
        command.onMoveCompleteAction += () => isMoveing = false;
        commandInvoker.ExecuteCommand(command);
    }
}
