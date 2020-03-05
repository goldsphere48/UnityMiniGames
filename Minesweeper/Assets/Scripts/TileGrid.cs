using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Difficult
{
    Easy,
    Medium,
    Hard
}

public class TileGrid : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private int _minesCount = 10;

    public UnityEvent OnWin;
    public UnityEvent OnLoose;

    private Tile[,] _tiles;
    private bool[,] _mines;
    private UniqueRandom _random = new UniqueRandom();

    private void Start()
    {
        _tiles = new Tile[_width, _height];
        GenerateMines();
        var gridStart = new Vector3(transform.position.x - _width / 2 + 0.5f, transform.position.y - _height / 2, -1);
        for (int i = 0; i < _width; ++i)
        {
            for (int j = 0; j < _height; ++j)
            {
                var tile = Instantiate(_tilePrefab, transform);
                tile.transform.position = gridStart + new Vector3(i, j, -1);
                _tiles[i, j] = tile.GetComponent<Tile>();
                _tiles[i, j].SetMine(_mines[i, j]);
                _tiles[i, j].SetPositionInGrid(new Vector2(i, j));
                _tiles[i, j].OnOpenTile.AddListener(OpenFreeZone);
                _tiles[i, j].OnOpenTile.AddListener(CheckLooseOrWin);
            }
        }
        SetMinesCountAround();
    }

    public void Reset()
    {
        GenerateMines();
        for (int i = 0; i < _width; ++i)
        {
            for (int j = 0; j < _height; ++j)
            {
                _tiles[i, j].Reset();
                _tiles[i, j].SetMine(_mines[i, j]);
                _tiles[i, j].SetPositionInGrid(new Vector2(i, j));
            }
        }
        SetMinesCountAround();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _width; ++i)
        {
            for (int j = 0; j < _height; ++j)
            {
                _tiles[i, j].OnOpenTile.RemoveAllListeners();
            }
        }
    }

    private void OpenFreeZone(Vector2 start)
    {
        int x = (int)start.x;
        int y = (int)start.y;
        if (_tiles[x, y].IsCovered)
        {
            _tiles[x, y].Open();
            if (_tiles[x, y].IsFree)
            {
                GetTileZone(start, out Vector2 leftTop, out Vector2 rightBottom);
                for (int i = (int)leftTop.x; i <= rightBottom.x; ++i)
                {
                    for (int j = (int)leftTop.y; j <= rightBottom.y; ++j)
                    {
                        if (!_tiles[i, j].IsMarked)
                        {
                            OpenFreeZone(new Vector2(i, j));
                        }
                    }
                }
            }
        }
        else
        {
            return;
        }
    }

    private void ShowMinesAndErrors()
    {
        for (int i = 0; i < _width; ++i)
        {
            for (int j = 0; j < _height; ++j)
            {
                if (_mines[i, j] && !_tiles[i, j].IsMarked)
                {
                    _tiles[i, j].Open();
                }
                if (_tiles[i, j].IsMarked && !_mines[i, j])
                {
                    _tiles[i, j].Cross();
                }
            }
        }
    }

    private void CheckLooseOrWin(Vector2 tilePosition)
    {
        int x = (int)tilePosition.x;
        int y = (int)tilePosition.y;
        if (_mines[x, y])
        {
            ShowMinesAndErrors();
            GameController.GameState = GameState.Loose;
            OnLoose?.Invoke();
            return;
        }
        if (IsWin())
        {
            GameController.GameState = GameState.Win;
            OnWin?.Invoke();
            return;
        }
    }

    private bool IsWin()
    {
        int notCoveredTiles = 0;
        for (int i = 0; i < _width; ++i)
        {
            for (int j = 0; j < _height; ++j)
            {
                if(!_tiles[i, j].IsCovered)
                {
                    notCoveredTiles++;
                }
            }
        }
        return _minesCount == _width * _height - notCoveredTiles;
    }

    private void SetMinesCountAround()
    {
        for (int i = 0; i < _width; ++i)
        {
            for (int j = 0; j < _height; ++j)
            {
                if (_mines[i, j])
                {
                    GetTileZone(new Vector2(i, j), out Vector2 leftTop, out Vector2 rightBottom);
                    for (int k = (int)leftTop.x; k <= rightBottom.x; ++k)
                    {
                        for (int l = (int)leftTop.y; l <= rightBottom.y; ++l)
                        {
                            _tiles[k, l].IncreaseMinesCount();
                        }
                    }
                
                }
            }
        }
    }

    /// <summary>
    /// Return two points left top relative position and right bottom relative position
    /// </summary>
    /// <param name="tilePosition">center</param>
    /// <param name="leftTop">left top relative center</param>
    /// <param name="rightBottom">right bottom relative center</param>
    private void GetTileZone(Vector2 tilePosition, out Vector2 leftTop, out Vector2 rightBottom)
    {
        var i = tilePosition.x;
        var j = tilePosition.y;
        leftTop = new Vector2(i - 1 <= 0 ? 0 : i - 1, j - 1 <= 0 ? 0 : j - 1);
        rightBottom = new Vector2(i + 1 >= _width ? _width - 1 : i + 1, j + 1 >= _height ? _height - 1 : j + 1);
    }

    private void GenerateMines()
    {
        _mines = new bool[_width, _height];
        for (int i = 0; i < _minesCount; ++i)
        {
            var index = _random.NextInt(_width * _height);
            int y = index / _width;
            int x = index - y * _height;
            _mines[x, y] = true;
        }
    }
}
