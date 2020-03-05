using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DicesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _dicePrefab;
    public UnityEvent OnDicesSpawned; 

    void Start()
    {
        int dicesQuantity = PlayerPrefs.GetInt("DicesQuantity");
        
        if (dicesQuantity == 0)
        {
            dicesQuantity = 1;
            PlayerPrefs.SetInt(PlayerPrefsConstants.DicesQuantity, dicesQuantity);
        }

        for (int i = 0; i < dicesQuantity; ++i)
        {
            Instantiate(_dicePrefab, transform, true);
        }

        OnDicesSpawned?.Invoke();
    }
}
