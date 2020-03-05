using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorPicker : MonoBehaviour, IPointerDownHandler
{
    public event Action<Color> OnColorPick;

    private Color _color;

    private void Awake()
    {
        _color = GetComponent<Image>().color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnColorPick?.Invoke(_color);
    }
}
