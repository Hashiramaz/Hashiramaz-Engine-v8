using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeController : MonoBehaviour
{
    public Animator anim
    {
        get
        {
            if (m_anim == null)
                m_anim = GetComponent<Animator>();
            return m_anim;
        }
    }
    public Animator m_anim;



    public void StartPattern1()
    {

    }

    public void StartPattern2()
    {

    }
    public void StartPattern3()
    {
        
    }
}
