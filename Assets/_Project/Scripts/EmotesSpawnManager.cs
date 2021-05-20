using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class EmotesSpawnManager : MonoBehaviourSingleton<EmotesSpawnManager>
{
    public EmoteBehaviour emotePrefab;

    public SpawnArea spawnArea;

    public bool blockEmotes;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SpawnEmote(CachedEmotesManager.Instance.GetEmote("FeelsBadMan"));
        }
    }

    public void SpawnEmote()
    {
        EmoteBehaviour emoteSpawned = Instantiate(emotePrefab,spawnArea.GetRandomPoint(),transform.rotation);

        emoteSpawned.StartEmoteCycle();
    }

    public void SpawnEmote(EmoteCacheData emoteData)
    {
        if(blockEmotes)
            return;
        
        EmoteBehaviour emoteSpawned = Instantiate(emotePrefab,spawnArea.GetRandomPoint(),transform.rotation);
        //EmoteBehaviour emoteSpawned = LeanPool.Spawn(emotePrefab,spawnArea.GetRandomPoint(),transform.rotation);
        emoteSpawned.SetData(emoteData);

        emoteSpawned.StartEmoteCycle();
    }

    public void SetBlockEmotesState(bool state)
    {
        blockEmotes = state;
    }
}
