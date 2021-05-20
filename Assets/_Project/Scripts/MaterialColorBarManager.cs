using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorBarManager : MonoBehaviour
{
    private float highIntensity;
    private float mediumIntensity;
    private float lowIntensity;

    public Color mediumColor
        {
            set{
                materialMedium.SetColor("_EmissionColor", value * MediumIntensity);
            }
        }
        public Color highColor
        {
            set{
                materialHigh.SetColor("_EmissionColor", value * HighIntensity);
            }
        }
        public Color LowColor
        {
            set{
                materialLow.SetColor("_EmissionColor", value * LowIntensity);
            }
        }

    public float HighIntensity { get => highIntensity; set => highIntensity = value; }
    public float MediumIntensity { get => mediumIntensity; set => mediumIntensity = value; }
    public float LowIntensity { get => lowIntensity; set => lowIntensity = value; }

    public Material materialMedium;
        public Material materialHigh;
        public Material materialLow;
        

}
