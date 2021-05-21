using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchChatConnect.Data;
using TwitchChatConnect.Client;

public class SpectatorsManager : MonoBehaviourSingleton<SpectatorsManager>
{
    public SpawnArea spawnArea;
    public SpawnArea[] spawnAreas;

    public SpectatorCharacter spectatorCharPrefab;

    public string rewardId;
    public string rewardIdDance;

    public int spectatorsLimit = 100;

    public bool randomRotation = true;
    #region INITIALIZE TWITCH CHAT
    private void Start()
    {
        InitializeTwitchConnection();
    }

    public void InitializeTwitchConnection()
    {
        TwitchChatClient.instance.Init(() =>
           {

               TwitchChatClient.instance.onChatRewardReceived += TrySpawnSpectator;
               TwitchChatClient.instance.onChatRewardReceived += TryChangeSpectatorDance;
               TwitchChatClient.instance.onChatMessageReceived += TrySpawnMessage;

               Debug.Log("Twitch connected");
           },
           message =>
           {
               // Error when initializing.
               Debug.LogError(message);
           });
    }


    #endregion

    #region Debug Things
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SpawnNewSpectator();
    }
    #endregion

    #region SpawnSpectator
    public void TrySpawnSpectator(TwitchChatReward rewardData)
    {
        if (rewardData.CustomRewardId != rewardId)
            return;

        Debug.Log("Reward Received: " + rewardData.CustomRewardId + " from " + rewardData.User.DisplayName);

        if (UserIsOnParty(rewardData.User))
            return;


        if (spectatorsSpawned.Count >= spectatorsLimit)
        {
            // Spawn Blink Spectator
            //FUTURE

            return;
        }


        SpawnNewSpectator(rewardData.User);
    }

    public void SpawnNewSpectator()
    {
        Vector3 randomRotationAngle;
        if (randomRotation)
        {
            randomRotationAngle = new Vector3(0, Random.Range(0, 360), 0);
        }
        else
        {
            randomRotationAngle = new Vector3(0, 0, 0);
        }
        SpectatorCharacter characterSpawned = Instantiate(spectatorCharPrefab, GetRandomSpawnArea().GetRandomPoint(), Quaternion.Euler(randomRotationAngle));

        characterSpawned.ActivateCharacter();
    }

    public void SpawnNewSpectator(TwitchUser twitchuser)
    {
        Vector3 randomRotationAngle;
        if (randomRotation)
        {
            randomRotationAngle = new Vector3(0, Random.Range(0, 360), 0);
        }
        else
        {
            randomRotationAngle = new Vector3(0, 0, 0);
        }

        SpectatorCharacter characterSpawned = Instantiate(spectatorCharPrefab, GetRandomSpawnArea().GetRandomPoint(), Quaternion.Euler(randomRotationAngle));

        characterSpawned.SetSpectatorData(twitchuser);

        characterSpawned.ActivateCharacter();

        AddNewSpectator(twitchuser, characterSpawned);

    }
    #endregion

    #region Manage Spectators

    [Header("Spectator Manage Things")]
    public List<Spectator> spectatorsSpawned = new List<Spectator>();


    public void AddNewSpectator(TwitchUser _user, SpectatorCharacter _character)
    {

        Spectator spectator = new Spectator(_user, _character);

        spectatorsSpawned.Add(spectator);
    }

    public void RemoveSpectator(TwitchUser user)
    {

    }

    public void RemoveAllSpectators()
    {

    }

    public Spectator GetSpectator(TwitchUser user)
    {
        Spectator spectatorSelected = new Spectator();

        for (int i = 0; i < spectatorsSpawned.Count; i++)
        {
            Spectator spectator = spectatorsSpawned[i];

            if (spectator.twitchUser == user)
                spectatorSelected = spectator;
        }

        return spectatorSelected;
    }

    public bool UserIsOnParty(TwitchUser user)
    {
        bool isOnParty = false;

        foreach (var spectator in spectatorsSpawned)
        {
            if (spectator.twitchUser == user)
            {
                isOnParty = true;

                //Verify of Player buyed a Sub
                if (spectator.twitchUser.IsSub != user.IsSub)
                    spectator.twitchUser.IsSub = user.IsSub;

            }
        }

        return isOnParty;
    }

    #endregion

    #region  MessageThings
    private void TrySpawnMessage(TwitchChatMessage chatMessage)
    {
        //Debug.Log("Mensagem: " + chatMessage.Message);
        if (!UserIsOnParty(chatMessage.User))
            return;

        Spectator spectator = GetSpectator(chatMessage.User);

        string message = TrySpawnEmote(chatMessage.Message);

        spectator.character.SpawnMessage(message);

    }
    public string TrySpawnEmote(string message)
    {
        string[] messageSplited = message.Split(' ');
        string finalMessage = "";
        foreach (var word in messageSplited)
        {
            if (CachedEmotesManager.Instance.MessageContainEmote(word))
            {
                EmoteCacheData emote = CachedEmotesManager.Instance.GetEmote(word);
                EmotesSpawnManager.Instance.SpawnEmote(emote);

                Debug.Log("Message Contains Emote: " + word);
            }
            else
            {
                finalMessage += word + " ";
            }
        }

        return finalMessage;
    }

    public string TrySpawnTwitchEmote(string message, IRCTags tags)
    {
        string finalMessage = message;
        for (int i = 0; i < tags.emotes.Count; i++)
        {
            ChatterEmote emote = tags.emotes[i];

            Debug.Log("Emotes: " + emote.indexes.Length);
            for (int j = 0; j < emote.indexes.Length; j++)
            {
                ChatterEmote.Index emoteInstance = emote.indexes[j];
                //string emoteName = message.Substring(emoteInstance.startIndex,emoteInstance.endIndex);
                int stringLength = (emoteInstance.endIndex + 1) - emoteInstance.startIndex;
                string emoteName = message.Substring(emoteInstance.startIndex, stringLength);

                finalMessage = finalMessage.Replace(emoteName, "");
                // char[] charToreplace = new char[emoteName.Length];
                // for (int k = 0; k < charToreplace.Length; k++)
                // {
                //     charToreplace[k] = ' ';
                // }

                // message.Remove(emoteInstance.startIndex,emoteInstance.endIndex);
                // message.Insert(emoteInstance.startIndex,charToreplace.ToString());

                StartTrySpawnEmote(emote, emoteName);

                //  Debug.Log("Message Contains Emote: " + emotecached.emoteName);

            }

        }

        for (int i = 0; i < tags.emotes.Count; i++)
        {
            ChatterEmote emote = tags.emotes[i];
            for (int j = 0; j < emote.indexes.Length; j++)
            {
                ChatterEmote.Index emoteInstance = emote.indexes[j];
                //int stringLength = (emoteInstance.endIndex + 1) - emoteInstance.startIndex;
                //string emoteName = message.Substring(emoteInstance.startIndex,stringLength);
                // string emoteName = emote.

                // message =  message.Replace(emoteName,"");

            }

        }
        Debug.Log("MEssage: " + finalMessage);


        return finalMessage;
    }

    private void StartTrySpawnEmote(ChatterEmote emote, string emoteName)
    {
        StartCoroutine(TrySpawnEmoteRoutine(emote, emoteName));
    }

    IEnumerator TrySpawnEmoteRoutine(ChatterEmote emote, string emoteName)
    {
        yield return null;

        EmoteCacheData emotecached = CachedEmotesManager.Instance.TryGetEmoteOrAdd(emoteName, emote.id);

        EmotesSpawnManager.Instance.SpawnEmote(emotecached);
    }

    public void TryChangeSpectatorDance(TwitchChatReward rewardData)
    {
        if (rewardData.CustomRewardId != rewardIdDance)
            return;

        if (!UserIsOnParty(rewardData.User))
            return;

        Spectator spectator = GetSpectator(rewardData.User);

        string message = rewardData.Message.Trim().ToLower();

        if (message == "dancinha")
        {
            spectator.character.ChooseDance(0);
        }
        if (message == "break")
        {
            spectator.character.ChooseDance(1);
        }
        if (message == "macarena")
        {
            spectator.character.ChooseDance(2);
        }
        if (message == "moonwalk")
        {
            spectator.character.ChooseDance(3);
        }
        if (message == "passinho1")
        {
            spectator.character.ChooseDance(4);
        }
        if (message == "passinho2")
        {
            spectator.character.ChooseDance(5);
        }
        if (message == "passinho3")
        {
            spectator.character.ChooseDance(6);
        }
        if (message == "passinho4")
        {
            spectator.character.ChooseDance(7);
        }
        if (message == "passinhodojon")
        {
            spectator.character.ChooseDance(8);
        }
        if (message == "robo")
        {
            spectator.character.ChooseDance(9);
        }
        if (message == "shuffling")
        {
            spectator.character.ChooseDance(10);
        }

    }

    #endregion

    #region  SpawnAreaThings
    public SpawnArea GetRandomSpawnArea()
    {
        return spawnAreas[Random.Range(0, spawnAreas.Length)];
    }

    #endregion

}

[System.Serializable]
public class Spectator
{
    public TwitchUser twitchUser;

    public SpectatorCharacter character;

    public Spectator()
    {

    }

    public Spectator(TwitchUser twitchUser, SpectatorCharacter character)
    {
        this.twitchUser = twitchUser;
        this.character = character;
    }
}