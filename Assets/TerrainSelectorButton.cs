using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSelectorButton : MonoBehaviour
{
    public int terrainIndex;

    public void Select()
    {
        SelectTerrain(terrainIndex);
    }

    public void Deselect()
    {
        DeselectTerrain(terrainIndex);
    }

    public void SelectTerrain(int _terrainIndex)
    {
        GlobalEventSystem.SelectTerrain(_terrainIndex);
    }

    public void DeselectTerrain(int _terrainIndex)
    {
        GlobalEventSystem.DeselectTerrain(_terrainIndex);
    }
}
