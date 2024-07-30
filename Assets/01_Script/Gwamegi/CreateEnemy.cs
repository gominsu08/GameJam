using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;

    [SerializeField] private List<GameObject> _enemyPrefab = new List<GameObject>();

    private List<GameObject> _spawnEnemy = new List<GameObject>();


    
    public void SetEnemyList()
    {
        _spawnEnemy = new List<GameObject>();
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
                    _spawnEnemy.Add(enemy);
                }
            }
        }

        int xRand = Random.Range(xMin, xMax + 1);
        int yRand = Random.Range(yMin, yMax + 1);

        RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(xRand, yRand)), Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("오브젝트가 존재합니다: " + hit.collider.gameObject.name);
            EnemyCreate(xMin, xMax,yMin,yMax, spawnEnemy);
        }
        else
        {
            Debug.Log("타일 위에 오브젝트가 없습니다.");
            GameObject enemy = Instantiate(_spawnEnemy[Random.Range(0, _spawnEnemy.Count)], _tileMap.GetCellCenterWorld(new Vector3Int(xRand, yRand)), Quaternion.identity);
            enemy.GetComponent<NumberContainer>().number = Random.Range(1,10);
            StageManager.Instance.enemyList.Add(enemy);
        }

        

    }

}
