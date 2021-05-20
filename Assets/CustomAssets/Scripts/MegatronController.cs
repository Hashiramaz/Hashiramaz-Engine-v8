using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegatronController : MonoBehaviour
{
    public Vector3 initialPosition;
    public Vector3 initialRotation;

    public Animator anim{
        get{
            if(m_anim == null)
            m_anim = GetComponent<Animator>();
            return m_anim;
        }
    }
    public Animator m_anim;


    private void OnEnable() {
        GlobalEventSystem.onStartCustomEvent1 += StartAnimation;
        GlobalEventSystem.onStartCustomEvent2 += StopAnimation;
    }

    private void OnDisable() {
        GlobalEventSystem.onStartCustomEvent1 -= StartAnimation;
        GlobalEventSystem.onStartCustomEvent2 -= StopAnimation;
        
    }

    private void Start() {
        initialPosition = transform.localPosition; 
        initialRotation = transform.localRotation.eulerAngles;
    }
    public void ResetState()
    {
        gameObject.transform.localPosition = initialPosition;
        gameObject.transform.localRotation = Quaternion.Euler(initialRotation);
    }

    public void StartAnimation()
    {
        //ResetState();
        Debug.Log("sTART aNIMARION"); 
        GlobalEventSystem.StartCustomCamera3();
        anim.SetBool("EnterAnim",true);
        Invoke("SetTriggerFalse",0.1f);
    }
    public void SetTriggerFalse()
    {
        anim.SetBool("EnterAnim",false);
        anim.SetBool("ExitAnim",false);

    }

    public void StopAnimation(){
        
        anim.SetBool("ExitAnim",true);
        Invoke("SetTriggerFalse",0.1f);
        StartCoroutine(comeBackMegatron());

    }
    IEnumerator comeBackMegatron()
    {
        yield return new WaitForSeconds(3f);
        ResetState();
    }
}
