using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MIDIManager : MonoBehaviour
{
    public CameraControllerV3 cameraController;
    private void Update() {
        
        if(MidiMaster.GetKeyDown(48))
        {            
            cameraController.ChangeToRandomCamera();
        }
    }
}
