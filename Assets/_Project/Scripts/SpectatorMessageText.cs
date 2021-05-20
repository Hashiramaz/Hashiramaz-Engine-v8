using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using TMPro;
using DG.Tweening;
public class SpectatorMessageText : MonoBehaviour
{
    public LeanToggle characterToggle
    {
        get
        {
            return GetComponent<LeanToggle>();
        }
    }

    public TextMeshPro messageText;

    #region Activate / Deactivate

    public void ActivateMessage()
    {
        characterToggle.TurnOn();
    }

    public void DeactivateMessage()
    {
        characterToggle.TurnOff();
    }    

    #endregion


    public void SetText(string text)
    {
        messageText.text = text;
    }

    public void StartMessageCycle(string _textString)
    {
        StartCoroutine(MessageTextRoutine(_textString));

    }

    IEnumerator MessageTextRoutine(string textString)
    {

        //TODO Set MessageText        
        SetText(textString);
        
        //Activate Message
        ActivateMessage();

        
        //Move Message UP
        transform.DOMoveY(transform.position.y + 2,2);
        
        yield return new WaitForSeconds(2f);

        //Deactivate Message
        DeactivateMessage();
        
        yield return new WaitForSeconds(1f);
        
        //Destroy Message
        Destroy(gameObject);
    }


}
