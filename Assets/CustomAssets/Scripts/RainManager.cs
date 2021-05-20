using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    public ParticleSystem Rain;

    public bool rainEnabled;
    private void OnEnable() {
        GlobalEventSystem.onStartCustomEvent3 += ToogleRain;
    }

    private void OnDisable() {
        GlobalEventSystem.onStartCustomEvent3 -= ToogleRain;
        
    }


    public void ToogleRain()
    {
        rainEnabled = !rainEnabled;

        if(rainEnabled)
            Rain.Play();
        else
            Rain.Stop();
    }
}
