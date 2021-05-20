using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageColector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Terrain"))
            Destroy(other.transform.root.gameObject);
    }
}
