using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTrigger : MonoBehaviour
{

   private void OnTriggerEnter(Collider other) {
       if(other.CompareTag("Terrain"))
       {
       Debug.Log("Entrou: " + other);
           TerrainSpawner.Instance.SpawnNewTerrain();
       }
   }
}
