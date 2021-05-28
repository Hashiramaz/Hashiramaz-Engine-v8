using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EmotesSpawnManager : MonoBehaviourSingleton<EmotesSpawnManager>
{
    public EmoteBehaviour emotePrefab;

    public SpawnArea spawnArea;
    public List<SpawnArea> spawnAreas;

    public bool blockEmotes;

    public bool attachToParent;
    public Transform parentToAttatch;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SpawnEmote(CachedEmotesManager.Instance.GetEmote("FeelsBadMan"));
        }
    }

    public void SpawnEmote()
    {
        EmoteBehaviour emoteSpawned = Instantiate(emotePrefab,GetRandomSpawnArea().GetRandomPoint(),transform.rotation);

        emoteSpawned.StartEmoteCycle();
    }

    public void SpawnEmote(EmoteCacheData emoteData)
    {
        if(blockEmotes)
            return;
        
        EmoteBehaviour emoteSpawned = Instantiate(emotePrefab,GetRandomSpawnArea().GetRandomPoint(),transform.rotation);
        
        if(attachToParent)
            emoteSpawned.transform.SetParent(parentToAttatch);
        //EmoteBehaviour emoteSpawned = LeanPool.Spawn(emotePrefab,spawnArea.GetRandomPoint(),transform.rotation);
        emoteSpawned.SetData(emoteData);

        emoteSpawned.StartEmoteCycle();
    }

    public void SetBlockEmotesState(bool state)
    {
        blockEmotes = state;
    }

    public bool randomSpawnPoint;
    public SpawnArea GetRandomSpawnArea()
    {
        if(randomSpawnPoint)
        return spawnAreas.PickRandomOne();
        else return spawnArea;

    }
}
