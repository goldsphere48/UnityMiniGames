using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class UnityEventSprite : UnityEvent<Sprite>
{

}

public class TableSpritePicker : MonoBehaviour, IPointerDownHandler
{
    public UnityEventSprite OnSpritePick;

    private Sprite _sprite;

    private void Awake()
    {
        _sprite = GetComponent<Image>().sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnSpritePick?.Invoke(_sprite);
    }
}
