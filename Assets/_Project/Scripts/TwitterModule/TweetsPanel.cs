using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Core;

public class TweetsPanel : MonoBehaviourSingleton<TweetsPanel>
{
    public TweetButton tweetButtonPrefab;

    

    public void InstantiateNewTweetButton(Tweet tweet)
    {
        TweetButton instantiated = Instantiate(tweetButtonPrefab,transform);
        
        instantiated.SetTweet(tweet);
    }


    public void ClearTweets()
    {         
        foreach (var tweet in GetComponentsInChildren<TweetButton>())
        {
            Destroy(tweet.gameObject);
        }
    }
}
