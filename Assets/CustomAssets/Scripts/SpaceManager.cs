using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    public ParticleSystem turboParticles1;
    public ParticleSystem turboParticles2;

    public bool turboActive;

    public GameObject DHMESSAGE;
    public bool MessageActive;

private void OnEnable() {
    GlobalEventSystem.onToogleSpaceParticles += ToogleTurboParticles;
    GlobalEventSystem.onStartCustomEvent5 += ToogleDHMessage;
}

private void OnDisable() {
    GlobalEventSystem.onToogleSpaceParticles -= ToogleTurboParticles;
    GlobalEventSystem.onStartCustomEvent5 -= ToogleDHMessage;
    
}

    public void ToogleTurboParticles()
    {
        turboActive = !turboActive;


        if(turboActive)
        {
            turboParticles1.Play();
            turboParticles2.Play();
        }
        else
        {
            turboParticles1.Stop();
            turboParticles2.Stop();
        }
    }

    public void ToogleDHMessage()
    {
        MessageActive = !MessageActive;

        DHMESSAGE.gameObject.SetActive(MessageActive);
        
    }
}
