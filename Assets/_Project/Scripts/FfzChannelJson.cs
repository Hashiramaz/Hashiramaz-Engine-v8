// Generated by https://quicktype.io


using Newtonsoft.Json;

using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

[System.Serializable]
public partial class FfzChannelJson
{
    [JsonProperty("room")]
    public Room Room { get; set; }

    [JsonProperty("sets")]
    public Sets Sets { get; set; }
}


[System.Serializable]
public partial class Room
{
    [JsonProperty("_id")]
    public long Id { get; set; }

    [JsonProperty("css")]
    public object Css { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("id")]
    public string RoomId { get; set; }

    [JsonProperty("is_group")]
    public bool IsGroup { get; set; }

    [JsonProperty("mod_urls")]
    public object ModUrls { get; set; }

    [JsonProperty("moderator_badge")]
    public object ModeratorBadge { get; set; }

    [JsonProperty("set")]
    public long Set { get; set; }

    [JsonProperty("twitch_id")]
    public long TwitchId { get; set; }

    [JsonProperty("user_badges")]
    public UserBadges UserBadges { get; set; }
}

public partial class UserBadges
{
}

public partial class Sets
{
    [JsonProperty("775036")]
    public The775036 The775036 { get; set; }
}

public partial class The775036
{
    [JsonProperty("_type")]
    public long Type { get; set; }

    [JsonProperty("css")]
    public object Css { get; set; }

    [JsonProperty("description")]
    public object Description { get; set; }

    [JsonProperty("emoticons")]
    public Emoticon[] Emoticons { get; set; }

    [JsonProperty("icon")]
    public object Icon { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }
}

public partial class Emoticon
{
    [JsonProperty("css")]
    public object Css { get; set; }

    [JsonProperty("height")]
    public long Height { get; set; }

    [JsonProperty("hidden")]
    public bool Hidden { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("margins")]
    public object Margins { get; set; }

    [JsonProperty("modifier")]
    public bool Modifier { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("offset")]
    public object Offset { get; set; }

    [JsonProperty("owner")]
    public Owner Owner { get; set; }

    [JsonProperty("public")]
    public bool Public { get; set; }

    [JsonProperty("urls")]
    public Dictionary<string, string> Urls { get; set; }

    [JsonProperty("width")]
    public long Width { get; set; }
}

public partial class Owner
{
    [JsonProperty("_id")]
    public long Id { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}

public partial class FfzChannelJson
{
    public static FfzChannelJson FromJson(string json) => JsonConvert.DeserializeObject<FfzChannelJson>(json, Converter.Settings);
    //public static FfzChannelJson FromJson(string json) => JsonUtility.FromJson<FfzChannelJson>(json);
}

public static class Serialize
{
    public static string ToJson(this FfzChannelJson self) => JsonUtility.ToJson(self);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}
