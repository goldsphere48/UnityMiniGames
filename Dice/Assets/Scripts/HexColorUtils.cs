using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HexColorUtils
{
    private static int HexToDec(string hex)
    {
        return System.Convert.ToInt32(hex, 16);
    }

    private static string DecToHex(int dec)
    {
        return dec.ToString("X2");
    }

    private static string FloatNormalizeToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    private static float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    public static Color GetColorFromHex(string hex)
    {
        float red = HexToFloatNormalized(hex.Substring(0, 2));
        float green = HexToFloatNormalized(hex.Substring(2, 2));
        float blue = HexToFloatNormalized(hex.Substring(4, 2));
        return new Color(red, green, blue);
    }

    public static string GetHexStringFromColor(Color color)
    {
        string red = FloatNormalizeToHex(color.r);
        string green = FloatNormalizeToHex(color.g);
        string blue = FloatNormalizeToHex(color.b);
        return red + green + blue;
    }
}

