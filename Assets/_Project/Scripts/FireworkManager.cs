using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class FireworkManager : MonoBehaviour
{
    public bool fireworksEnabled;

    public Firework[] fireworks;

    public SpawnArea[] spawnAreas;

    public bool spawnFromLean;
        public float timeBetweenFireworks = 0.1f;
    private void OnEnable()
    {
        GlobalEventSystem.onStartCustomEvent1 += SpawnFirework;
        GlobalEventSystem.onStartCustomEvent2 += ToggleFireworks;
    }

    private void OnDisable()
    {
        GlobalEventSystem.onStartCustomEvent1 -= SpawnFirework;
        GlobalEventSystem.onStartCustomEvent2 -= ToggleFireworks;

    }

    public void SpawnFirework()
    {
        Debug.Log("Firework Spawned");
            Firework fireworkSpawned;
        
        if(!spawnFromLean)
             fireworkSpawned = Instantiate(fireworks.PickRandomOne(),spawnAreas.PickRandomOne().GetRandomPoint(),transform.rotation);
            else
             fireworkSpawned = LeanPool.Spawn(fireworks.PickRandomOne(),spawnAreas.PickRandomOne().GetRandomPoint(),transform.rotation);



    }
    public void ToggleFireworks()
    {
        fireworksEnabled = !fireworksEnabled;

        if (fireworksEnabled)
        {
            Debug.Log("Fireworks Enabled");
            StartCoroutine(FireworksRoutine());
        }
        else
        {
            Debug.Log("Fireworks Disabled");
            StopCoroutine(FireworksRoutine());

        }
    }
    public void SetFireworksState(bool state)
    {
        if(state == fireworksEnabled)
            return;
        
        fireworksEnabled = state;

        if (fireworksEnabled)
        {
            Debug.Log("Fireworks Enabled");
            StartCoroutine(FireworksRoutine());
        }
        else
        {
            Debug.Log("Fireworks Disabled");
            StopCoroutine(FireworksRoutine());

        }
    }

    IEnumerator FireworksRoutine()
    {
        while (fireworksEnabled)
        {
            yield return new WaitForSeconds(timeBetweenFireworks);

            SpawnFirework();

        }

        yield return null;
    }

}
