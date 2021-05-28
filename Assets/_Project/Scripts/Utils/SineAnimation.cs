using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SineAnimation : MonoBehaviour
{
    public Vector3 positionDisplacement;
    public Vector3 positionOrigin;
    private float _timePassed;
    public float timeSine = 1;

    public bool randomBasedOnInitialValues;
    private void Start()
    {
        positionOrigin = transform.localPosition;

        if(randomBasedOnInitialValues)
        {
            float x = Random.Range(0,positionDisplacement.x);
            float y = Random.Range(0,positionDisplacement.y);
            float z = Random.Range(0,positionDisplacement.z);
          
            positionDisplacement = new Vector3(x,y,z);

            float timeRandom = Random.Range(1,timeSine);
            timeSine = timeRandom;
        }
    }

    private void Update()
    {
        _timePassed += Time.deltaTime/timeSine;
        transform.localPosition = Vector3.Lerp(positionOrigin, positionOrigin + positionDisplacement,
            Mathf.PingPong(_timePassed, 1));
    }

}
