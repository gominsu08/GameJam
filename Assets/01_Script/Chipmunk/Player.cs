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
    public enum EnumPlayerEventBus
    {
        MoveHorizontal, MoveVertical
    }
    [SerializeField] private EnumPlayerType playerType;
    public EventBus<EnumPlayerEventBus> eventBus = new EventBus<EnumPlayerEventBus>();
    private void Update()
    {
        #region 프로토타입 코드
        if (Input.GetKeyDown(KeyCode.W))
        {
            eventBus.Publish(EnumPlayerEventBus.MoveVertical);
            commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.up));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            eventBus.Publish(EnumPlayerEventBus.MoveVertical);
            commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.down));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            eventBus.Publish(EnumPlayerEventBus.MoveHorizontal);
            commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.left));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            eventBus.Publish(EnumPlayerEventBus.MoveHorizontal);
            commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.right));
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            commandInvoker.UndoCommand();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            commandInvoker.RedoCommand();
        }
        #endregion
    }
}
