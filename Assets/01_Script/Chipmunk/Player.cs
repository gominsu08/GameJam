using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Entity
{
    public static bool isPlayerMoving = false;
    InputReader _inputReader { get => InputReader.Instance; }
    public enum EnumPlayerType
    {
        Horizontal, Vertical
    }
    [SerializeField] private EnumPlayerType playerType;
    protected override void Awake()
    {
        base.Awake();
        switch (playerType)
        {
            case EnumPlayerType.Horizontal:
                _inputReader.OnPlayer1Move += Move;
                break;
            case EnumPlayerType.Vertical:
                _inputReader.OnPlayer2Move += Move;
                break;
        }
    }

    private void MoveEnemy()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        // #region 프로토타입 코드
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     Move(Vector3.up);
        // }
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     Move(Vector3.down);
        // }
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     Move(Vector3.left);
        // }
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     Move(Vector3.right);
        // }
        // #endregion
    }
    public override void Move(Vector2 direction)
    {
        if (isPlayerMoving) return;
        isPlayerMoving = true;
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
        command.onCompleteAction += () => isPlayerMoving = false;
        commandInvoker.ExecuteCommand(command);
    }
}
