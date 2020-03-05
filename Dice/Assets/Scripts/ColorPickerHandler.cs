using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteColorChanger))]
public class ColorPickerHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] ColorPickerPanel _colorPickerPanel;

    private SpriteColorChanger _spriteColorChanger;

    private void Awake()
    {
        _spriteColorChanger = GetComponent<SpriteColorChanger>();    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _colorPickerPanel.gameObject.SetActive(true);
        _colorPickerPanel.OnColorChanged.RemoveAllListeners();
        _colorPickerPanel.OnColorChanged.AddListener(_spriteColorChanger.SetColor);
    }
}
