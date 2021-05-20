using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TwitchChatCoroutines.ClassesAndStructs;
//using Newtonsoft.Json;
using System.Net;
using System;


public class EmotesDownloader : MonoBehaviourSingleton<EmotesDownloader>
{
    public int twitchChannelId;
    public string twitchChannelName;


    public BttvChannelEmotesJson channelEmotesJson;
    public BttvEmoteInfo[] globalEmotesJsonArray;
    public FfzChannelJson ffzChannelJson;

    private dynamic FFZEmotesJson;
    private dynamic FFZChannelEmotesJson;

    WebClient client;
    private void Start()
    {
        client = new WebClient();
        DownloadAllBTTVEmotes();
        DownloadFFZEmotes();

        Directory.CreateDirectory(Application.persistentDataPath + "/emotes/TWITCH");
    }

    #region BTTV EMOTES
    public void DownloadAllBTTVEmotes()
    {
        StartCoroutine(DownloadBTTVJsonEmotesRoutine());
    }

    IEnumerator DownloadBTTVJsonEmotesRoutine()
    {
        yield return null;

        Directory.CreateDirectory(Application.persistentDataPath + "/emotes/BetterTTV");


        //Download Global BTTV Emotes Json
        string bttvGlobalEmotesJsonString;
        yield return bttvGlobalEmotesJsonString = HelperFunctions.JsonGetString("https://api.betterttv.net/3/cached/emotes/global");
        //globalEmotesJsonArray = JsonConvert.DeserializeObject<List<BttvEmoteInfo>>(bttvGlobalEmotesJsonString);
        //globalEmotesJsonArray = JsonUtility.FromJson<List<BttvEmoteInfo>>(bttvGlobalEmotesJsonString);
        globalEmotesJsonArray = JsonHelper.GetJsonArray<BttvEmoteInfo>(bttvGlobalEmotesJsonString);

        //Download Channel Emotes Json
        string bttvChannelEmotesJsonString;
        yield return bttvChannelEmotesJsonString = HelperFunctions.JsonGetString("https://api.betterttv.net/3/cached/users/twitch/" + twitchChannelId);
        //channelEmotesJson = JsonConvert.DeserializeObject<BttvChannelEmotesJson>(bttvChannelEmotesJsonString);
        channelEmotesJson = JsonUtility.FromJson<BttvChannelEmotesJson>(bttvChannelEmotesJsonString);


        DownloadGlobalBttvEmotesOnCache();
        DownloadChannelBttvEmotesOnCache();

    }



    public void DownloadGlobalBttvEmotesOnCache()
    {
        foreach (var bttvEmoteInfo in globalEmotesJsonArray)
        {
            DownloadBttvEmote(bttvEmoteInfo);
        }
    }

    public void DownloadChannelBttvEmotesOnCache()
    {
        foreach (var bttvEmoteInfo in channelEmotesJson.channelEmotes)
        {
            DownloadBttvEmote(bttvEmoteInfo);
        }
        foreach (var bttvEmoteInfo in channelEmotesJson.sharedEmotes)
        {
            DownloadBttvEmote(bttvEmoteInfo);
        }
    }

    private void DownloadBttvEmote(BttvEmoteInfo bttvEmoteInfo)
    {
        string channel = bttvEmoteInfo.userId;
        string emote = bttvEmoteInfo.id;
        string code = bttvEmoteInfo.code;
        string imageType = bttvEmoteInfo.imageType;
        string path = Application.persistentDataPath + "/emotes/BetterTTV/BTTV" + emote + "." + imageType;

        if (!File.Exists(path))
        {
            client.DownloadFile(new Uri("http://cdn.betterttv.net/emote/" + emote + "/2x"), path);
            Debug.Log("Downloading File: " + code);
        }
        else
        {
            Debug.Log("File Exists: " + code);

        }

        if (imageType.ToUpper() == "PNG")
        {
            Sprite spriteLoaded = HelperFunctions.LoadSprite(path);

            CachedEmotesManager.Instance.AddSpriteEmote(spriteLoaded, code);
        }
        if (imageType.ToUpper() == "GIF")
        {
            GIF GifLoaded = HelperFunctions.LoadGif(path);

            CachedEmotesManager.Instance.AddGifEmote(GifLoaded, code);
        }
    }

