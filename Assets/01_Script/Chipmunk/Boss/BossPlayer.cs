using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPlayer : Entity
{
    protected override void Awake()
    {
        base.Awake();
        InputReader.Instance.OnBossPlayerMove += Move;
        // OnMoveEvent.AddListener(a =>
        // {
        //     command.onCompleteAction += () =>
        //     {

        //         if (moveQueue.Count == 0) return;
        //         Vector2 moveDir = moveQueue.Dequeue();
        //         Debug.Log(moveQueue.Count);
        //         Debug.Log(moveDir);
        //         Debug.Log(isMoveing);
        //         Move(moveDir);
        //     };
        // });
    }
    public override void Move(Vector2 direction)
    {
        if (isMoveing) moveQueue.Enqueue(direction);
        base.Move(direction);
        // isMoveing = false;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _visualTrm.DORotate(new Vector3(0, 0, angle), 1 / _speed);
        // transform.DORotate(new Vector3(0, 0, transform.rotation.eulerAngles.z + 90), 1 / _speed);
    }
    Queue<Vector2> moveQueue = new Queue<Vector2>();


    private void OnDisable()
    {
        InputReader.Instance.OnBossPlayerMove -= Move;
    }

    // IEnumerator goodControl(Vector2 direction)
    // {
    //     float startTime = Time.time;
    //     while (isMoveing && startTime + 10 > Time.time)
    //     {
    //         yield return null;
    //         base.Move(direction);
    //     }
    // }
}
