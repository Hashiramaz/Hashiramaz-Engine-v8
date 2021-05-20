using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenHandsTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Hand"))
        {
            var explosion = Instantiate(SpawnPrefabReference.GetDefaultExplosion(),transform.position,transform.rotation,gameObject.transform.root);
            explosion.transform.localScale = gameObject.transform.localScale;
            //explosion.transform.parent = gameObject.transform.root.transform;
            var autodestroy = explosion.AddComponent<AutoDestroyInSeconds>();


            Destroy(gameObject);
        }
    }
}
