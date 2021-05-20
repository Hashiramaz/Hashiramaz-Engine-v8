using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
//using Assets.GifAssets.PowerGif;

namespace TwitchChatCoroutines.ClassesAndStructs
{
    public static class HelperFunctions
    {
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static dynamic JsonGet(string url, string[] headers = null)
        {
            using (WebClient client = new WebClient())
            {
                if (headers != null)
                    for (int i = 0; i < headers.Length; i++)
                    {
                        client.Headers.Add(headers[i]);
                    }
                return JsonConvert.DeserializeObject<dynamic>(client.DownloadString(url));
            }
        }
        public static Dictionary<string,object> JsonGetObject(string url, string[] headers = null)
        {
            using (WebClient client = new WebClient())
            {
                if (headers != null)
                    for (int i = 0; i < headers.Length; i++)
                    {
                        client.Headers.Add(headers[i]);
                    }
                //return JsonConvert.DeserializeObject<dynamic>(client.DownloadString(url));
                return JsonUtility.FromJson<Dictionary<string,object>>(client.DownloadString(url));
            }
        }
        public static string JsonGetString(string url, string[] headers = null)
        {
            using (WebClient client = new WebClient())
            {
                if (headers != null)
                    for (int i = 0; i < headers.Length; i++)
                    {
                        client.Headers.Add(headers[i]);
                    }
                //return JsonConvert.DeserializeObject<string>(client.DownloadString(url));
                return client.DownloadString(url);
            }
        }

        public static Sprite LoadSprite(string path)
        {
            if (string.IsNullOrEmpty(path)) return null;
            if (System.IO.File.Exists(path))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(bytes);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                return sprite;
            }
            return null;
        }
        // public static Gif LoadGif(string path)
        // {
        //     if (string.IsNullOrEmpty(path)) return null;
        //     if (System.IO.File.Exists(path))
        //     {
        //          byte[] bytes = System.IO.File.ReadAllBytes(path);
        //         // Texture2D texture = new Texture2D(1, 1);
        //         // texture.LoadImage(bytes);
        //         // Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        //         // return sprite;

        //         //var path = "Assets/GifAssets/PowerGif/Examples/Samples/Large.gif";

        //         // if (path == "") return null;
        //         // var bytes = File.ReadAllBytes(path);
        //          var gif = Gif.Decode(bytes);

        //         return gif;

        //     }
        //     return null;

        public static GIF LoadGif(string path)
        {
       
            List<Texture2D> mFrames = new List<Texture2D>();
            List<Sprite> mSpriteFrames = new List<Sprite>();
            List<float> mFrameDelay = new List<float>();
            
            using (var decoder = new MG.GIF.Decoder(File.ReadAllBytes(path)))
            {
                var img = decoder.NextImage();

                while (img != null)
                {   
                    Texture2D textureLoaded = img.CreateTexture();
                    
                    mFrames.Add(textureLoaded);

                    Sprite sprite = Sprite.Create(textureLoaded, new Rect(0, 0, textureLoaded.width, textureLoaded.height), new Vector2(0.5f, 0.5f));
                    mSpriteFrames.Add(sprite);

                    mFrameDelay.Add(img.Delay / 1500.0f);
                    img = decoder.NextImage();
                }
            }

            GIF gifLoaded = new GIF(mFrames,mSpriteFrames,mFrameDelay);
            
            return gifLoaded;            
        }

      
    }
}
