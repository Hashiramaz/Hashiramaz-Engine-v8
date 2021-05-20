using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRawInput;
public class CamerasController : MonoBehaviour
{
    public CinematicCamera[] cinematicCameras;
    private int currentCameraSelected;
    private bool randomCamerasRuning;
    private float timeToWaitBetweenCameras = 5f;

    private void OnEnable()
    {
        GlobalEventSystem.onStartCustomCamera1 += OnStartCamera1;
        GlobalEventSystem.onStartCustomCamera2 += OnStartCamera2;
        GlobalEventSystem.onStartCustomCamera3 += OnStartCamera3;
        GlobalEventSystem.onStartCustomCamera4 += OnStartCamera4;
        GlobalEventSystem.onStartCustomCamera5 += OnStartCamera5;
        GlobalEventSystem.onStartCustomCamera6 += OnStartCamera6;
        GlobalEventSystem.onStartCustomCamera7 += OnStartCamera7;
        GlobalEventSystem.onStartCustomCamera8 += OnStartCamera8;
        GlobalEventSystem.onStartCustomCamera9 += OnStartCamera9;
        GlobalEventSystem.onStartRandomCameras += OnStartRandomCameras;
    }

    private void OnDisable()
    {
        GlobalEventSystem.onStartCustomCamera1 -= OnStartCamera1;
        GlobalEventSystem.onStartCustomCamera2 -= OnStartCamera2;
        GlobalEventSystem.onStartCustomCamera3 -= OnStartCamera3;
        GlobalEventSystem.onStartCustomCamera4 -= OnStartCamera4;
        GlobalEventSystem.onStartCustomCamera5 -= OnStartCamera5;
        GlobalEventSystem.onStartCustomCamera6 -= OnStartCamera6;
        GlobalEventSystem.onStartRandomCameras -= OnStartRandomCameras;
        GlobalEventSystem.onStartCustomCamera7 -= OnStartCamera7;
        GlobalEventSystem.onStartCustomCamera8 -= OnStartCamera8;
        GlobalEventSystem.onStartCustomCamera9 -= OnStartCamera9;
    }

    private void OnStartCamera1()
    {
        StartCamera(0);
    }
    private void OnStartCamera2()
    {
        StartCamera(1);
    }
    private void OnStartCamera3()
    {
        StartCamera(2);
    }
    private void OnStartCamera4()
    {
        StartCamera(3);
    }
    private void OnStartCamera5()
    {
        StartCamera(4);
    }
    private void OnStartCamera6()
    {
        StartCamera(5);
    }
    private void OnStartCamera7()
    {
        StartCamera(6);
    }
    private void OnStartCamera8()
    {
        StartCamera(7);
    }
    private void OnStartCamera9()
    {
        StartCamera(8);
    }


    public void OnStartRandomCameras()
    {
        ActivateRandomCameras();
    }

    public void StartCamera(int cameraIndex)
    {
        if(cameraIndex >= cinematicCameras.Length)
            return;
        
        StopRandomCameras();
        
        currentCameraSelected  = cameraIndex;

        GetCinematicCamera(cameraIndex).StartCamera();

    }
    public void StartCamera(int cameraIndex, bool randomCamera)
    {
        if(!randomCamera)
            StopRandomCameras();
        
        if(cameraIndex >= cinematicCameras.Length)
            return;
        
        currentCameraSelected  = cameraIndex;
        
        GetCinematicCamera(cameraIndex).StartCamera();
        
    }

    public CinematicCamera GetCinematicCamera(int cameraIndex)
    {
        return cinematicCameras[cameraIndex];
    }

    public int GetRandomCameraIndex()
    {
        int newRandomCamera = 0;

        newRandomCamera = UnityEngine.Random.Range(0, cinematicCameras.Length);

        if (newRandomCamera == currentCameraSelected)
            newRandomCamera = GetRandomCameraIndex();

        return newRandomCamera;
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
            RandomCameraToStart = GetRandomCameraIndex();

            yield return new WaitForSeconds(0.5f);
            
            StartCamera(RandomCameraToStart,true);

            yield return new WaitForSeconds(timeToWaitBetweenCameras);
        }

        yield return null;
    }
}
