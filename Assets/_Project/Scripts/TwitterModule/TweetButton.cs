using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Responses;
using Twity.DataModels.Core;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TweetButton : MonoBehaviour
{
    public Tweet tweet;

    public Text tweetUsername;
    public Text tweetText;

    public Image userImage;

    public void SetTweet(Tweet _tweet)
    {
        //Implement Tweet Infos
        tweet = _tweet;

        tweetUsername.text = tweet.user.name;
        tweetText.text = tweet.text;

        SetImageByUrl(tweet.user.profile_image_url);
    }

    public void SetImageByUrl(string imageURL)
    {
        StartCoroutine(SetImageByURLRoutine(imageURL));
    }

    IEnumerator SetImageByURLRoutine(string _imageURL)
    {


        UnityWebRequest request = UnityWebRequestTexture.GetTexture(_imageURL);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {

            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            userImage.GetComponent<Image>().overrideSprite = sprite;
        }

    }

    public void SendTweetToQueue()
    {
        //Implement
        TwitterTextAnimator.Instance.AddTweetToQueue(tweet);
        TwitterTextAnimator.Instance.ShowNextTweet();
        Destroy(gameObject);
    }

    public void DenyTweet()
    {
        //Implement
        Destroy(gameObject);
    }

}
