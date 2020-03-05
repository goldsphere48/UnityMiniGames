using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Materials
{
    Metallic,
    Plastick
}

public class MaterialPicker : MonoBehaviour
{
    [SerializeField] Toggle _plastickToggle; 
    [SerializeField] Toggle _metallicToggle;

    private void Awake()
    {
        _plastickToggle.onValueChanged.AddListener(ApplyPlastick);
        _metallicToggle.onValueChanged.AddListener(ApplyMetallic);

        var m = GameStorage.ReadMaterial();
        if (m == Materials.Metallic)
        {
            _metallicToggle.isOn = true;
            _plastickToggle.isOn = false;
            _metallicToggle.interactable = false;
        }
        else
        {
            _plastickToggle.isOn = true;
            _metallicToggle.isOn = false;
            _plastickToggle.interactable = false;
        }
    }

    public void ApplyMetallic(bool check)
    {
        if (check)
        {
            _metallicToggle.interactable = false;
            _plastickToggle.interactable = true;
            _plastickToggle.isOn = false;
            Save(PlayerPrefsConstants.Material, Materials.Metallic);
        }
    }

    public void ApplyPlastick(bool check)
    {
        if (check)
        {
            _plastickToggle.interactable = false;
            _metallicToggle.interactable = true;
            _metallicToggle.isOn = false;
            Save(PlayerPrefsConstants.Material, Materials.Plastick);
        }
    }

    private void Save(string constant, Materials value)
    {
        PlayerPrefs.SetString(constant, value.ToString());
    }
}
