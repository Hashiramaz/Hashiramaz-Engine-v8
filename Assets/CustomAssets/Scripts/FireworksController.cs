using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksController : MonoBehaviour
{
   public List<ParticleSystem> fireworks;


   public bool fireworksEnabled;


    private void OnEnable() {
        GlobalEventSystem.onStartFireworks += ToogleFireworks;
    }

    private void OnDisable() {
        
        GlobalEventSystem.onStartFireworks -= ToogleFireworks;
    }


   public void ToogleFireworks()
   {
       fireworksEnabled = !fireworksEnabled;

        if(fireworksEnabled)
            StartFirewords();
            else
            {
                StopFireworks();
            }

   }


    public void StartFirewords()
    {
        StartCoroutine(FireworkdsRoutine());
    }
   IEnumerator FireworkdsRoutine()
   {
       while (fireworksEnabled)
       {
           yield return new WaitForSeconds(0.1f);

           int randomFirworkds = Random.Range(0,fireworks.Count);

           fireworks[randomFirworkds].Play();
       }
   }


   public void StopFireworks()
   {
       StopCoroutine("FireworkdsRoutine");
   }    
}
