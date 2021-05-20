using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData : MonoBehaviourSingletonPersistent<StageData>
{
    public float terrainSpeed = 5f;

    public static float GetTerrainSpeed()
    {
        return Instance.terrainSpeed * Instance.terrainSpeedMultiplier;
    }

    [SerializeField]
    private float m_terrainSpeedMultiplier;
    public float terrainSpeedMultiplier{
        get{
            return m_terrainSpeedMultiplier;
        }
        set{

            m_terrainSpeedMultiplier = value;
        }
    }
}
