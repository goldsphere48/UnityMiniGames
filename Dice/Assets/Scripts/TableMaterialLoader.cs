using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMaterialLoader
{
    public static Material LoadMaterialFromPlayerPrefs()
    {
        Material material;
        var name = PlayerPrefs.GetString(PlayerPrefsConstants.TableSprite);
        if (!string.IsNullOrEmpty(name))
        {
            material = Resources.Load<Material>("Materials/" + name);
        }
        else
        {
            material = Resources.Load<Material>("Materials/light-wood");
        }
        return material;
    }

    public static Sprite LoadSpriteFromPlayerPrefs()
    {
        Sprite sprite;
        var name = PlayerPrefs.GetString(PlayerPrefsConstants.TableSprite);
        if (!string.IsNullOrEmpty(name))
        {
            sprite = Resources.Load<Sprite>("Textures/" + name);
        }
        else
        {
            sprite = Resources.Load<Sprite>("Textures/light-wood");
        }
        return sprite;
    }
}
