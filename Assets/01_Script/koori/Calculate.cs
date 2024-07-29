using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    [SerializeField] private List<Collider2D> _hit = new List<Collider2D>();
    [SerializeField] private Transform _player1, _player2;
    private Vector2 Dir { get => -(_player1.position - _player2.position); }

    private void Update()
    {
        Debug.Log(IsPlayerInLine(_player1.position, _player2.position)) ;
        if (IsPlayerInLine(_player1.position, _player2.position))
        {
            _hit = Physics2D.RaycastAll(_player1.position,Dir.normalized, Dir.magnitude).Select(A => A.collider).Where(B => B.transform != _player1 && B.transform != _player2).ToList();
            Debug.DrawRay(_player1.position, Dir.normalized);
        }
        else
        {
            _hit.Clear();
        }
    }

    private bool IsPlayerInLine(Vector2 player1Pos, Vector2 player2Pos)
    {
        // x ��ǥ�� ���� ��� (���� ���� ������)
        if (player1Pos.x == player2Pos.x)
        {
            return true;
        }
        // y ��ǥ�� ���� ��� (���� ���� ������)
        else if (player1Pos.y == player2Pos.y)
        {
            return true;
        }
        // �� ���� ��졡�����������ʪ�������
        else
        {
            return false;
        }
    }

    private void Operation()
    {
        
    }
}
