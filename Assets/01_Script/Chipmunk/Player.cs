using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Entity
{
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
}
