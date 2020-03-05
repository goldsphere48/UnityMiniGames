using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventVector2: UnityEvent<Vector2>
{

}

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _mine;
    [SerializeField] private GameObject _flag;
    [SerializeField] private GameObject _covered;
    [SerializeField] private GameObject _minesCountText;
    [SerializeField] private GameObject _crossed;
    [SerializeField] private GameObject _error;
    public UnityEventVector2 OnOpenTile;

    private static Color[] NumberColors = 
    {
        new Color(63f/256, 84f/256, 163f/256), // 1 is light blue
        new Color(41f/256, 129f/256, 64f/256), // 2 is green
        new Color(225f/256, 31f/256, 28f/256), // 3 is light red
        new Color(45f/256, 46f/256, 117f/256), // 4 is dark blue
        new Color(125f/256, 0, 0),             // 5 is dark red
        new Color(34f/256, 130f/256, 130f/256),// 6 is cyan
        new Color(204f/256, 170f/256, 0),      // 7 is yellow
        new Color(130f/256, 0, 104f/256),      // 8 is purple
    };

    private bool _isMine = false;
    private bool _isMarked = false;
    private bool _isCovered = true;
    private int _minesCount = 0;
    private Vector2 _positionInGrid;
    private TextMesh _minesCountTextMesh;

    public bool IsFree => _minesCount == 0;
    public bool IsCovered => _isCovered;
    public bool IsMine => _isMine;
    public bool IsMarked => _isMarked;

    private void Awake()
    {
        _minesCountTextMesh = _minesCountText.GetComponent<TextMesh>();
    }

    public void Cross()
    {
        _crossed.SetActive(true);
    }

    public void IncreaseMinesCount()
    {
        _minesCount++;
        if (!_isMine)
        {
            _minesCountText.SetActive(true);
            _minesCountTextMesh.text = _minesCount.ToString();
            _minesCountTextMesh.color = NumberColors[_minesCount - 1];
        }
    }

    public void Reset()
    {
        _isCovered = true;
        _isMine = false;
        _isMarked = false;
        _minesCount = 0;
        _mine.SetActive(false);
        _flag.SetActive(false);
        _crossed.SetActive(false);
        _covered.SetActive(true);
        _minesCountText.SetActive(false);
    }

    public void SetMine(bool value)
    {
        _isMine = value;
        _mine.SetActive(value);
    }

    public void SetPositionInGrid(Vector2 value)
    {
        _positionInGrid = value;
    }

    public void Open()
    {
        _isCovered = false;
        _covered.SetActive(_isCovered);
    }

    private void OnMouseOver()
    {
        if (GameController.GameState == GameState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!_isMarked)
                {
                    OnOpenTile?.Invoke(_positionInGrid);
                }
                if (IsMine)
                {
                    _error.SetActive(true);
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                if (_isCovered)
                {
                    _isMarked = !_isMarked;
                    _flag.SetActive(_isMarked);
                }
            }
        }
    }
}
