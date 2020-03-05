using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityEventColor : UnityEvent<Color>
{

}

public class ColorPickerPanel : MonoBehaviour
{
    public UnityEventColor OnColorChanged;

    private ColorPicker[] _colorPickers;

    private void Awake()
    {
        _colorPickers = GetComponentsInChildren<ColorPicker>();
        
    }

    public void OnEnable()
    {
        foreach (var colorPicker in _colorPickers)
        {
            colorPicker.OnColorPick += OnColorChanged.Invoke;
        }
    }

    public void OnDisable()
    {
        foreach (var colorPicker in _colorPickers)
        {
            colorPicker.OnColorPick -= OnColorChanged.Invoke;
        }
    }
}
