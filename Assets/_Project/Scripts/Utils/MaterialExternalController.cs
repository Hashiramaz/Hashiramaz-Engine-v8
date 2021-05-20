using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialExternalController : MonoBehaviour
{
    
    public float Intensity { get => intensity; set => intensity = value; }
    private float intensity;

    public Material materialSelected;


            public Color materialColor
        {
            set{
                materialSelected.SetColor("_EmissionColor", value * intensity);
            }
        }
}
