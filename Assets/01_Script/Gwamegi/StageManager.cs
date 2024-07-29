using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class StageManager : MonoSingleton<StageManager>
{
    [SerializeField] private RoundManager _roundManager;

    [SerializeField] private List<MapData> _mapData = new List<MapData>();

    [SerializeField] private int _enemyCount;
    [SerializeField] private int _boxCount;

    //타일맵
    [SerializeField] private Tilemap _tileMap;
    //박스 타일맵
    [SerializeField] private Tilemap _boxTileMap;
    //기본 타일
    [SerializeField] private Tile _baseTile;
    //박스 타일
    [SerializeField] private Tile _boxTile;
    //타일맵 위치
    [SerializeField] private Vector2 _tileTransform;

    private CreateEnemy _createEnemy;

    public int stage;

    //초기값 + 맵 데이터 나중에 없애도 상관없음
    private int _xMaxSize;
    private int _xMinSize;
    private int _yMaxSize;
    private int _yMinSize;

    //삭제 할떄 상용되는 변수
    private int _xMaxSizeIn;
    private int _xMinSizeIn;
    private int _yMaxSizeIn;
    private int _yMinSizeIn;


    protected override void Awake()
    {
        base.Awake();
        _xMaxSize = _mapData[stage].xMax;
        _yMaxSize = _mapData[stage].yMax;
        _xMinSize = _mapData[stage].xMin;
        _yMinSize = _mapData[stage].yMin;

        _createEnemy = GetComponent<CreateEnemy>();
        _xMaxSizeIn = _xMaxSize;
        _yMaxSizeIn = _yMaxSize;
        _xMinSizeIn = _xMinSize;
        _yMinSizeIn = _yMinSize;
    }


    private void Update()
    {
        _tileMap.transform.position = _tileTransform;

        _xMaxSize = _mapData[stage].xMax;
        _yMaxSize = _mapData[stage].yMax;
        _xMinSize = _mapData[stage].xMin;
        _yMinSize = _mapData[stage].yMin;

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(Setting(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize));
            _xMaxSizeIn = _xMaxSize;
            _yMaxSizeIn = _yMaxSize;
            _xMinSizeIn = _xMinSize;
            _yMinSizeIn = _yMinSize;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(TileDestroy(_xMinSizeIn, _xMaxSizeIn, _yMinSizeIn, _yMaxSizeIn));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBox(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize);
        }
    }

    public void CreateBox(int xMin, int xMax, int yMin, int yMax)
    {
            int xRand = Random.Range(xMin, xMax + 1);
            int yRand = Random.Range(yMin, yMax + 1);

            if (_boxTileMap.GetTile(new Vector3Int(xRand, yRand)))
            {
                CreateBox(xMin, xMax, yMin, yMax);
            }
            else
            {
                _boxTileMap.SetTile(new Vector3Int(xRand, yRand), _boxTile);
            }
    }

    


    public void CreateEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _createEnemy.EnemyCreate(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize);
        }
    }

    public void TileSetCoroutineStart()
    {
        StartCoroutine(Setting(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize));
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


    private IEnumerator Setting(int xMin, int xMax, int yMin, int yMax)
    {
        int xMaxSize = xMax;
        int xMinSize = xMin;
        int yMaxSize = yMax;
        int yMinSize = yMin;

        Debug.Log(1);

        for (int j = 0; j <= (xMax - xMin) / 2; j++)
        {


            for (int i = xMinSize; i <= xMaxSize; i++)
            {
                _tileMap.SetTile(new Vector3Int(i, yMaxSize), _baseTile);

                yield return new WaitForSeconds(0.001f);
            }

            for (int i = yMaxSize; i >= yMinSize; i--)
            {
                _tileMap.SetTile(new Vector3Int(xMaxSize, i), _baseTile);

                yield return new WaitForSeconds(0.001f);
            }

            for (int i = xMaxSize; i >= xMinSize; i--)
            {
                _tileMap.SetTile(new Vector3Int(i, yMinSize), _baseTile);

                yield return new WaitForSeconds(0.001f);
            }

            for (int i = yMinSize; i <= yMaxSize; i++)
            {
                _tileMap.SetTile(new Vector3Int(xMinSize, i), _baseTile);

                yield return new WaitForSeconds(0.001f);
            }

            xMaxSize--;
            xMinSize++;
            yMaxSize--;
            yMinSize++;
        }

        _roundManager.timer.TileSet();
        CreateEnemy(_enemyCount);

        for (int i = 0; i < _boxCount; i++)
        {
            CreateBox(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize);
        }

    }


    private IEnumerator TileDestroy(int xMin, int xMax, int yMin, int yMax)
    {
        if (xMin == xMax - 2) yield break;
        if (yMax - 2 == yMin) yield break;

        if (xMin == (xMax - 1)) yield break;
        if ((yMax - 1) == yMin) yield break;

        int xMaxSize = xMax;
        int xMinSize = xMin;
        int yMaxSize = yMax;
        int yMinSize = yMin;

        _xMaxSizeIn--;
        _xMinSizeIn++;
        _yMaxSizeIn--;
        _yMinSizeIn++;

        for (int i = xMinSize; i <= xMaxSize; i++)
        {
            _tileMap.SetTile(new Vector3Int(i, yMaxSize), null);
            RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(i, yMaxSize)), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("오브젝트가 존재합니다: " + hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("타일 위에 오브젝트가 없습니다.");
            }
            yield return new WaitForSeconds(0.001f);
        }

        for (int i = yMaxSize; i >= yMinSize; i--)
        {
            _tileMap.SetTile(new Vector3Int(xMaxSize, i), null);
            RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(xMaxSize, i)), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("오브젝트가 존재합니다: " + hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("타일 위에 오브젝트가 없습니다.");
            }
            yield return new WaitForSeconds(0.001f);
        }

        for (int i = xMaxSize; i >= xMinSize; i--)
        {

            _tileMap.SetTile(new Vector3Int(i, yMinSize), null);
            RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(i, yMinSize)), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("오브젝트가 존재합니다: " + hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("타일 위에 오브젝트가 없습니다.");
            }
            yield return new WaitForSeconds(0.001f);

        }

        for (int i = yMinSize; i <= yMaxSize; i++)
        {
            _tileMap.SetTile(new Vector3Int(xMinSize, i), null);
            RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(xMinSize, i)), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("오브젝트가 존재합니다: " + hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("타일 위에 오브젝트가 없습니다.");
            }
            yield return new WaitForSeconds(0.001f);
        }




    }
}
