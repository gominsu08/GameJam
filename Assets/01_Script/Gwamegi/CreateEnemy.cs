using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;

    [SerializeField] private List<GameObject> _enemyPrefab = new List<GameObject>();

    private List<string> _spawnEnemy = new List<string>();

    private Dictionary<Vector2,bool> enemySpawnpoint = new Dictionary<Vector2, bool>();


    private void Awake()
    {
        enemySpawnpoint.Add(new Vector2(2, 1), true);
        enemySpawnpoint.Add(new Vector2(0, 1), true);
    }

    public void SetEnemyList()
    {
        _spawnEnemy = new List<string>();
    }

    public void SetEnemyDic()
    {
        enemySpawnpoint.Clear();
        enemySpawnpoint.Add(new Vector2(2, 1), true);
        enemySpawnpoint.Add(new Vector2(0, 1), true);
    }


    public void EnemyCreate(int xMin, int xMax, int yMin, int yMax, List<EnumOperator> spawnEnemy)
    {
        SetEnemyList();

        foreach (EnumOperator item in spawnEnemy)
        {
            foreach (GameObject enemy in _enemyPrefab)
            {
                if(enemy.GetComponent<NumberContainer>().operatorType == item)
                {
                    _spawnEnemy.Add(enemy.GetComponent<Enemy>().poolName);
                }
            }
        }

        int xRand = Random.Range(xMin, xMax + 1);
        int yRand = Random.Range(yMin, yMax + 1);

        Vector2 vec = _tileMap.GetCellCenterWorld(new Vector3Int(xRand, yRand));


        if (enemySpawnpoint.TryAdd(vec,true))
        {
            Enemy enemy = PoolManager.Instance.Pop(_spawnEnemy[Random.Range(0, _spawnEnemy.Count)], vec) as Enemy;
            enemy.GetComponent<NumberContainer>().number = Random.Range(1, 10);
            StageManager.Instance.enemyList.Add(enemy.gameObject);
            return;
        }
        else
        {
            EnemyCreate(xMin, xMax, yMin, yMax, spawnEnemy);
        }

        //RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.zero);
        ////if(Enemy.enemies.Where(a => (Vector2)a.transform.position == vec).ToList().Count == 0)
        ////{
        ////    Debug.Log("Enemy ����");
        ////    Enemy enemy = PoolManager.Instance.Pop(_spawnEnemy[Random.Range(0, _spawnEnemy.Count)], vec) as Enemy;
        ////    enemy.GetComponent<NumberContainer>().number = Random.Range(1, 10);
        ////    StageManager.Instance.enemyList.Add(enemy.gameObject);
        ////    return;
        ////}
        //if (hit.collider != null)
        //{
        //    Debug.Log("������Ʈ�� �����մϴ�: " + hit.collider.gameObject.name);
        //    EnemyCreate(xMin, xMax,yMin,yMax, spawnEnemy);
        //}
        //else
        //{
        //    Debug.Log("Ÿ�� ���� ������Ʈ�� �����ϴ�.");
        //    Enemy enemy = PoolManager.Instance.Pop(_spawnEnemy[Random.Range(0, _spawnEnemy.Count)], vec) as Enemy;
        //    enemy.GetComponent<NumberContainer>().number = Random.Range(1,10);
        //    StageManager.Instance.enemyList.Add(enemy.gameObject);
        //}
    }

}
