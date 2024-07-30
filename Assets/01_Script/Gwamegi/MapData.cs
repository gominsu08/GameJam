using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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
}
