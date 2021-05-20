using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{

    public ParticleSystem flame1;
    public ParticleSystem flame2;

    public bool flamesActive;

    private void OnEnable() {
        GlobalEventSystem.onStartCustomEvent4 += ToogleFlames;
    }

    private void OnDisable() {
        GlobalEventSystem.onStartCustomEvent4 -= ToogleFlames;
        
    }



    public void ToogleFlames()
    {
        flamesActive = !flamesActive;


        if(flamesActive)
        {
            flame1.Play();
            flame2.Play();
        }
        else
        {
            flame1.Stop();
            flame2.Stop();

        }
    }
    public void ToogleFlamesState(bool State)
    {
        flamesActive = State;


        if(flamesActive)
        {
            flame1.Play();
            flame2.Play();
        }
        else
        {
            flame1.Stop();
            flame2.Stop();

        }
    }
}
