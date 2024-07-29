using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    private Player _player;
    [SerializeField] private Transform _player1, _player2;

    private void Update()
    {
        Debug.Log(IsPlayerInLine(_player1.position, _player2.position)) ;
        if (IsPlayerInLine(_player1.position, _player2.position))
        {
            List<RaycastHit2D> hit = Physics2D.RaycastAll(_player1.position, _player2.position).ToList();
        }
    }

    private bool IsPlayerInLine(Vector2 player1Pos, Vector2 player2Pos)
    {
        // x 좌표가 같은 경우 (세로 방향 일직선)
        if (player1Pos.x == player2Pos.x)
        {
            return true;
        }
        // y 좌표가 같은 경우 (가로 방향 일직선)
        else if (player1Pos.y == player2Pos.y)
        {
            return true;
        }
        // 그 외의 경우　仕事したくない．．．
        else
        {
            return false;
        }
    }
}
