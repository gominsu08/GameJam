using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialCalculator : MonoBehaviour
{
    [SerializeField] private List<Collider2D> _hit = new List<Collider2D>();
    [SerializeField] private Transform _player1, _player2;
    [SerializeField] private TutorialNumManagewr _playerNum;
    private List<Collider2D> usedObjects = new List<Collider2D>();
    private Vector2 Dir { get => -(_player1.position - _player2.position); }

    private void Awake()
    {
    }
    private void Start()
    {
        InputReader.Instance.OnPlayer1Move += aa;
        InputReader.Instance.OnPlayer2Move += aa;
    }
    public void aa(Vector2 vector2)
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
    private List<Collider2D> GetEntitiesBetweenPlayers(Vector2 player1Pos, Vector2 player2Pos)
    {
        // �÷��̾� 1�� 2 ������ ��� ��ǥ ���
        var direction = (player2Pos - player1Pos).normalized;
        var distance = Vector2.Distance(player1Pos, player2Pos);
        var steps = Mathf.CeilToInt(distance); // �Ÿ���ŭ�� ���� ���

        var positionsBetween = Enumerable.Range(0, steps)
                                         .Select(step => player1Pos + direction * step)
                                         .ToList();

        // Grid.Instance.entities���� �ش� ��ǥ�� �ִ� ��ƼƼ���� ���͸�
        var entities = Grid.Instance.entityDic
                             .Where(entity => positionsBetween.Contains((Vector2)entity.Key))
                             .Select(entity => entity.Value.GetComponent<Collider2D>())
                             .Where(collider => collider != null)
                             .ToList();

        return entities;
    }
    private void CalculatePlayersNumbers()
    {
        //Vector2 centerPos = (_player1.position + _player2.position) / 2f;

        _hit = GetEntitiesBetweenPlayers(_player1.position, _player2.position);

        Debug.DrawRay(_player1.position, Dir.normalized * (Dir.magnitude), Color.red);


        usedObjects.Clear();
        _playerNum.Pc1Num = CalculatePlayerNumber(_playerNum.Pc1Num);

        usedObjects.Clear();
        _playerNum.Pc2Num = CalculatePlayerNumber(_playerNum.Pc2Num);

        _playerNum.PCNumChange(_playerNum.Pc1Num, _playerNum.Pc2Num);


        foreach (Collider2D usedObj in usedObjects)
        {
            usedObj.gameObject.GetComponent<Enemy>().Effect();
            usedObj.gameObject.SetActive(false);
            PoolManager.Instance.Push(usedObj.gameObject.GetComponent<Enemy>());
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
