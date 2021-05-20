using UnityEngine;
using UnityEngine.UI;
using TwitchChatConnect.Client;
using TwitchChatConnect.Data;
using TwitchChatConnect.Manager;

public class Example : MonoBehaviour
{
    [SerializeField] private Transform panel;
    [SerializeField] private GameObject textPrefab;

    void Start()
    {
    }


    private void OnEnable() {
        TwitchChatClient.instance.onChatMessageReceived += ShowMessage;
        
    }
    private void OnDisable() {
        TwitchChatClient.instance.onChatMessageReceived -= ShowMessage;
        
    }

    void ShowMessage(TwitchChatMessage chatMessage)
    {
        // Debug.Log("Message Sended");
        // string parameters = string.Join(" - ", chatMessage.parameters);
        // string chatMessageText = $"Command: '{chatMessage.command}' - Sender: {chatMessage.sender} - Parameters: {parameters}";

        // GameObject newText = Instantiate(textPrefab, panel);
        // newText.GetComponent<Text>().text = chatMessageText;
    }
}
