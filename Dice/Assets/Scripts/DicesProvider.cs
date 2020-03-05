using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicesProvider : MonoBehaviour
{
    private Dice[] _dices;
    public void InitializeDices()
    {
        _dices = GetComponentsInChildren<Dice>();
    }

    public void ApplyRandomForceForAllDices()
    {
        for (int i = 0; i < _dices.Length; ++i)
        {
            _dices[i].ApplyRandomForce();
        }
    }
}
