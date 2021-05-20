using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimatorRandomizer : MonoBehaviour
{
    Animator animar;
    // Start is called before the first frame update
    void Start()
    {
       animar = GetComponent<Animator>() ;
       
       float randomTime = Random.Range(0f,10f);
       
       Invoke("StartAnimation",randomTime);
    }

    public void StartAnimation(){
       animar.SetTrigger("StartAnimation");

    }

   
}
