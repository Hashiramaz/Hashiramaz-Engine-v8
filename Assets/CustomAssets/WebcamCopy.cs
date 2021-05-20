using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamCopy : MonoBehaviour
{
    private void OnEnable() {
        
        WebcamTest.Instance.onWebcamStarted += CloneWebcam;
    }

    private void OnDisable() {
        WebcamTest.Instance.onWebcamStarted -= CloneWebcam;
    }

    public void CloneWebcam()
    {
        StartCoroutine(ClonewebcamRoutine());
    }
    public IEnumerator ClonewebcamRoutine()
    {
        yield return new WaitForEndOfFrame();
        
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = WebcamTest.Instance.webCamTexture;
    }
}
