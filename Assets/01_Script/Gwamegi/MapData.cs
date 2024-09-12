using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/MapData")]
public class MapData : ScriptableObject
{
    public int stage;

    public int xMax;
    public int yMax;
    public int xMin;
    public int yMin;

    public int boxCount;
    public int enemyCount;

    public List<EnumOperator> spawnEnemyType = new List<EnumOperator>();

    public int minBossNum, maxBossNum;

    public int roundTime;

    public int player1;
    public int player2;
}
