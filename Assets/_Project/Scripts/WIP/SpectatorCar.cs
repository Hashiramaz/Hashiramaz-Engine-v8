using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpectatorCar : MonoBehaviour
{
    public string spectatorUserName;

    public string currentMessage;

    public Text ballonText;
    public void SetMessage(string message)
    {
        currentMessage = message;
        ballonText.text = message;
    }
}
