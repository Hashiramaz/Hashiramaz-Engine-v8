using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamTest : MonoBehaviourSingleton<WebcamTest>
{
    // Start is called before the first frame update
    public WebCamTexture webCamTexture;
    public RenderTexture renderTexture;
    void Start()
    {
        webCamTexture = new WebCamTexture("Logitech HD Webcam C270");
        Debug.Log("Connected Webcam: "  + webCamTexture.deviceName);

    foreach (var item in WebCamTexture.devices)
    {
        Debug.Log(item.name);
    }
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webCamTexture;

        //renderTexture = (RenderTexture)renderer.material.mainTexture;
        
        

        webCamTexture.Play();

        onWebcamStarted?.Invoke();
    }

    public Action onWebcamStarted;
    // Update is called once per frame
    void Update()
    {
        
    }
}
