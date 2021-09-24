using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandParticles : MonoBehaviour
{

    public GameObject cubeDebug;

    public Transform leftPalm;
    public Transform rightPalm;

    public Flame leftFlame;
    public Flame rightflame;

    public float minRotation = 60;
    public float maxRotation = 120;

    void Update()
    {
        Debug.Log("Current Rotation: " + leftPalm.localRotation.eulerAngles.z);
        if(leftPalm.localRotation.eulerAngles.z > minRotation && leftPalm.localRotation.eulerAngles.z < maxRotation)
        {
            leftFlame.SetActive(true);
        }
        else
        {
            leftFlame.SetActive(false);

        }
        if(rightPalm.localRotation.eulerAngles.z > minRotation && rightPalm.localRotation.eulerAngles.z < maxRotation)
        {
            rightflame.SetActive(true);
        }
        else
        {
            rightflame.SetActive(false);
        }
    }

}
[System.Serializable]
public class Flame
{
    public ParticleSystem flame;
    public bool isActive;

    public void SetActive(bool state)
    {
        if(state != isActive)
        {
            isActive = state;

            if(isActive)
            {
                flame.Play();
            }
            else
            {
                flame.Stop();
            }

        }
    }
}
