using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSpriteSaver : MonoBehaviour
{
    public void SaveTableSprite(Sprite sprite)
    {
        PlayerPrefs.SetString(PlayerPrefsConstants.TableSprite, sprite.name);
    }
}
