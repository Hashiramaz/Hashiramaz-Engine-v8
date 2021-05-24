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

    public List<TerrainGroup> terrainGroups;

    public List<int> activeTerrainGroups;
}

[System.Serializable]
public class TerrainGroup{
public List<MoveTerrain> terrainsPrefab;

public MoveTerrain GetRandomTerrain()
{
    return terrainsPrefab.PickRandomOne();
}
}
