using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twity.DataModels.Responses;
using Twity.DataModels.Core;

public class TwitterConnect : MonoBehaviour
{
    void Start()
    {
        Twity.Oauth.consumerKey = "z66930uMzZzB1ZGfIAQ0hb7eU";
        Twity.Oauth.consumerSecret = "19v6EQyGeYyCzHGSjuE48ECc4BqCf4OtVd7166bfsOwEfWsfA1";
        Twity.Oauth.accessToken = "92294330-5AoRbY7hTiiBdo9zYrSs9JKonX30CeISpVFr0tY6D";
        Twity.Oauth.accessTokenSecret = "1p1rhAWP5GjxBGnhjOtDZUgiXB9pOQgxCOV0hwPxYcl7F";

        // Debug.Log("Start Connection");

        // StartCoroutine(Twity.Client.GetOauth2BearerToken(CallbackAuth));

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Searching Tweets!");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["q"] = "bbb";
            parameters["count"] = 30.ToString(); ;
            StartCoroutine(Twity.Client.Get("search/tweets", parameters, Callback));

        }
    }

    void CallbackAuth(bool success)
    {
        if (success)
        {
            Debug.Log("Conection Success");
        }
        else
        {
            Debug.Log("Conection Fail");

            return;
        }
        // you write some request with application-only authentication
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
            } 
        }
        else
        {
            Debug.Log(response);
        }
    }
}
