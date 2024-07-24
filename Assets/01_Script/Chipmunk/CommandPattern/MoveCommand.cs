using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveCommand : Command
{
    Transform _transform;
    float _duration;
    Vector3 _targetPosition;
    Vector3 _beforePosition;
    public override void Execute()
    {
        _beforePosition = _transform.position;
        _transform.DOMove(_targetPosition, _duration);
    }

    public override void Redo()
    {
        Execute();
    }

    public override void Undo()
    {
        _transform.position = _beforePosition;
    }
    public MoveCommand(Transform transform, float duration = 1f, Vector3 targetPosition = default)
    {
        _transform = transform;
        _duration = duration;
        _targetPosition = targetPosition;
    }
}