    #endregion

    #region FFZ EMOTES
    public void DownloadFFZEmotes()
    {
        //StartCoroutine(DownloadFFZEmotesRoutine());
        StartCoroutine(DownloadFFZEmotesRoutineObject());
    }
    IEnumerator DownloadFFZEmotesRoutine()
    {
        yield return null;
        Directory.CreateDirectory(Application.persistentDataPath + "/emotes/FFZ");
        /*
            //Download GlobalFFZ Emotes Json
            string ffzGlobalEmoteSJson;
            ffzGlobalEmoteSJson  = HelperFunctions.JsonGetString("https://api.frankerfacez.com/v1/set/global");

            //Download Channel FFZ Emotes Json
            string ffzChannelEmoteSJson;
            ffzChannelEmoteSJson  = HelperFunctions.JsonGetString("https://api.frankerfacez.com/v1/room/" + twitchChannelName);

        */

        string FFZChannelEmotesJsonString = HelperFunctions.JsonGetString("https://api.frankerfacez.com/v1/room/" + twitchChannelName);

        //Dictionary<string,object> FFZChannelEmotesJsonObject = HelperFunctions.JsonGetObject("https://api.frankerfacez.com/v1/room/" + twitchChannelName);

        ffzChannelJson = new FfzChannelJson();
        ffzChannelJson = FfzChannelJson.FromJson(FFZChannelEmotesJsonString);

        //FFZChannelEmotesJson = FFZChannelEmotesJson.sets[(string)(FFZChannelEmotesJson.room.set)].emoticons;

        //FFZEmotesJson = HelperFunctions.JsonGet("https://api.frankerfacez.com/v1/set/global");

        yield return new WaitForEndOfFrame();

        //var temporary3 = JArray.FromObject(FFZChannelEmotesJson);
        //dynamic[] ffzemotesInfoArray = JsonHelper.GetJsonArray<dynamic>((string)FFZChannelEmotesJson);

        foreach (var emoteInfo in ffzChannelJson.Sets.The775036.Emoticons)
        {
            string code = emoteInfo.Name;
            string url = "http://cdn.frankerfacez.com/emoticon/" + emoteInfo.Id + "/1";
            //string url = emoteInfo.Urls["2"];
            string path = Application.persistentDataPath + "/emotes/FFZ/FFZ" + emoteInfo.Id + ".png";

            if (!File.Exists(path))
            {
                client.DownloadFile(new Uri(url), path);
                Debug.Log("Downloading Emote: " + code);
            }
            else
            {
                Debug.Log("File Exist: " + code);

            }


            Sprite spriteLoaded = HelperFunctions.LoadSprite(path);

            CachedEmotesManager.Instance.AddSpriteEmote(spriteLoaded, code);

        }


    }
    IEnumerator DownloadFFZEmotesRoutineObject()
    {
        yield return null;
        Directory.CreateDirectory(Application.persistentDataPath + "/emotes/FFZ");

        string FFZChannelEmotesJsonString = HelperFunctions.JsonGetString("https://api.frankerfacez.com/v1/room/" + twitchChannelName);
        Dictionary<string, object> FFZChannelEmotesJsonObject = new Dictionary<string, object>();
        FFZChannelEmotesJsonObject = (Dictionary<string, object>)EasyMobile.MiniJSON.Json.Deserialize(FFZChannelEmotesJsonString);
        //EasyMobile.MiniJSON.Json.Deserialize(FFZChannelEmotesJsonString);

        //FFZChannelEmotesJsonObject = HelperFunctions.JsonGetObject("https://api.frankerfacez.com/v1/room/" + twitchChannelName);
        //FFZChannelEmotesJsonObject = 

        //ffzChannelJson = new FfzChannelJson();
        //ffzChannelJson = FfzChannelJson.FromJson(FFZChannelEmotesJsonString);

        Dictionary<string, object> room = new Dictionary<string, object>();
        room = (Dictionary<string, object>)FFZChannelEmotesJsonObject["room"];
        Debug.Log("Json Downloaded " + FFZChannelEmotesJsonObject.Keys.Count);
        foreach (var item in FFZChannelEmotesJsonObject.Keys)
        {
            Debug.Log("Key: " + item);
        }


        Dictionary<string, object> sets = new Dictionary<string, object>();
        sets = (Dictionary<string, object>)FFZChannelEmotesJsonObject["sets"];

        string setId = room["set"].ToString();

        Dictionary<string, object> set = new Dictionary<string, object>();
        set = (Dictionary<string, object>)sets[setId];

        //Emoticon[] emoticons = JsonHelper.GetJsonArray<Emoticon>(set["emoticons"].ToString());

        List<object> emoticons = new List<object>();

        emoticons = (List<object>)set["emoticons"];


        yield return new WaitForEndOfFrame();

        foreach (var emote in emoticons)
        {

            Dictionary<string, object> emoteInfo = new Dictionary<string, object>();

            emoteInfo = (Dictionary<string, object>)emote;

            string code = emoteInfo["name"].ToString();
            string url = "http://cdn.frankerfacez.com/emoticon/" + emoteInfo["id"].ToString() + "/1";
            //string url = emoteInfo.Urls["2"];
            string path = Application.persistentDataPath + "/emotes/FFZ/FFZ" + emoteInfo["id"].ToString() + ".png";

            if (!File.Exists(path))
            {
                client.DownloadFile(new Uri(url), path);
                Debug.Log("Downloading Emote: " + code);
            }
            else
            {
                Debug.Log("File Exist: " + code);

            }

            Sprite spriteLoaded = HelperFunctions.LoadSprite(path);

            CachedEmotesManager.Instance.AddSpriteEmote(spriteLoaded, code);

        }


    }

