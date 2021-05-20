using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardTextPro : MonoBehaviour
{
    public bool PickFromEventCamera;
    private void Update()
    {
        if (PickFromEventCamera)
        {
            transform.LookAt(GlobalEventSystem.GetMainActiveCamera());
        }
        else
        {
            //transform.rotation = Camera.main.transform.rotation;
            transform.LookAt(Camera.main.transform);
        }
    }
}
