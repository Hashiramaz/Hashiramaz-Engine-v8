using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Optimizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
	   // When the Menu starts, set the rendering to target 20fps
        OnDemandRendering.renderFrameInterval = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
