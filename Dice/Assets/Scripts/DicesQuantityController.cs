using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DicesQuantityController : MonoBehaviour
{
    [SerializeField] private GameObject _dicesQuantityText;

    private Text _text;
    private readonly int maxQuantity = 10;

    public void Awake()
    {
        _text = _dicesQuantityText.GetComponent<Text>();
        UpdateText(GetCurrentQuantity());
    }

    public void Increase()
    {
        int current = GetCurrentQuantity();
        if (current + 1 <= maxQuantity)
        {
            current++;
            UpdateQuantity(current);
        }
    }

    public void Decrease()
    {
        int current = GetCurrentQuantity();
        if (current - 1 > 0)
        {
            current--;
            UpdateQuantity(current);
        }
    }

    private void UpdateText(int newQuantity)
    {
        _text.text = newQuantity.ToString();
    }

    private int GetCurrentQuantity()
    {
        return PlayerPrefs.GetInt(PlayerPrefsConstants.DicesQuantity);
    }

    private void UpdateQuantity(int newQuantity)
    {
        PlayerPrefs.SetInt(PlayerPrefsConstants.DicesQuantity, newQuantity);
        UpdateText(newQuantity);
    }
}
