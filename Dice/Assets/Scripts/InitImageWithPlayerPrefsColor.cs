using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
class InitImageWithPlayerPrefsColor : MonoBehaviour
{
    [SerializeField] protected Color _defaultColor;
    [SerializeField] protected string _playerPrefsConstant;

    private void Start()
    {
        Color? color = GameStorage.ReadColorFromPlayerPrefs(_playerPrefsConstant);
        GetComponent<Image>().color = color ?? _defaultColor;
    }
}
