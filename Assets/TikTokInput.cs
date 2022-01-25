using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TikTokInput : MonoBehaviour
{
    public UnityEvent stopCamera;

    public UnityEvent moveCamera;

    public UnityEvent dropButton;

    public UnityEvent stopDrop;

   private void Update() {
       if(Input.GetKeyDown(KeyCode.H))
       {
           stopCamera.Invoke();
           stopDrop.Invoke();

       }

       if(Input.GetKeyDown(KeyCode.J))
       {
           moveCamera.Invoke();
       }
       if(Input.GetKeyDown(KeyCode.K))
       {
        dropButton.Invoke();
       }
   }
}
