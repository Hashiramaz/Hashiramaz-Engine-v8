using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRawInput;


public class InputsController : MonoBehaviour
{
    //public static InputsController instance;

    public bool inputsRunInBackGround;




    private void Awake()
    {
        // if (instance == null)
        //     instance = this;

        // if (instance == this)
        //     DontDestroyOnLoad(this.gameObject);
        // else
        //     Destroy(gameObject);

    }



    private void Start()
    {
        
    }

    private void OnEnable() {
        RawKeyInput.Start(true);
        RawKeyInput.OnKeyDown += OnKeyDown;
    }

    private void OnDisable() {
        RawKeyInput.OnKeyDown -= OnKeyDown;
        RawKeyInput.Stop();
    }
    private void Update()
    {
        
        

    }


    public void OnKeyDown(RawKey key)
    {
        if(key == RawKey.G)
            Debug.Log("Key Pressed");


        //Cameras
        if (key == (RawKey.Q))
            GlobalEventSystem.StartCustomCamera1();

        if (key == (RawKey.W))
            GlobalEventSystem.StartCustomCamera2();

        if (key == (RawKey.E))
            GlobalEventSystem.StartCustomCamera3();

        if (key == (RawKey.R))
            GlobalEventSystem.StartCustomCamera4();

        if (key == (RawKey.T))
            GlobalEventSystem.StartCustomCamera5();
        
        if (key == (RawKey.Y))
            GlobalEventSystem.StartCustomCamera6();
        
        if (key == (RawKey.U))
            GlobalEventSystem.StartCustomCamera7();
        
        if (key == (RawKey.I))
            GlobalEventSystem.StartCustomCamera8();
        
        if (key == (RawKey.O))
            GlobalEventSystem.StartCustomCamera9();

        //Random Cameras
        if (key == (RawKey.S))
            GlobalEventSystem.StartRandomCameras();

        //Lights Turn On/Off
        if (key == (RawKey.L)){
            GlobalEventSystem.StartTurnOnLights();
            Debug.Log("Key G Pressed");
            //lightFlash.ToogleLight();
        }
            
        if (key == (RawKey.K))
            GlobalEventSystem.StartTurnOffLights();


        // if(key == RawKey.P)
        //     GlobalEventSystem.SetLightsPattern3();
        
        // if(key == RawKey.O)
        //     GlobalEventSystem.SetLightsPattern2();


        //Toogle Inputs On/Off
        if (key == (RawKey.A))
            Toogle();
      
        
        
        
        //CustomEvents
        if (key == (RawKey.Z))
            GlobalEventSystem.StartCustomEvent1();

        if (key == (RawKey.X))
            GlobalEventSystem.StartCustomEvent2();

        if (key == (RawKey.C))
            GlobalEventSystem.StartCustomEvent3();

        if (key == (RawKey.V))
            GlobalEventSystem.StartCustomEvent4();

        if (key == (RawKey.B))
            GlobalEventSystem.StartCustomEvent5();

        if (key == (RawKey.N))
            GlobalEventSystem.StartCustomEvent6();
            
        if (key == (RawKey.M))
            GlobalEventSystem.StartCustomEvent7();


        if(key == RawKey.H)
            GlobalEventSystem.StartSpaceCamera();
        
        if(key == RawKey.G)
            GlobalEventSystem.ToogleSpaceParticles();

        if(key == RawKey.F)
            GlobalEventSystem.StartIntroCamera();
        
        if(key == RawKey.U)
            GlobalEventSystem.StartFireworks();


        if(key == RawKey.N)
            GlobalEventSystem.EnableMixer();
        
        if(key == RawKey.M)
            GlobalEventSystem.DisableMixer();

    }


    public void Toogle()
    {
        if (RawKeyInput.IsRunning)
            RawKeyInput.Stop();

        inputsRunInBackGround = !inputsRunInBackGround;
        RawKeyInput.Start(inputsRunInBackGround);

    }


    

}
