using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Entity
{
    
    public enum EnumPlayerType
    {
        Horizontal, Vertical
    }
    [SerializeField] private EnumPlayerType playerType;
    private void Update()
    {
        #region 프로토타입 코드
        if (Input.GetKeyDown(KeyCode.W))
        {
            CommandManager.Instance.commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.up));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CommandManager.Instance.commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.down));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CommandManager.Instance.commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.left));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CommandManager.Instance.commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.right));
        }
        #endregion
    }
}
