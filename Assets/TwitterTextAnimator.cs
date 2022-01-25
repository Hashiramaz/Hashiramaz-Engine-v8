using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI.Examples;
using Febucci.UI;
using Twity.DataModels.Responses;
using Twity.DataModels.Core;
using UnityEngine.Networking;
using UnityEngine.UI;
using Lean.Gui;

public class TwitterTextAnimator : MonoBehaviourSingleton<TwitterTextAnimator>
{
    public LeanWindow textWindow;
    public TextAnimatorPlayer tanimPlayer;

    public List<Tweet> TweetList;

    public string searchTerm;

    public Image userImage;
    
    public bool showingTweet;
    // Start is called before the first frame update
    void Start()
    {
        tanimPlayer.onTextShowed.AddListener(TurnOffTextAnimatorWindow);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSearchTerm(string term)
    {
        searchTerm = term;
    }
    public void SearchTweets()
    {
        Debug.Log("Searching Tweets!");
        tanimPlayer.ShowText("");
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["q"] = searchTerm;
        parameters["count"] = 30.ToString(); ;
        StartCoroutine(Twity.Client.Get("search/tweets", parameters, CallbackSearch));
    }

    void CallbackSearch(bool success, string response)
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

                //AddTweetToQueue(tweet);

                TweetsPanel.Instance.InstantiateNewTweetButton(tweet);
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

    public void TryShowNextTweet()
    {
        Debug.Log("Trying show next tweet: " + tweetQueue.Count);
        if(tweetQueue.Count > 0 && !showingTweet)
        {
            ShowNextTweet();
        }
      
    }

    public void ShowNextTweet()
    {

        tanimPlayer.ShowText("");
        Tweet tweet = tweetQueue.Dequeue();

        tanimPlayer.ShowText(tweet.user.name + "\n \n " + tweet.text);
        SetTwitterUserImage(tweet.user.profile_image_url);

        textWindow.TurnOn();

        showingTweet = true;
       
        //Show Tweet
    }

    public void TurnOffTextAnimatorWindow()
    {
        StartCoroutine(tryShowNextRoutine());
        
    }

    IEnumerator tryShowNextRoutine()
    {
        yield return new WaitForSeconds(5f);
        textWindow.TurnOff();

        showingTweet = false;
        yield return new WaitForSeconds(1f);
        TryShowNextTweet();
    }


    public void SetTwitterUserImage(string imageURL)
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

}
