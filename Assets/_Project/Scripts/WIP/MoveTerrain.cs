using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTerrain : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position +=   new Vector3(StageData.GetTerrainSpeed() * Time.deltaTime,0,0);
    }

    
}
