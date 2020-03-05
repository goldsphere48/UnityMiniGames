using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameStorage : MonoBehaviour
{
    public static Color? ReadColorFromPlayerPrefs(string playerPrefsConstant)
    {
        if (PlayerPrefs.HasKey(playerPrefsConstant))
        {
            return HexColorUtils.GetColorFromHex(PlayerPrefs.GetString(playerPrefsConstant));
        }
        return null;
    }

    public static Materials ReadMaterial()
    {
        var m = PlayerPrefs.GetString(PlayerPrefsConstants.Material);
        Enum.TryParse<Materials>(m, out Materials material);
        return material;
    }
}
