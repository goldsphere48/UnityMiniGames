using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TableSpriteChanger : MonoBehaviour
{
    public void SetSprite(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}
