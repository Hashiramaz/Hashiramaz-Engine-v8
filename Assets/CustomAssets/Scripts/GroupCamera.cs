using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCamera : MonoBehaviour
{
    public List<CPC_CameraPath> CameraPaths;

    public bool randomCamerasRuning;

    public int currentCameraSelected;
    public float timeToWaitBetweenCameras = 5f;

    public CPC_CameraPath spacePath;

    private void OnEnable()
    {
        GlobalEventSystem.onStartCustomCamera1 += PlayCamera1;
        GlobalEventSystem.onStartCustomCamera2 += PlayCamera2;
        GlobalEventSystem.onStartCustomCamera3 += PlayCamera3;
        GlobalEventSystem.onStartCustomCamera4 += PlayCamera4;
        GlobalEventSystem.onStartCustomCamera5 += PlayCamera5;
        GlobalEventSystem.onStartCustomCamera6 += PlayCamera6;

        GlobalEventSystem.onStartRandomCameras += OnPlayRandomCameras;
        GlobalEventSystem.onStopRandomCameras  += OnStopRandomCameras;

        GlobalEventSystem.onStartSpaceCamera += PlaySpacePath;
    }

    private void OnDisable()
    {
        GlobalEventSystem.onStartCustomCamera1 -= PlayCamera1;
        GlobalEventSystem.onStartCustomCamera2 -= PlayCamera2;
        GlobalEventSystem.onStartCustomCamera3 -= PlayCamera3;
        GlobalEventSystem.onStartCustomCamera4 -= PlayCamera4;
        GlobalEventSystem.onStartCustomCamera5 -= PlayCamera5;
        GlobalEventSystem.onStartCustomCamera6 -= PlayCamera6;

        GlobalEventSystem.onStartRandomCameras -= OnPlayRandomCameras;
        GlobalEventSystem.onStopRandomCameras  -= OnStopRandomCameras;
        
        GlobalEventSystem.onStartSpaceCamera -= PlaySpacePath;
    }



    public void PlayPath(int pathIndex)
    {
        PlayPath(pathIndex, false);
    }

    public void PlayPath(int pathIndex, bool randomCameras)
    {
        DeactivateSpacePath();

        currentCameraSelected = pathIndex;

        if (!randomCameras)
        {
            StopRandomCameras();
        }

        if (pathIndex < CameraPaths.Count)
        {

            CameraPaths[pathIndex].selectedCamera.gameObject.SetActive(true);
            CameraPaths[pathIndex].PlayPath(CameraPaths[pathIndex].playOnAwakeTime);

            for (int i = 0; i < CameraPaths.Count; i++)
            {
                if (i != pathIndex)
                {
                    CameraPaths[i].selectedCamera.gameObject.SetActive(false);
                }
            }

        }
    }


    public void ActivateRandomCameras()
    {
        StopCoroutine("StartRandomCameras");

        randomCamerasRuning = true;
        StartCoroutine(StartRandomCameras());
    }


    public void StopRandomCameras()
    {
        if (randomCamerasRuning)
        {
            randomCamerasRuning = false;
            StopCoroutine("StartRandomCameras");

        }
    }


    IEnumerator StartRandomCameras()
    {
        int RandomCameraToStart;

        while (randomCamerasRuning)
        {
            RandomCameraToStart = GetRandomCamera();

            yield return new WaitForSeconds(0.5f);
            PlayPath(RandomCameraToStart, true);

            yield return new WaitForSeconds(timeToWaitBetweenCameras);
        }

        yield return null;
    }

    public int GetRandomCamera()
    {
        int newRandomCamera = 0;

        newRandomCamera = Random.Range(0, CameraPaths.Count);

        if (newRandomCamera == currentCameraSelected)
            newRandomCamera = GetRandomCamera();

        return newRandomCamera;
    }

    #region CALLBACKS

    public void PlayCamera1()
    {
        PlayPath(0);
    }
    public void PlayCamera2()
    {
        PlayPath(1);

    }
    public void PlayCamera3()
    {
        PlayPath(2);

    }
    public void PlayCamera4()
    {
        PlayPath(3);

    }
    public void PlayCamera5()
    {
        PlayPath(4);

    }

    private void PlayCamera6()
    {
         PlayPath(5);
    }
    public void PlaySpacePath()
    {
        spacePath.selectedCamera.gameObject.SetActive(true);
        spacePath.PlayPath(spacePath.playOnAwakeTime);

        for (int i = 0; i < CameraPaths.Count; i++)
            {
               
                CameraPaths[i].selectedCamera.gameObject.SetActive(false);
                
            }
    }    

    public void DeactivateSpacePath()
    {
        spacePath.selectedCamera.gameObject.SetActive(false);
    }

    public void PlayIntroCamera()
    {
        
    }




    public void OnPlayRandomCameras()
    {
        ActivateRandomCameras();
    }
    public void OnStopRandomCameras()
    {
        StopRandomCameras();
    }
    #endregion
}
