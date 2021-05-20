using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    public bool rotateReverse;
    private void Update()
    {
        if (rotateReverse)
            transform.Rotate((-StageData.GetTerrainSpeed() * 4) / 60 * 360 * Time.deltaTime, 0, 0);
        else
            transform.Rotate((StageData.GetTerrainSpeed() * 4) / 60 * 360 * Time.deltaTime, 0, 0);
    }
}
