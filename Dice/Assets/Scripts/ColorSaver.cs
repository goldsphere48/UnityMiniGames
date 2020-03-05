using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSaver : MonoBehaviour
{
    public void SaveDiceColor(Color color)
    {
        Save(color, PlayerPrefsConstants.DiceColor);
    }

    public void SaveDicePointsColor(Color color)
    {
        Save(color, PlayerPrefsConstants.DicePointsColor);
    }

    public void Save(Color color, string constant)
    {
        string hex = HexColorUtils.GetHexStringFromColor(color);
        PlayerPrefs.SetString(constant, hex);
    }
}
