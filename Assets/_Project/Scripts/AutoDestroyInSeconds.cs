using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
public class AutoDestroyInSeconds : MonoBehaviour
{
    public float timeToDestroy = 7f;
    public bool despawnFromLean;

    private void Start()
    {

        StartCoroutine(AutoDestroyIn(timeToDestroy));
    }



    IEnumerator AutoDestroyIn(float _time)
    {
        yield return new WaitForSeconds(_time);
        transform.SendMessage("Die", SendMessageOptions.DontRequireReceiver);
        if (!despawnFromLean)
            Destroy(gameObject);
        else
            LeanPool.Despawn(gameObject);
    }

    public void AutoDestroy()
    {
        if (!despawnFromLean)
            Destroy(gameObject);
        else
            LeanPool.Despawn(gameObject);
    }
}
