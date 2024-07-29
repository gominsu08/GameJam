using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoSingleton<Grid>
{
    [field: SerializeField] public Tilemap gridTilemap { get; private set; }
    [field: SerializeField] public Tilemap mapTilemap { get; private set; }
    [field: SerializeField] public Tile tile { get; private set; }
    public Dictionary<Vector2Int, Entity> entityDic = new();
    protected override void Awake()
    {
        base.Awake();
        gridTilemap = GetComponent<Tilemap>();
        if (mapTilemap == null)
            mapTilemap = transform.parent.transform.GetComponents<Tilemap>().FirstOrDefault(a => a != gridTilemap);
    }
    public bool set(Entity entity, Vector2 pos)
    {
        if (gridTilemap.GetTile(gridTilemap.WorldToCell(pos)) || mapTilemap.GetTile(mapTilemap.WorldToCell(pos)) == null) return false;

        if (entityDic.ContainsKey(Vector2Int.RoundToInt(pos)))
            entityDic[Vector2Int.RoundToInt(pos)] = entity;
        else
            entityDic.Add(Vector2Int.RoundToInt(pos), entity);

        gridTilemap.SetTile(gridTilemap.WorldToCell(pos), tile);
        return true;
    }
    public void remove(Vector2 pos)
    {
        entityDic.Remove(Vector2Int.RoundToInt(pos));
        gridTilemap.SetTile(gridTilemap.WorldToCell(pos), null);
    }

}
