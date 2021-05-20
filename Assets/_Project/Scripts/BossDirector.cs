using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
public class BossDirector : MonoBehaviour
{
    [Header("Intro")]
    public AudioSource introAudio;

    public TimelineAsset introTimeline;

    public PlayableDirector director;

    public CameraControllerV2 cameraControllerV2;

    public List<PlayableDirector> dropCameras;


    public void PlayIntro()
    {
        cameraControllerV2.DeactivateCameras();

        introAudio.Stop();
        director.playableAsset = introTimeline;
        director.Play();
    } 

    public void ReturnNormalCameras()
    {
        cameraControllerV2.ChooseCamera(0);
    }

    public void PlayDropCamera(int dropCameraIndex)
    {
        cameraControllerV2.DeactivateCameras();
        dropCameras[dropCameraIndex].Play();
    }

    public void PlayRandomDropCamera()
    {
        PlayDropCamera(Random.Range(0,dropCameras.Count));
    }
}
