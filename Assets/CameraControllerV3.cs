using System.Collections;
using System.Collections.Generic;
using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;

public class CameraControllerV3 : MonoBehaviour
{

    public List<LeanToggle> cameras;
    public LeanToggle blackcamera;
    public Canvas cameraCanva;
    public int currentCameraSelected;

    public bool randomCamerasRuning;
    public float timeToWaitBetweenCameras;
    public LeanToggle randomCamerasButton;
    public Transform CurrentEventCamera
    {
        get
        {
            return cameras[currentCameraSelected].transform;
        }
    }

    private void OnEnable()
    {
        GlobalEventSystem.onGetMainActiveCamera += GetCurrentCameraTransform;
    }

    private void OnDisable()
    {
        GlobalEventSystem.onGetMainActiveCamera -= GetCurrentCameraTransform;
    }
    public void SetRenderCamera(Camera camera)
    {
        cameraCanva.worldCamera = camera;
    }


    public int GetRandomCamera()
    {
        int newRandomCamera = 0;

        newRandomCamera = Random.Range(0, cameras.Count);

        if (newRandomCamera == currentCameraSelected)
            newRandomCamera = GetRandomCamera();

        return newRandomCamera;
    }

    public int GetRandomFilteredCameras()
    {
        int selectedCamera = 0;

        selectedCamera = GetRandomCamera();

        return selectedCamera;
    }
    public void ActivateRandomCameras()
    {
        StopCoroutine("StartRandomCameras");

        randomCamerasRuning = true;
        StartCoroutine(StartRandomCameras());
    }


    public void ChooseCamera(int cameraIndex)
    {
        ChooseCamera(cameraIndex, false);
    }
    public void ChooseCamera(int cameraIndex, bool randomCameras = false)
    {
        currentCameraSelected = cameraIndex;

        if (!randomCameras)
        {
            StopRandomCameras();
        }

        if (cameras[cameraIndex] != null)
        {
            cameras[cameraIndex].TurnOn();

            SetRenderCamera(cameras[cameraIndex].GetComponent<Camera>());
        }

    }


    IEnumerator StartRandomCameras()
    {
        int RandomCameraToStart;

        yield return new WaitForSeconds(0.5f);

        while (randomCamerasRuning)
        {
            RandomCameraToStart = GetRandomFilteredCameras();

            ChooseCamera(RandomCameraToStart, true);

            yield return new WaitForSeconds(timeToWaitBetweenCameras);
        }

        yield return null;
    }

    public void StopRandomCameras()
    {
        if (randomCamerasRuning)
        {
            randomCamerasRuning = false;
            StopCoroutine("StartRandomCameras");
            if (randomCamerasButton.On)
                randomCamerasButton.TurnOff();
        }
    }

    public void ChooseBlackCamera()
    {
        blackcamera.TurnOn();
        StopRandomCameras();
    }
    public Transform GetCurrentCameraTransform()
    {
        return CurrentEventCamera;
    } 

    
    public void SetRandomTimeBetweenCameras(float time)
    {
        timeToWaitBetweenCameras = time;
    }
}
