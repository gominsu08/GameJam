using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    [SerializeField] private List<Collider2D> _hit = new List<Collider2D>();
    [SerializeField] private Transform _player1, _player2;
    [SerializeField] private PlayerNum _playerNum;
    private Vector2 Dir { get => -(_player1.position - _player2.position); }

    private void Update()
    {
        Debug.Log(IsPlayerInLine(_player1.position, _player2.position));
        if (IsPlayerInLine(_player1.position, _player2.position))
        {
            _hit = Physics2D.RaycastAll(_player1.position, Dir.normalized, Dir.magnitude).Select(A => A.collider).Where(B => B.transform != _player1 && B.transform != _player2).ToList();
            Debug.DrawRay(_player1.position, Dir.normalized);
            Operation(_player1, ref _playerNum.pc1Num); // �÷��̾� 1 ����
            Operation(_player2, ref _playerNum.pc2Num); // �÷��̾� 2 ����
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

    private void Operation(Transform player, ref int playerNum)
    {
        _hit = Physics2D.RaycastAll(player.position, Dir.normalized, Dir.magnitude)
                .Select(A => A.collider)
                .Where(B => B.transform != _player1 && B.transform != _player2)
                .ToList();

        float result = playerNum;

        List<Collider2D> usedObjects = new List<Collider2D>();

        foreach (Collider2D col in _hit)
        {
            NumberContainer container = col.GetComponent<NumberContainer>();
            if (container != null)
            {
                switch (container.operatorType)
                {
                    case EnumOperator.Plus:
                        result += container.number;
                        usedObjects.Add(col);
                        break;
                    case EnumOperator.Minus:
                        result -= container.number;
                        usedObjects.Add(col);
                        break;
                    case EnumOperator.Multiply:
                        result *= container.number;
                        usedObjects.Add(col);
                        break;
                    case EnumOperator.Division:
                        if (container.number != 0) // 0���� ������ ���� ����
                        {
                            result /= container.number;
                            usedObjects.Add(col);
                        }
                        break;
                }
            }
        }

        playerNum = (int)result;

        _playerNum.PCNumChange(_playerNum.pc1Num, _playerNum.pc2Num);

        foreach (Collider2D usedObj in usedObjects)
        {
            Destroy(usedObj.gameObject);
        }
    }
}
