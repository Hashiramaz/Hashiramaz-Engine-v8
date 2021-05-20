using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueColorChangeAtTime : MonoBehaviour
{
    public Color currentHueColor;
    public float currentHueValue;

    private void Update() {
        UpdateHueColor();
    }
    public void UpdateHueColor()
    {
        currentHueValue += 0.001f;

        if(currentHueValue >= 1)
        {
            currentHueValue = 0;
        }

        currentHueColor = Color.HSVToRGB(currentHueValue,1f,1f);
    }

    public Color GetCurrentHueColor()
    {
        return currentHueColor;
    }
}
