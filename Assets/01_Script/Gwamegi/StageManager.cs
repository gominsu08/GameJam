using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private Tile _baseTile;

    [SerializeField] private Vector2 _tileTransform;

    [SerializeField] private int _xMaxSize;
    [SerializeField] private int _xMinSize;
    [SerializeField] private int _yMaxSize;
    [SerializeField] private int _yMinSize;
    private void Update()
    {
        _tileMap.transform.position = _tileTransform;

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(TileSet(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize));
        }
    }


    public void TileSetCoroutineStart()
    {
        StartCoroutine(TileSet(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize));
    }

    private IEnumerator TileSet(int xMin,int xMax, int yMin, int yMax)
    {

        for (int i = xMin; i < xMax; i++) 
        {

            for (int j = yMin; j < yMax; j++)
            {
                _tileMap.SetTile(new Vector3Int(i, j), _baseTile);
                yield return new WaitForSeconds(0.01f);
            }
        
        }
    }
}
