using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class SpriteColorChanger : MonoBehaviour
{
    public UnityEventColor OnColorChanged;

    public void SetColor(Color color)
    {
        GetComponent<Image>().color = color;
        OnColorChanged?.Invoke(color);
    }
}
