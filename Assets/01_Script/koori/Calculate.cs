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
        Vector2 centerPos = (_player1.position + _player2.position) / 2f;

        _hit = Physics2D.RaycastAll(centerPos, Dir.normalized, Dir.magnitude / 2f)
            .Select(A => A.collider)
            .Where(B => B.transform != _player1 && B.transform != _player2)
            .OrderBy(hit => Vector2.Distance(centerPos, hit.transform.position))
            .ToList();

        Debug.DrawRay(centerPos, Dir.normalized * (Dir.magnitude / 2f), Color.red);


        usedObjects.Clear(); 
        _playerNum.pc1Num = CalculatePlayerNumber(_playerNum.pc1Num);

        usedObjects.Clear(); 
        _playerNum.pc2Num = CalculatePlayerNumber(_playerNum.pc2Num);

        _playerNum.PCNumChange(_playerNum.pc1Num, _playerNum.pc2Num);


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