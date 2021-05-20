using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviourSingleton<TerrainSpawner>
{
    public List<MoveTerrain> terrainsPrefab;


    public void SpawnNewTerrain()
    {
        var terrainToSpawn = terrainsPrefab.PickRandomOne();

        Instantiate(terrainToSpawn,transform.position,transform.rotation);
    }
}
