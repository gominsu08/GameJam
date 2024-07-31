using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class StageManager : MonoSingleton<StageManager>
{
    public List<GameObject> enemyList = new List<GameObject>();

    [SerializeField] private RoundManager _roundManager;

    [SerializeField] private PlayerNum _playerNum;

    [SerializeField] private List<MapData> _mapData = new List<MapData>();
    private MapData _map;

    private int _enemyCount;
    private int _boxCount;

    public int roundTime;
    public int player1;
    public int player2;

    public UnityEvent OnGameOver;
    public UnityEvent OnPlayerDeath;

    //Ÿ�ϸ�
    [SerializeField] private Tilemap _tileMap;
    //�ڽ� Ÿ�ϸ�
    [SerializeField] private Tilemap _boxTileMap;
    //�⺻ Ÿ��
    [SerializeField] private Tile _baseTile;
    //�ڽ� Ÿ��
    [SerializeField] private Tile _boxTile;
    //Ÿ�ϸ� ��ġ
    [SerializeField] private Vector2 _tileTransform;

    [SerializeField] private TMP_Text _moveCountText;

    private CreateEnemy _createEnemy;

    //���� ��������
    public int stage;

    //�ʱⰪ + �� ������ ���߿� ���ֵ� �������
    private int _xMaxSize;
    private int _xMinSize;
    private int _yMaxSize;
    private int _yMinSize;

    //���� �ҋ� ���Ǵ� ����
    private int _xMaxSizeIn;
    private int _xMinSizeIn;
    private int _yMaxSizeIn;
    private int _yMinSizeIn;


    private int _playerMoveCount;

    public bool isEnemyReset;
    public void StageReset()
    {
        isEnemyReset = false;
        _createEnemy.SetEnemyDic();
        _createEnemy.SetEnemyList();
        foreach (GameObject item in enemyList)
        {
            PoolManager.Instance.Push(item.GetComponent<IPoolable>());
        }
        MapDestroy(_xMinSizeIn, _xMaxSizeIn, _yMinSizeIn, _yMaxSizeIn);
        StartCoroutine(BoxTileDestroy(_xMinSizeIn, _xMaxSizeIn, _yMinSizeIn, _yMaxSizeIn));
        MapSetting();
        isEnemyReset = true;
    }
    public void playerMoveCountting()
    {

        _playerMoveCount++;

        if (_playerMoveCount >= 20)
        {
            StartCoroutine(TileDestroy(_xMinSizeIn, _xMaxSizeIn, _yMinSizeIn, _yMaxSizeIn));
            _playerMoveCount = 0;
        }
    }



    public List<EnumOperator> spawnEnemyType = new List<EnumOperator>();

    public int minBossNum, maxBossNum;

    protected override void Awake()
    {
        base.Awake();
        DataManager.Instance.round += 1;
        _createEnemy = GetComponent<CreateEnemy>();
        MapSetting();

        _xMaxSizeIn = _map.xMax;
        _yMaxSizeIn = _map.yMax;
        _xMinSizeIn = _map.xMin;
        _yMinSizeIn = _map.yMin;

        _roundManager.timer.Initialize();
    }

    private void Start()
    {

    }
    private void Update()
    {
        if (enemyList.Count <= 0 && isEnemyReset)
        {
            Debug.Log("���ʹ� ����");
            _roundManager.timer.TimeSet();
            _roundManager.timer.RoundEnd();
            isEnemyReset = false;
        }

        _moveCountText.text = $"�̵�Ƚ��[{_playerMoveCount}]";

        _tileMap.transform.position = _tileTransform;

    }
    public void MapSetting()
    {
        foreach (MapData item in _mapData)
        {
            if (item.stage == DataManager.Instance.round)
            {
                _map = item;
            }
        }
        player1 = _map.player1;
        player2 = _map.player2;

        _playerNum.Start();

        spawnEnemyType = _map.spawnEnemyType;

        roundTime = _map.roundTime;

        minBossNum = _map.minBossNum;
        maxBossNum = _map.maxBossNum;

        _xMaxSize = _map.xMax;
        _yMaxSize = _map.yMax;
        _xMinSize = _map.xMin;
        _yMinSize = _map.yMin;
        _enemyCount = _map.enemyCount;
        _boxCount = _map.boxCount;
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
            _createEnemy.EnemyCreate(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize, spawnEnemyType);
        }
        isEnemyReset = true;
    }
    public void TileSetCoroutineStart()
    {
        
        StartCoroutine(Setting(_xMinSize, _xMaxSize, _yMinSize, _yMaxSize));
    }
    private IEnumerator Setting(int xMin, int xMax, int yMin, int yMax)
    {
        _xMaxSizeIn = _xMaxSize;
        _yMaxSizeIn = _yMaxSize;
        _xMinSizeIn = _xMinSize;
        _yMinSizeIn = _yMinSize;

        int xMaxSize = xMax;
        int xMinSize = xMin;
        int yMaxSize = yMax;
        int yMinSize = yMin;

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
    private IEnumerator BoxTileDestroy(int xMin, int xMax, int yMin, int yMax)
    {
        int xMaxSize = xMax;
        int xMinSize = xMin;
        int yMaxSize = yMax;
        int yMinSize = yMin;

        for (int j = 0; j <= (xMax - xMin) / 2; j++)
        {
            for (int i = xMinSize; i <= xMaxSize; i++)
            {
                _boxTileMap.SetTile(new Vector3Int(i, yMaxSize), null);
            }

            for (int i = yMaxSize; i >= yMinSize; i--)
            {
                _boxTileMap.SetTile(new Vector3Int(xMaxSize, i), null);
            }

            for (int i = xMaxSize; i >= xMinSize; i--)
            {

                _boxTileMap.SetTile(new Vector3Int(i, yMinSize), null);
            }

            for (int i = yMinSize; i <= yMaxSize; i++)
            {
                _boxTileMap.SetTile(new Vector3Int(xMinSize, i), null);
            }

            xMaxSize--;
            xMinSize++;
            yMaxSize--;
            yMinSize++;

        }
        yield return null;
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
            _boxTileMap.SetTile(new Vector3Int(i, yMaxSize), null);
            RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(i, yMaxSize)), Vector2.zero);

            if (hit.collider != null)
            {
                hit.collider.gameObject.SetActive(false);
                if (hit.collider.gameObject.TryGetComponent(out Enemy enemy))
                {
                    enemyList.Remove(hit.collider.gameObject);
                    PoolManager.Instance.Push(hit.collider.gameObject.GetComponent<IPoolable>());
                }
                else
                {
                    OnPlayerDeath?.Invoke();
                    yield break;
                }
            }
            yield return new WaitForSeconds(0.001f);
        }

        for (int i = yMaxSize; i >= yMinSize; i--)
        {
            _boxTileMap.SetTile(new Vector3Int(xMaxSize, i), null);
            _tileMap.SetTile(new Vector3Int(xMaxSize, i), null);
            RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(xMaxSize, i)), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("������Ʈ�� �����մϴ�: " + hit.collider.gameObject.name);
                hit.collider.gameObject.SetActive(false);
                if (hit.collider.gameObject.TryGetComponent(out Enemy enemy))
                {
                    enemyList.Remove(hit.collider.gameObject);
                    PoolManager.Instance.Push(hit.collider.gameObject.GetComponent<IPoolable>());
                }
                else
                {
                    OnPlayerDeath?.Invoke();
                    yield break;
                }
            }
            else
            {
                Debug.Log("Ÿ�� ���� ������Ʈ�� �����ϴ�.");
            }
            yield return new WaitForSeconds(0.001f);
        }

        for (int i = xMaxSize; i >= xMinSize; i--)
        {

            _tileMap.SetTile(new Vector3Int(i, yMinSize), null);
            _boxTileMap.SetTile(new Vector3Int(i, yMinSize), null);
            RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(i, yMinSize)), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("������Ʈ�� �����մϴ�: " + hit.collider.gameObject.name);
                hit.collider.gameObject.SetActive(false);
                if (hit.collider.gameObject.TryGetComponent(out Enemy enemy))
                {
                    enemyList.Remove(hit.collider.gameObject);
                    PoolManager.Instance.Push(hit.collider.gameObject.GetComponent<IPoolable>());
                }
                else
                {
                    OnPlayerDeath?.Invoke();
                    yield break;
                }
            }
            else
            {
                Debug.Log("Ÿ�� ���� ������Ʈ�� �����ϴ�.");
            }
            yield return new WaitForSeconds(0.001f);

        }

        for (int i = yMinSize; i <= yMaxSize; i++)
        {
            _tileMap.SetTile(new Vector3Int(xMinSize, i), null);
            _boxTileMap.SetTile(new Vector3Int(xMinSize, i), null);
            RaycastHit2D hit = Physics2D.Raycast(_tileMap.GetCellCenterWorld(new Vector3Int(xMinSize, i)), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("������Ʈ�� �����մϴ�: " + hit.collider.gameObject.name);
                hit.collider.gameObject.SetActive(false);
                if (hit.collider.gameObject.TryGetComponent(out Enemy enemy))
                {
                    enemyList.Remove(hit.collider.gameObject);
                    PoolManager.Instance.Push(hit.collider.gameObject.GetComponent<IPoolable>());
                }
                else
                {
                    OnPlayerDeath?.Invoke();
                    yield break;
                }
            }
            else
            {
                Debug.Log("Ÿ�� ���� ������Ʈ�� �����ϴ�.");
            }
            yield return new WaitForSeconds(0.001f);
        }




    }
    private void MapDestroy(int xMin, int xMax, int yMin, int yMax)
    {

        int xMaxSize = xMax;
        int xMinSize = xMin;
        int yMaxSize = yMax;
        int yMinSize = yMin;

        for (int j = 0; j <= (xMax - xMin) / 2; j++)
        {
            for (int i = xMinSize; i <= xMaxSize; i++)
            {
                _tileMap.SetTile(new Vector3Int(i, yMaxSize), null);

            }

            for (int i = yMaxSize; i >= yMinSize; i--)
            {
                _tileMap.SetTile(new Vector3Int(xMaxSize, i), null);
            }

            for (int i = xMaxSize; i >= xMinSize; i--)
            {
                _tileMap.SetTile(new Vector3Int(i, yMinSize), null);
            }

            for (int i = yMinSize; i <= yMaxSize; i++)
            {
                _tileMap.SetTile(new Vector3Int(xMinSize, i), null);
            }
            xMaxSize--;
            xMinSize++;
            yMaxSize--;
            yMinSize++;

        }


    }

}
