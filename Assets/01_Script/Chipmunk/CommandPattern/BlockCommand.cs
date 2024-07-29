using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BlockCommand : Command
{
    Transform _transform { get => _entity._visualTrm; }
    Entity _entity;
    float _duration;
    float _power;
    public override void Execute()
    {
        _transform.DOShakePosition(_duration, _power).OnComplete(() => onCompleteAction?.Invoke());
    }

    public override void Redo()
    {
        Execute();
    }

    public override void Undo()
    {
        Execute();
    }
    public BlockCommand(Entity entity, float duration = 1f, float power = 0.2f)
    {
        _entity = entity;
        _duration = duration;
        _power = power;
    }
}
