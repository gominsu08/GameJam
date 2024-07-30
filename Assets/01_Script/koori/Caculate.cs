using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Caculate : MonoBehaviour
{
    [SerializeField] private List<Collider2D> _hit = new List<Collider2D>();
    [SerializeField] private Transform _player1, _player2;
    [SerializeField] private PlayerNum _playerNum;
    private List<Collider2D> usedObjects = new List<Collider2D>();
    private Vector2 Dir { get => -(_player1.position - _player2.position); }

    private void Update()
    {
        if (_player1 == null || _player2 == null) return; 
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
        //Vector2 centerPos = (_player1.position + _player2.position) / 2f;

        _hit = Physics2D.RaycastAll(_player1.position, Dir.normalized, Dir.magnitude)
            .Select(A => A.collider)
            .Where(B => B.transform != _player1 && B.transform != _player2)
            .OrderBy(hit => Vector2.Distance(_player1.position, hit.transform.position))
            .ToList();

        Debug.DrawRay(_player1.position, Dir.normalized * (Dir.magnitude), Color.red);


        usedObjects.Clear(); 
        _playerNum.Pc1Num = CalculatePlayerNumber(_playerNum.Pc1Num);

        usedObjects.Clear(); 
        _playerNum.Pc2Num = CalculatePlayerNumber(_playerNum.Pc2Num);

        _playerNum.PCNumChange(_playerNum.Pc1Num, _playerNum.Pc2Num);


        foreach (Collider2D usedObj in usedObjects)
        {
            Destroy(usedObj.gameObject);
        }
        usedObjects.Clear();
    }

    
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
                    case EnumOperator.Multiply:
                        result *= container.number;
                        usedObjects.Add(col);
                        break;
                    case EnumOperator.Division:
                        if (container.number != 0)
                        {
                            result /= container.number;
                            usedObjects.Add(col);
                        }
                        break;
                }
            }
        }

        foreach (Collider2D col in _hit)
        {
            NumberContainer container = col.GetComponent<NumberContainer>();
            if (container != null && !usedObjects.Contains(col))
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
                }
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