using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoSingleton<Grid>
{
    [field: SerializeField] public Tilemap tilemap { get; private set; }
    [field: SerializeField] public Tile tile { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        tilemap = GetComponent<Tilemap>();
    }
    public bool set(Vector2 pos)
    {
        if (tilemap.GetTile(tilemap.WorldToCell(pos))) return false;
        tilemap.SetTile(tilemap.WorldToCell(pos), tile);
        return true;
    }
    public void remove(Vector2 pos)
    {
        tilemap.SetTile(tilemap.WorldToCell(pos), null);
    }

}
