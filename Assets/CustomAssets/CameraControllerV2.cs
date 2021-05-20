using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
public class CameraControllerV2 : MonoBehaviour
{
    public List<LeanToggle> cameras;
    public LeanToggle blackcamera;
    public int currentCameraSelected;
    public bool randomCamerasRuning;
    public float timeToWaitBetweenCameras;

    public Transform CurrentEventCamera
    {
        get
        {
            return cameras[currentCameraSelected].transform;
        }
    }


    public bool djCameras;
 
    public List<int> djcamerasIndex;
    public bool eventCameras;
    public List<int> eventCamerasIndex;
    public bool crowdCameras;
    public List<int> crowdCamerasIndex;
    public bool detailCameras;
    public List<int> detailCamerasIndex;
    public bool ADcamera;
    public List<int> ADCamerasIndex;

    public bool m_noFilteredCameras;


    public bool noFilteredCameras
    {
        get
        {
            m_noFilteredCameras = (!djCameras && !eventCameras && !crowdCameras&& !detailCameras  && !ADcamera);
            return m_noFilteredCameras;
        }
    }


    public LeanToggle randomCamerasButton;

    private void OnEnable()
    {
        GlobalEventSystem.onGetMainActiveCamera += GetCurrentCameraTransform;
    }

    private void OnDisable()
    {
        GlobalEventSystem.onGetMainActiveCamera -= GetCurrentCameraTransform;
    }

    public void SetDjCamerasState(bool state)
    {
        djCameras = state;
    }

    public void SetEventCamerasState(bool state)
    {
        eventCameras = state;
    }
    public void SetCrowdCamerasState(bool state)
    {
        crowdCameras = state;
    }
    public void SetDetailCamerasState(bool state)
    {
        detailCameras = state;
    }
    
    public void SetADCamerasState(bool state)
    {
        ADcamera = state;
    }
    public Transform GetCurrentCameraTransform()
    {
        return CurrentEventCamera;
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
        List<int> filteredIndexes = new List<int>();

        if (djCameras)
        {
            filteredIndexes.Add(djcamerasIndex.PickRandomOne());
        }

        if (eventCameras)
        {
            filteredIndexes.Add(eventCamerasIndex.PickRandomOne());
        }
        if (crowdCameras)
        {
            filteredIndexes.Add(crowdCamerasIndex.PickRandomOne());
        }
        if (detailCameras)
        {
            filteredIndexes.Add(detailCamerasIndex.PickRandomOne());
        }
        if (ADcamera)
        {
            filteredIndexes.Add(ADCamerasIndex.PickRandomOne());
        }


        if (noFilteredCameras)
        {
            selectedCamera = GetRandomCamera();
        }
        else
        {
            selectedCamera = filteredIndexes.PickRandomOne();
        }


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

    public void DeactivateCameras()
    {
        foreach (var camera in cameras)
        {
            camera.TurnOff();
        }
    }

    public void SetRandomTimeBetweenCameras(float time)
    {
        timeToWaitBetweenCameras = time;
    }
}
