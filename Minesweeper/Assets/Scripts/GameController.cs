using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Playing,
    Win,
    Loose
}
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _tileGridGameObject;
    public UnityEvent OnRestart;

    public static GameState GameState = GameState.Playing;

    private TileGrid _tileGrid;

    public void Awake()
    {
        _tileGrid = _tileGridGameObject.GetComponent<TileGrid>();
    }

    public void RestartGame()
    {
        OnRestart?.Invoke();
        GameState = GameState.Playing;
        _tileGrid.Reset();
    }

}
