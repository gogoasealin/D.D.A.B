using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScaleWithCamera : MonoBehaviour {

    public int targetWidth;
    public float pixelToUnits;
    private Quaternion rotationZero = Quaternion.Euler(0, 0, 0);
    private void Update()
    {
        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);

        GetComponent<Camera>().orthographicSize﻿ = height / pixelToUnits / 2;
    }
}

