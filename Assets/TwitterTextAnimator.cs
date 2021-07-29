using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI.Examples;
using Febucci.UI;
using Twity.DataModels.Responses;
using Twity.DataModels.Core;
public class TwitterTextAnimator : MonoBehaviour
{
    public TextAnimatorPlayer tanimPlayer;

    public List<Tweet> TweetList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Searching Tweets!");
            tanimPlayer.ShowText("");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["q"] = "olimpiadas";
            parameters["count"] = 30.ToString(); ;
            StartCoroutine(Twity.Client.Get("search/tweets", parameters, Callback));

        }
         if (Input.GetKeyDown(KeyCode.D))
        {
            ShowNextTweet();

        }
    }
     void Callback(bool success, string response)
    {
        if (success)
        {
            Debug.Log(response);
            
            SearchTweetsResponse tweetsResponse = JsonUtility.FromJson<SearchTweetsResponse>(response);
            
            foreach (var tweet in tweetsResponse.statuses)
            {
                
            Debug.Log("------------------------------------------------------------------------------------------------");
            Debug.Log("Tweet User: " + tweet.user.name);
            Debug.Log("Tweet: " + tweet.text);

            AddTweetToQueue(tweet);
            } 

           // tanimPlayer.ShowText(TweetList[0].text);
        }
        else
        {
            Debug.Log(response);
        }
    }
    Queue<Tweet> tweetQueue = new Queue<Tweet>();

    public void AddTweetToQueue(Tweet tweet)
    {
        tweetQueue.Enqueue(tweet);
    }



    public void ShowNextTweet()
    {
        tanimPlayer.ShowText("");
        Tweet tweet = tweetQueue.Dequeue();

        tanimPlayer.ShowText(tweet.user.name + "\n \n "+ tweet.text);
        //Show Tweet
    }

    
}
