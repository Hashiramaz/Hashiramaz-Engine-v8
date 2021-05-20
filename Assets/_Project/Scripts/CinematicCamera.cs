using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class CinematicCamera : MonoBehaviour
{   
    public CPC_CameraPath cameraPath;

    public LeanToggle toggle
{
    get{
        return GetComponent<LeanToggle>();
    }
}
    public void StartCamera()
    {
        cameraPath.PlayPath();
        toggle.TurnOn();
    }
}
