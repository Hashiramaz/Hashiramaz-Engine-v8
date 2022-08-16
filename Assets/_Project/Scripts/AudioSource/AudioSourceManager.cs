using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lasp;

public class AudioSourceManager : MonoBehaviourSingleton<AudioSourceManager>
{
    public string selectedDeviceID;

    public string[] avaiableDevices;

    public AudioLevelTracker audioTracker;


    private void Start() {
        selectedDeviceID = audioTracker.deviceID;
    }

    public void SelectDevice()
    {

    }

    public void OnDeviceSelected()
    {

    }
}
