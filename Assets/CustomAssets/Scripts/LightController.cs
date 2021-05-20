using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    
    public Light FlashLight;
    public bool FlashTurnOn;

    public float flashFrequency = 0.05f;

    public Animator lightanim;

    public List<ProbeController> probesPurple;
    public bool purpleEnabled;


    public bool pattern2Enabled;

    public List<GameObject> LightsGroup1;
    public List<GameObject> LightsGroup2;

    private void OnEnable() {
        GlobalEventSystem.onStartTurnOnLights += ToogleLight;
        GlobalEventSystem.onStartTurnOffLights += StopFlashLight;
        GlobalEventSystem.onSetLightsPattern3 += TooglePurpleLights;
        GlobalEventSystem.onSetLightsPattern2 += TooglePatternProbes;
    }

    private void OnDisable() {
        GlobalEventSystem.onStartTurnOnLights -= ToogleLight;
        GlobalEventSystem.onStartTurnOffLights -= StopFlashLight;
        GlobalEventSystem.onSetLightsPattern3 -= TooglePurpleLights;
        GlobalEventSystem.onSetLightsPattern2 -= TooglePatternProbes;
        
    }


    public void ToogleLight()
    {
        
        Debug.Log("Lights On");
        FlashTurnOn = true;
        lightanim.SetBool("LightOn",FlashTurnOn);

        // if(!FlashTurnOn)
        // {            
        //     FlashTurnOn = true;
        //     StartCoroutine(FlashRoutine());
        // }
        
    }

    IEnumerator FlashRoutine()
    {
        while (FlashTurnOn)
        {
            FlashLight.gameObject.SetActive(!FlashLight.gameObject.activeSelf);
            yield return new WaitForSeconds(flashFrequency);

        }
        FlashLight.gameObject.SetActive(false);
    }

    public void StopFlashLight()
    {
        //FlashTurnOn = true;
        FlashTurnOn = false;
        lightanim.SetBool("LightOn",FlashTurnOn);
        StopCoroutine("FlashRoutine");
    }

    public void TooglePurpleLights()
    {
        purpleEnabled = !purpleEnabled;

        for (int i = 0; i < probesPurple.Count ; i++)
        {
            probesPurple[i].gameObject.SetActive(purpleEnabled);
        }
    }


    public void TooglePatternProbes()
    {
        pattern2Enabled = !pattern2Enabled;
        
        for (int i = 0; i < LightsGroup1.Count; i++)
        {
            LightsGroup1[i].gameObject.SetActive(pattern2Enabled);    
        }
        
        for (int i = 0; i < LightsGroup2.Count; i++)
        {
            LightsGroup2[i].gameObject.SetActive(!pattern2Enabled);    
        }

    }
}
