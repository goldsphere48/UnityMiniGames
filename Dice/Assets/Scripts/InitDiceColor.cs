using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class InitDiceColor : MonoBehaviour
{
    private ColoredPoints[] _coloredPoints;
    private Renderer _renderer;

    private void Awake()
    {
        _coloredPoints = GetComponentsInChildren<ColoredPoints>();
        _renderer = GetComponent<Renderer>();
        var diceColor = GameStorage.ReadColorFromPlayerPrefs(PlayerPrefsConstants.DiceColor);
        var dicePointsColor = GameStorage.ReadColorFromPlayerPrefs(PlayerPrefsConstants.DicePointsColor);
        SetDiceColor(diceColor ?? Color.white);
        SetDicePointsColor(dicePointsColor ?? Color.black);
    }

    public void SetDiceColor(Color color)
    {
        _renderer.material.SetColor("_Color", color);
        var material = GameStorage.ReadMaterial();
        if (material == Materials.Metallic)
        {
            _renderer.material.SetFloat("_Metallic", DiceMaterial.Metallic.MetallicIntensity);
            _renderer.material.SetFloat("_Glossiness", DiceMaterial.Metallic.Smoothness);
        }
        else
        {
            _renderer.material.SetFloat("_Metallic", DiceMaterial.Plastick.MetallicIntensity);
            _renderer.material.SetFloat("_Glossiness", DiceMaterial.Plastick.Smoothness);
        }
    }

    public void SetDicePointsColor(Color color)
    {
        foreach (var cp in _coloredPoints)
        {
            cp.SetColor(color);
        }
    }
}

