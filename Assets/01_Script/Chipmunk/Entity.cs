using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float _speed = 1f;
    [SerializeField] protected float _moveSpace = 1f;
    protected CommandInvoker commandInvoker { get => CommandManager.Instance.commandInvoker; }
    [SerializeField] protected UnityEvent<Vector2> OnMoveEvent;
    [field: SerializeField] public Transform _visualTrm { get; protected set; }
    public bool isMoveing { get; protected set; }
    protected virtual void Awake()
    {
        if (_visualTrm == null)
            _visualTrm = transform.Find("Visual");
    }
    protected virtual void OnDestroy()
    {

    }
    private void Update()
    {
    }
    public virtual void Move(Vector2 direction)
    {
        if (isMoveing) return;
        isMoveing = true;
        Debug.Log(direction);
        Vector2 targetPosition = (Vector2)transform.position + direction;
        Command command;
        if (Physics2D.RaycastAll(transform.position, direction, direction.magnitude).ToList().Any((a) => a.transform != transform))
        {
            command = new BlockCommand(this, 1 / _speed);
        }
        else
        {
            OnMoveEvent?.Invoke(direction);
            command = new MoveCommand(this, 1 / _speed, targetPosition);
        }
        command.onCompleteAction += () => isMoveing = false;
        commandInvoker.ExecuteCommand(command);
    }
}
