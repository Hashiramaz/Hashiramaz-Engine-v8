using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChatConnect.Client;
using TwitchChatConnect.Data;

public class CarGroupController : MonoBehaviour
{
    public List<SpectatorCar> currentCars = new List<SpectatorCar>();

    public Dictionary<string, SpectatorCar> carsSpawned = new Dictionary<string, SpectatorCar>();

    public SpectatorCar spectatorCarPrefab;

    public SpawnArea spawnArea;

    private void OnEnable()
    {

    }
    private void Start() {
        
        TwitchChatClient.instance.onChatMessageReceived += OnMessageReceived;
    }
    private void OnDisable()
    {
        TwitchChatClient.instance.onChatMessageReceived -= OnMessageReceived;

    }


    public void OnMessageReceived(TwitchChatMessage chatMessage)
    {
        // Debug.Log("Message. User: " + chatMessage.sender + " , message: " + chatMessage.message);
        // string parameters = string.Join(" - ", chatMessage.parameters);
        // string chatMessageText = $"Command: '{chatMessage.command}' - Sender: {chatMessage.sender} - Parameters: {parameters}";

        SpawnSpectatorCar(chatMessage.User.DisplayName, chatMessage.Message);
    }

    public void SpawnSpectatorCar(string userName, string message)
    {
        if (!carsSpawned.ContainsKey(userName))
        {
            var carInstantiated = Instantiate(spectatorCarPrefab, spawnArea.GetRandomPoint(), transform.rotation);

            carInstantiated.SetMessage(message);

            currentCars.Add(carInstantiated);
            carsSpawned.Add(userName, carInstantiated);
        }else
        {
            var car =  carsSpawned[userName];
            car.SetMessage(message);
        }
    }
}
