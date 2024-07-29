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


    private int _xMaxSizeIn;
    private int _xMinSizeIn;
    private int _yMaxSizeIn;
    private int _yMinSizeIn;


    private void Awake()
    {
        _xMaxSizeIn = _xMaxSize;
        _yMaxSizeIn = _yMaxSize;
        _xMinSizeIn = _xMinSize;
        _yMinSizeIn = _yMinSize;
    }


    private void Update()
    {
        _tileMap.transform.position = _tileTransform;

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(TileSet(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize));
            _xMaxSizeIn = _xMaxSize;
            _yMaxSizeIn = _yMaxSize;
            _xMinSizeIn = _xMinSize;
            _yMinSizeIn = _yMinSize;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TileDestroy(_xMinSizeIn, _xMaxSizeIn, _yMinSizeIn, _yMaxSizeIn);
        }
    }


    public void TileSetCoroutineStart()
    {
        StartCoroutine(TileSet(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize));
    }

    private IEnumerator TileSet(int xMin, int xMax, int yMin, int yMax)
    {
        for (int i = xMin; i <= xMax; i++)
        {

            for (int j = yMin; j <= yMax; j++)
            {
                _tileMap.SetTile(new Vector3Int(i, j), _baseTile);
                yield return new WaitForSeconds(0.005f);
            }

        }
    }

    public void TileDestroyCoroutineStart()
    {

    }


    private void TileDestroy(int xMin, int xMax, int yMin, int yMax)
    {
        if (xMin == xMax) return;
        if (yMax == yMin) return;

        int xMaxSize = xMax;
        int xMinSize = xMin;
        int yMaxSize = yMax;
        int yMinSize = yMin;

        for (int i = xMinSize; i <= xMaxSize; i++)
        {
            _tileMap.SetTile(new Vector3Int(i, yMinSize), null);
        }

        for (int i = xMinSize; i <= xMaxSize; i++)
        {
            _tileMap.SetTile(new Vector3Int(i, yMaxSize), null);
        }

        for (int i = yMinSize; i <= yMaxSize; i++)
        {
            _tileMap.SetTile(new Vector3Int(xMinSize, i), null);
        }

        for (int i = yMinSize; i <= yMaxSize; i++)
        {
            _tileMap.SetTile(new Vector3Int(xMaxSize, i), null);
        }

        _xMaxSizeIn--;
        _xMinSizeIn++;
        _yMaxSizeIn--;
        _yMinSizeIn++;

    }
}
