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
    Transform _transform { get => _entity._visualTrm; }
    Entity _entity;
    float _duration;
    Vector3 _targetPosition;
    Vector3 _beforePosition;
    /// <summary>
    /// NotifyValue
    /// </summary>
    NotifyValue<EnumCommandState> commandState = new NotifyValue<EnumCommandState>();
    public override void Execute()
    {
        commandState.Value = EnumCommandState.Executing;

        _beforePosition = _transform.position;
        _entity.transform.position = _targetPosition;
        _transform.position = _beforePosition;


        _transform.DOMove(_targetPosition, _duration).OnComplete(() => onCompleteAction?.Invoke());
        // _transform.DOMove(_targetPosition, _duration).OnComplete(() => commandState.Value = EnumCommandState.waiting);
    }

    public override void Redo()
    {
        Execute();
    }

    public override void Undo()
    {
        _entity.transform.position = _beforePosition;
        _transform.position = _beforePosition;
    }
    public MoveCommand(Entity entity, float duration = 1f, Vector2 targetPosition = default)
    {
        _entity = entity;
        _duration = duration;
        _targetPosition = targetPosition;
    }
}
