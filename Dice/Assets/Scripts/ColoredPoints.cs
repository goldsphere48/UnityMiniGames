﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredPoints : MonoBehaviour
{
    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
