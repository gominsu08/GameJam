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
}
