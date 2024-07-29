using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    [SerializeField] private List<Collider2D> _hit = new List<Collider2D>();
    [SerializeField] private Transform _player1, _player2;
    [SerializeField] private PlayerNum _playerNum;
    private List<Collider2D> usedObjects = new List<Collider2D>();
    private Vector2 Dir { get => -(_player1.position - _player2.position); }

    private void Update()
    {
        if (IsPlayerInLine(_player1.position, _player2.position))
        {
            CalculatePlayersNumbers();
        }
        else
        {
            _hit.Clear();
        }
    }

    private void CalculatePlayersNumbers()
    {
        // 1. 두 플레이어 사이의 중간 지점 계산
        Vector2 centerPos = (_player1.position + _player2.position) / 2f;

        // 2. 중간 지점에서 RaycastAll 실행
        _hit = Physics2D.RaycastAll(centerPos, Dir.normalized, Dir.magnitude / 2f) // 거리는 절반만큼
            .Select(A => A.collider)
            .Where(B => B.transform != _player1 && B.transform != _player2)
            .OrderBy(hit => Vector2.Distance(centerPos, hit.transform.position)) // 중간 지점에서의 거리 순으로 정렬
            .ToList();

        Debug.DrawRay(centerPos, Dir.normalized * (Dir.magnitude / 2f), Color.red); // 디버깅 Ray 그리기

        // 3. 플레이어 1과 플레이어 2의 숫자 계산
        _playerNum.pc1Num = CalculatePlayerNumber(_playerNum.pc1Num);
        _playerNum.pc2Num = CalculatePlayerNumber(_playerNum.pc2Num);

        _playerNum.PCNumChange(_playerNum.pc1Num, _playerNum.pc2Num);

        // 4. 사용된 오브젝트 삭제
        foreach (Collider2D usedObj in usedObjects)
        {
            Destroy(usedObj.gameObject);
        }
        usedObjects.Clear();
    }

    // 플레이어 숫자 계산 함수
    private int CalculatePlayerNumber(int playerNum)
    {
        float result = playerNum;

        foreach (Collider2D col in _hit)
        {
            NumberContainer container = col.GetComponent<NumberContainer>();
            if (container != null && !usedObjects.Contains(col))
            {
                switch (container.operatorType)
                {
                    case EnumOperator.Plus:
                        result += container.number;
                        break;
                    case EnumOperator.Minus:
                        result -= container.number;
                        break;
                    case EnumOperator.Multiply:
                        result *= container.number;
                        break;
                    case EnumOperator.Division:
                        if (container.number != 0)
                        {
                            result /= container.number;
                        }
                        break;
                }
                usedObjects.Add(col); // 연산 후 사용된 오브젝트 추가
            }
        }

        return (int)result;
    }

    private bool IsPlayerInLine(Vector2 player1Pos, Vector2 player2Pos)
    {
        if (Mathf.Approximately(player1Pos.x, player2Pos.x))
        {
            return true;
        }
        else if (Mathf.Approximately(player1Pos.y, player2Pos.y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}