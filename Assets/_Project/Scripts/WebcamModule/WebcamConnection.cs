using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class WebcamConnection : MonoBehaviourSingleton<WebcamConnection>
{
    public RenderTexture webcamRenderTexture;

    private WebCamTexture webCamTexture;

    public GameObject webcamRenderer;
    public Action onWebcamStarted;

    public Dropdown webcamDropdown;
    public string webcamSelectedName;

    public Material webcamChromaMaterial;
    void Start()
    {
        SelectWebcam("Logitech HD Webcam C270");

        UpdateDropdown();
    }
#region  DEVICE SELECTION
    public void SelectWebcam(string webcamDeviceName)
    {
        webcamSelectedName = webcamDeviceName;

        webCamTexture = new WebCamTexture(webcamDeviceName);

        Renderer renderer = webcamRenderer.GetComponent<Renderer>();

        renderer.material.mainTexture = webCamTexture;

        webCamTexture.Play();

        onWebcamStarted?.Invoke();
    }

    public void UpdateDropdown()
    {
        webcamDropdown.ClearOptions();

        WebCamDevice[] webCams = WebCamTexture.devices;

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        int selectedIndex = 0;
        for (int i = 0; i < webCams.Length; i++)
        {
            string webcamDeviceName = webCams[i].name;
            Dropdown.OptionData optionData = new Dropdown.OptionData(webcamDeviceName);

            options.Add(optionData);

            if (webcamDeviceName == webcamSelectedName)
                selectedIndex = i;

        }

        webcamDropdown.AddOptions(options);

        webcamDropdown.SetValueWithoutNotify(selectedIndex);
    }

    public void SelectOption(string webcamName)
    {
        SelectWebcam(webcamName);
    }

    public void SetOption(int targetIndex)
    {
        webCamTexture.Stop();
        
        List<Dropdown.OptionData> options = webcamDropdown.options;

        SelectWebcam(options[targetIndex].text);

    }
#endregion

#region CONFIG VALUES


    public void SetBrightness(float value)
    {
        Debug.Log("Setting brightness: " + value);        
        webcamChromaMaterial.SetFloat("_ChromaKeyBrightnessRange",value);
    }
    public void SetHueRange(float value)
    {
        Debug.Log("Setting Hue Range: " + value);
        webcamChromaMaterial.SetFloat("_ChromaKeyHueRange",value);        
    }
    public void SetSaturation(float value)
    {
        Debug.Log("Setting Saturation: " + value);        
        webcamChromaMaterial.SetFloat("_ChromaKeySaturationRange",value);
        
    }
    public void SetChromaColor(Color colorPicked)
    {
        webcamChromaMaterial.SetColor("_ChromaKeyColor",colorPicked);
    }
#endregion

    public void SetDefaultValues()
    {

    }

    public void LoadSavedValuesOnInterface()
    {

    }

}
