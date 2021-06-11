using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviourSingleton<TerrainSpawner>
{

    private void OnEnable() {
        GlobalEventSystem.onSelectTerrain += ActivateTerrainGroup;
        GlobalEventSystem.onDeselectTerrain += RemoveTerrainGroup;

    }

    private void OnDisable() {
        GlobalEventSystem.onSelectTerrain -= ActivateTerrainGroup;
        GlobalEventSystem.onDeselectTerrain -= RemoveTerrainGroup;
        
    }
    public List<MoveTerrain> terrainsPrefab;

    public bool pickFromTerrainGroup;
    public void SpawnNewTerrain()
    {
        var terrainToSpawn = GetTerrainToSpawn();

        Instantiate(terrainToSpawn, transform.position, transform.rotation);
    }


    public MoveTerrain GetTerrainToSpawn()
    {
        MoveTerrain terrain = new MoveTerrain();

        if(pickFromTerrainGroup && activeTerrainGroups.Count > 0)
        {
            int terrainGroupIndex = GetRandomTerrainGroupIndex();
            terrain = terrainGroups[terrainGroupIndex].GetRandomTerrain();
        }
        else
        {
            terrain = terrainsPrefab.PickRandomOne();
        }

        return terrain;
    }


    public List<TerrainGroup> terrainGroups;

    public List<int> activeTerrainGroups;

    public void ActivateTerrainGroup(int groupIndex)
    {
        if(!activeTerrainGroups.Contains(groupIndex))
        {
            activeTerrainGroups.Add(groupIndex);
        }
    }

    public void RemoveTerrainGroup(int groupIndex)
    {
        if(activeTerrainGroups.Contains(groupIndex))
        {
            activeTerrainGroups.Remove(groupIndex);
        }
    }

    public int GetRandomTerrainGroupIndex()
    {
        return activeTerrainGroups.PickRandomOne();
    }

    public TerrainGroup GetTerrainGroup(int groupIndex)
    {
        return terrainGroups[groupIndex];
    }
}

[System.Serializable]
public class TerrainGroup
{
    public List<MoveTerrain> terrainsPrefab;

    public MoveTerrain GetRandomTerrain()
    {
        return terrainsPrefab.PickRandomOne();
    }
}
