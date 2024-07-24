using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public void Initialize()
    {
        #region 프로토타입 코드
        Player player = GameObject.FindAnyObjectByType<Player>();
        player.eventBus.AddListener(Player.EnumPlayerEventBus.MoveHorizontal, () =>
        {
            Debug.Log("적이 수평으로 움직임");
        });
        #endregion
    }
    private void Awake()
    {

    }
    public virtual void MoveHorizontal() {
        Command moveCommand = new MoveCommand(transform, 1f, transform.position + Vector3.left);
        commandInvoker.ExecuteCommand(new MoveCommand(transform, 1f, transform.position + Vector3.left));
    }
    public virtual void MoveVertical() { }
}
