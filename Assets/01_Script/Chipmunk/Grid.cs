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
    protected override void Awake()
    {
        base.Awake();
        gridTilemap = GetComponent<Tilemap>();
        if (mapTilemap == null)
            mapTilemap = transform.parent.transform.GetComponents<Tilemap>().FirstOrDefault(a => a != gridTilemap);
    }
    public bool set(Vector2 pos)
    {
        if (gridTilemap.GetTile(gridTilemap.WorldToCell(pos)) || mapTilemap.GetTile(mapTilemap.WorldToCell(pos)) == null) return false;
        gridTilemap.SetTile(gridTilemap.WorldToCell(pos), tile);
        return true;
    }
    public void remove(Vector2 pos)
    {
        gridTilemap.SetTile(gridTilemap.WorldToCell(pos), null);
    }

}
