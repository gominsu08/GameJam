using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

enum EnumCommandState
{
    waiting,
    Executing,

}
public class MoveCommand : Command
{
    Transform _transform;
    float _duration;
    Vector3 _targetPosition;
    Vector3 _beforePosition;
    public Action onMoveCompleteAction;
    /// <summary>
    /// NotifyValue
    /// </summary>
    NotifyValue<EnumCommandState> commandState = new NotifyValue<EnumCommandState>();
    LayerMask layerMask { get => LayerMask.GetMask("Entity"); }
    public override void Execute()
    {
        commandState.Value = EnumCommandState.Executing;
        _beforePosition = _transform.position;

        Vector2 moveDir = _targetPosition - _transform.position;

        if (Physics2D.RaycastAll(_transform.position, _targetPosition - _transform.position, moveDir.magnitude).ToList().Any((a) => a.transform != _transform))
            _transform.DOShakePosition(0.5f, 0.2f).OnComplete(() => onMoveCompleteAction?.Invoke());
        else
            _transform.DOMove(_targetPosition, _duration).OnComplete(() => onMoveCompleteAction?.Invoke());
        // _transform.DOMove(_targetPosition, _duration).OnComplete(() => commandState.Value = EnumCommandState.waiting);
    }

    public override void Redo()
    {
        Execute();
    }

    public override void Undo()
    {
        _transform.position = _beforePosition;
    }
    public MoveCommand(Transform transform, float duration = 1f, Vector2 targetPosition = default)
    {
        _transform = transform;
        _duration = duration;
        _targetPosition = targetPosition;
    }
}
