using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabReference : MonoBehaviourSingleton<SpawnPrefabReference>
{
    public GameObject defaultExplosion;

    public static GameObject GetDefaultExplosion()
    {
        return Instance.defaultExplosion;
    }

}
