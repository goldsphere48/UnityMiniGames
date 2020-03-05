using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileController : MonoBehaviour
{
    [SerializeField] private Texture2D _looseSmile;
    [SerializeField] private Texture2D _neitralSmile;
    [SerializeField] private Texture2D _winSmile;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSmile()
    {
        var block = new MaterialPropertyBlock();
        switch (GameController.GameState)
        {
            case GameState.Playing:
                block.SetTexture("_MainTex", _neitralSmile);
                break;
            case GameState.Win:
                block.SetTexture("_MainTex", _winSmile);
                break;
            case GameState.Loose:
                block.SetTexture("_MainTex", _looseSmile);
                break;
        }
        _renderer.SetPropertyBlock(block);
    }
}
