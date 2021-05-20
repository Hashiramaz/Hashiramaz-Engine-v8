using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventSystem : MonoBehaviour
{
    public delegate void ShowEvent();

    public delegate Transform TransformValue();


    public static event ShowEvent onStartCustomCamera1;
    public static void StartCustomCamera1()
    {
        if(onStartCustomCamera1 != null)
        {
            onStartCustomCamera1();
        }
    }
    public static event ShowEvent onStartCustomCamera2;
    public static void StartCustomCamera2()
    {
        if(onStartCustomCamera2 != null)
        {
            onStartCustomCamera2();
        }
    }
    public static event ShowEvent onStartCustomCamera3;
    public static void StartCustomCamera3()
    {
        if(onStartCustomCamera3 != null)
        {
            onStartCustomCamera3();
        }
    }
    public static event ShowEvent onStartCustomCamera4;
    public static void StartCustomCamera4()
    {
        if(onStartCustomCamera4 != null)
        {
            onStartCustomCamera4();
        }
    }
    public static event ShowEvent onStartCustomCamera5;
    public static void StartCustomCamera5()
    {
        if(onStartCustomCamera5 != null)
        {
            onStartCustomCamera5();
        }
    }
    public static event ShowEvent onStartCustomCamera6;
    public static void StartCustomCamera6()
    {
        if(onStartCustomCamera6 != null)
        {
            onStartCustomCamera6();
        }
    }
    public static event ShowEvent onStartCustomCamera7;
    public static void StartCustomCamera7()
    {
        if(onStartCustomCamera7 != null)
        {
            onStartCustomCamera7();
        }
    }
    public static event ShowEvent onStartCustomCamera8;
    public static void StartCustomCamera8()
    {
        if(onStartCustomCamera8 != null)
        {
            onStartCustomCamera8();
        }
    }
    public static event ShowEvent onStartCustomCamera9;
    public static void StartCustomCamera9()
    {
        if(onStartCustomCamera9 != null)
        {
            onStartCustomCamera9();
        }
    }
    public static event ShowEvent onStartRandomCameras;
    public static void StartRandomCameras()
    {
        if(onStartRandomCameras != null)
        {
            onStartRandomCameras();
        }
    }
    public static event ShowEvent onStopRandomCameras;
    public static void StopRandomCameras()
    {
        if(onStopRandomCameras != null)
        {
            onStopRandomCameras();
        }
    }

    public static event ShowEvent onStartTurnOnLights;
    public static void StartTurnOnLights()
    {
        if(onStartTurnOnLights != null)
        {
            onStartTurnOnLights();
        }
    }
    public static event ShowEvent onStartTurnOffLights;
    public static void StartTurnOffLights()
    {
        if(onStartTurnOffLights != null)
        {
            onStartTurnOffLights();
        }
    }
    public static event ShowEvent onSetLightsPattern1;
    public static void SetLightsPattern1()
    {
        if(onSetLightsPattern1 != null)
        {
            onSetLightsPattern1();
        }
    }
    public static event ShowEvent onSetLightsPattern2;
    public static void SetLightsPattern2()
    {
        if(onSetLightsPattern2 != null)
        {
            onSetLightsPattern2();
        }
    }
    public static event ShowEvent onSetLightsPattern3;
    public static void SetLightsPattern3()
    {
        if(onSetLightsPattern3 != null)
        {
            onSetLightsPattern3();
        }
    }
 
    public static event ShowEvent onToogleBackgroundKeyboard;
    public static void ToogleBackgroundKeyboard()
    {
        if(onToogleBackgroundKeyboard != null)
        {
            onToogleBackgroundKeyboard();
        }
    }
    public static event ShowEvent onStartCustomEvent1;
    public static void StartCustomEvent1()
    {
        if(onStartCustomEvent1 != null)
        {
            onStartCustomEvent1();
        }
    }
    public static event ShowEvent onStartCustomEvent2;
    public static void StartCustomEvent2()
    {
        if(onStartCustomEvent2 != null)
        {
            onStartCustomEvent2();
        }
    }

    public static event ShowEvent onStartCustomEvent3;
    public static void StartCustomEvent3()
    {
        if(onStartCustomEvent3 != null)
        {
            onStartCustomEvent3();
        }
    }
    public static event ShowEvent onStartCustomEvent4;
    public static void StartCustomEvent4()
    {
        if(onStartCustomEvent4 != null)
        {
            onStartCustomEvent4();
        }
    }

    public static event ShowEvent onStartCustomEvent5;
    public static void StartCustomEvent5()
    {
        if(onStartCustomEvent5 != null)
        {
            onStartCustomEvent5();
        }
    }
    public static event ShowEvent onStartCustomEvent6;
    public static void StartCustomEvent6()
    {
        if(onStartCustomEvent6 != null)
        {
            onStartCustomEvent6();
        }
    }
    public static event ShowEvent onStartCustomEvent7;
    public static void StartCustomEvent7()
    {
        if(onStartCustomEvent7 != null)
        {
            onStartCustomEvent7();
        }
    }
    public static event ShowEvent onStartCustomEvent8;
    public static void StartCustomEvent8()
    {
        if(onStartCustomEvent8 != null)
        {
            onStartCustomEvent8();
        }
    }
    public static event ShowEvent onStartSpaceCamera;
    public static void StartSpaceCamera()
    {
        if(onStartSpaceCamera != null)
        {
            onStartSpaceCamera();
        }
    }
    public static event ShowEvent onToogleSpaceParticles;
    public static void ToogleSpaceParticles()
    {
        if(onToogleSpaceParticles != null)
        {
            onToogleSpaceParticles();
        }
    }
    public static event ShowEvent onStartIntroCamera;
    public static void StartIntroCamera()
    {
        if(onStartIntroCamera != null)
        {
            onStartIntroCamera();
        }
    }
    public static event ShowEvent onEnableMixer;
    public static void EnableMixer()
    {
        if(onEnableMixer != null)
        {
            onEnableMixer();
        }
    }
    public static event ShowEvent onDisableMixer;
    public static void DisableMixer()
    {
        if(onDisableMixer != null)
        {
            onDisableMixer();
        }
    }
    public static event ShowEvent onStartFireworks;
    public static void StartFireworks()
    {
        if(onStartFireworks != null)
        {
            onStartFireworks();
        }
    }

    public static event TransformValue onGetMainActiveCamera;

    public static Transform GetMainActiveCamera()
    {
        if(onGetMainActiveCamera != null)
            return onGetMainActiveCamera();
        else
            return null;
    }
}
