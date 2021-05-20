using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CachedEmotesManager : MonoBehaviourSingleton<CachedEmotesManager>
{
    public SortedList<string, EmoteCacheData> bttvEmotes = new SortedList<string, EmoteCacheData>();

    public EmoteCacheData AddSpriteEmote(Sprite sprite, string emoteName)
    {
        if (bttvEmotes.Keys.Contains(emoteName))
            return GetEmote(emoteName);


        EmoteCacheData emoteCacheData = new EmoteCacheData(sprite, emoteName);

        bttvEmotes.Add(emoteName, emoteCacheData);

        Debug.Log("Emote Added: " + emoteName);
        Debug.Log("Image: " + sprite != null);

        return emoteCacheData;
    }

    public void AddGifEmote(GIF gif, string emoteName)
    {
        if (bttvEmotes.Keys.Contains(emoteName))
            return;

        bttvEmotes.Add(emoteName, new EmoteCacheData(gif, emoteName));

        Debug.Log("Emote Added: " + emoteName);
        Debug.Log("Image: " + gif != null);
    }


    public EmoteCacheData GetEmote(string emoteName)
    {
        if (bttvEmotes.ContainsKey(emoteName))
        {
            return bttvEmotes[emoteName];
        }
        else
            return null;
    }

    public EmoteCacheData TryGetEmoteOrAdd(string emoteName, string emoteID)
    {
        if (GetEmote(emoteName) == null)
        {
            return EmotesDownloader.Instance.AddTwitchEmote(emoteName, emoteID);
        }
        else return GetEmote(emoteName);

    }

    public bool MessageContainEmote(string message)
    {
        return bttvEmotes.ContainsKey(message);
    }
}


[System.Serializable]
public class EmoteCacheData
{

    public string emoteName;
    public EmoteType type;
    public Sprite emoteSprite;
    //public EmoteData emoteData;

    public GIF emoteGif;

    public EmoteCacheData()
    {
    }

    public EmoteCacheData(Sprite emoteSprite)
    {
        this.type = EmoteType.PNG;
        this.emoteSprite = emoteSprite;
    }
    public EmoteCacheData(Sprite emoteSprite, string _emoteName)
    {
        this.type = EmoteType.PNG;
        this.emoteSprite = emoteSprite;
        this.emoteName = _emoteName;
    }
    public EmoteCacheData(GIF emoteGif, string _emoteName)
    {
        this.type = EmoteType.GIF;
        this.emoteGif = emoteGif;
        this.emoteName = _emoteName;
    }
    // public EmoteCacheData(Gif emoteGif)
    // {
    //     this.type = EmoteType.PNG;
    //     this.emoteGif = emoteGif;        
    // }
}
public enum EmoteType
{
    PNG,
    GIF
}

public class GIF
{
    //public string Filename;
    public List<Texture2D> mFrames = new List<Texture2D>();
    public List<Sprite> mSpriteFrames = new List<Sprite>();
    public List<float> mFrameDelay = new List<float>();

    public GIF()
    {
    }

    public GIF(List<Texture2D> mFrames, List<float> mFrameDelay)
    {
        this.mFrames = mFrames;
        this.mFrameDelay = mFrameDelay;
    }

    public GIF(List<Texture2D> mFrames, List<Sprite> mSpriteFrames, List<float> mFrameDelay)
    {
        this.mFrames = mFrames;
        this.mSpriteFrames = mSpriteFrames;
        this.mFrameDelay = mFrameDelay;
    }
}