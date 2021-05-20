using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRawInput;

public class CameraGroupController : MonoBehaviour
{
    public List<CPC_CameraPath> CameraPaths;

    public bool inputsRunInBackGround;
    public bool randomCamerasRuning;

    public int currentCameraSelected;
    public float timeToWaitBetweenCameras = 5f;

    public Light FlashLight;
    public bool FlashTurnOn;

    public float flashFrequency = 0.05f;

    private void Start() {
        RawKeyInput.Start(true);
    }
    private void Update() {
//        if(Input.GetKeyDown(KeyCode.Q))
        if(RawKeyInput.IsKeyDown(RawKey.Q))
        {
            PlayPath(0);
        }

        //if(Input.GetKeyDown(KeyCode.W))
        if(RawKeyInput.IsKeyDown(RawKey.W))
        {
            PlayPath(1);

        }
        //if(Input.GetKeyDown(KeyCode.E))
        if(RawKeyInput.IsKeyDown(RawKey.E))
        {
            PlayPath(2);
        }

        //if(Input.GetKeyDown(KeyCode.R))
        if(RawKeyInput.IsKeyDown(RawKey.R))
        {
            PlayPath(3);
        }
        //if(Input.GetKeyDown(KeyCode.T))
        if(RawKeyInput.IsKeyDown(RawKey.T))
        {
            PlayPath(4);
        }

        //if(Input.GetKeyDown(KeyCode.Y))
        if(RawKeyInput.IsKeyDown(RawKey.Y))
        {
            PlayPath(5);
        }

        

        if(RawKeyInput.IsKeyDown(RawKey.A))
        {
            Toogle();
        }
        
        if(RawKeyInput.IsKeyDown(RawKey.S))
        {
            ActivateRandomCameras();
        }
        
        if(RawKeyInput.IsKeyDown(RawKey.L))
        {
            ToogleFlash();
        }
        if(RawKeyInput.IsKeyDown(RawKey.I))
        {
            SetFlashFrequency(0.01f);
        }
        if(RawKeyInput.IsKeyDown(RawKey.O))
        {
            SetFlashFrequency(0.05f);
        }
        if(RawKeyInput.IsKeyDown(RawKey.P))
        {
            SetFlashFrequency(0.1f);
        }
        if(RawKeyInput.IsKeyDown(RawKey.K))
        {
            StopFlash();
        }
        
        
        
        




    }


public void ActivateRandomCameras()
{
    StopCoroutine("StartRandomCameras");
    
    randomCamerasRuning = true;
    StartCoroutine(StartRandomCameras());
}

public void SetFlashFrequency(float frequency)
{
    flashFrequency = frequency;
}
public void ToogleFlash()
{

    if(!FlashTurnOn)
    {
        FlashTurnOn = true;
        StartCoroutine(FlashRoutine());
    }
    

}
public void StopFlash()
{   
        FlashTurnOn = false;
        StopCoroutine("FlashRoutine");
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
public void StopRandomCameras()
{
    if(randomCamerasRuning){
        randomCamerasRuning = false;
        StopCoroutine("StartRandomCameras");

    }
}
IEnumerator StartRandomCameras()
{
     int RandomCameraToStart;

        while(randomCamerasRuning)
        {
            RandomCameraToStart = GetRandomCamera();
            
            yield return new WaitForSeconds(0.5f);
            PlayPath(RandomCameraToStart,true);
            
            yield return new WaitForSeconds(timeToWaitBetweenCameras);
        }

     yield return null;
}


    public int GetRandomCamera()
    {
        int newRandomCamera = 0;

        newRandomCamera = Random.Range(0,CameraPaths.Count);
        
        if(newRandomCamera == currentCameraSelected)
            newRandomCamera = GetRandomCamera();

        return newRandomCamera;
    }

    public void Toogle()
    {
        if(RawKeyInput.IsRunning)
            RawKeyInput.Stop();
        
        inputsRunInBackGround = !inputsRunInBackGround;
        RawKeyInput.Start(inputsRunInBackGround);

    }

    public void PlayPath(int pathIndex)
    {
        PlayPath(pathIndex,false);
    }
    public void PlayPath(int pathIndex, bool randomCameras)
    {
        currentCameraSelected = pathIndex;

        if(!randomCameras)
        {
            StopRandomCameras();
        }

        if(CameraPaths[pathIndex] != null)
        {
            
            CameraPaths[pathIndex].selectedCamera.gameObject.SetActive(true);
            CameraPaths[pathIndex].PlayPath(CameraPaths[pathIndex].playOnAwakeTime);
        
          for (int i = 0; i < CameraPaths.Count; i++)
          {
              if(i != pathIndex)
              {
                  CameraPaths[i].selectedCamera.gameObject.SetActive(false);
              }
          }

        }
    }   

    private void OnDisable() {
        RawKeyInput.Stop();
    }
}