    #endregion

    #region Twitch EMOTES
    public EmoteCacheData AddTwitchEmote(string emoteName, string emoteID)
    {

        string code = emoteName;
        string url = "http://static-cdn.jtvnw.net/emoticons/v1/" + emoteID + "/2.0";
        //string url = emoteInfo.Urls["2"];
        string path = Application.persistentDataPath + "/emotes/TWITCH/Twitch" + emoteID + ".png";

        if (!File.Exists(path))
        {
            client.DownloadFile(new Uri(url), path);
            Debug.Log("Downloading Emote: " + code);
        }
        else
        {
            Debug.Log("File Exist: " + code);

        }

        Sprite spriteLoaded = HelperFunctions.LoadSprite(path);

        return CachedEmotesManager.Instance.AddSpriteEmote(spriteLoaded, code);

        
    }
    #endregion

    public void RedownloadEmotes()
    {

    }
    public void ClearCache()
    {

    }
}

[System.Serializable]
public class BttvChannelEmotesJson
{
    public string id;
    public List<BttvEmoteInfo> bots;
    public List<BttvEmoteInfo> channelEmotes;
    public List<BttvEmoteInfo> sharedEmotes;
}
[System.Serializable]
public class BttvEmoteInfo
{
    public string id;
    public string code;
    public string imageType;
    public string userId;
}

public class JsonHelper
{
    public static T[] GetJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}

[System.Serializable]
public class FFZEmoteInfo
{
    public string css;
    public string height;
    public string hidden;
    public string id;
    public string margins;
    public string modifier;
    public string offset;
    public string owner;

    public string userId;
}


