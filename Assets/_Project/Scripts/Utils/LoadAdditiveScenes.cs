using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAdditiveScenes : MonoBehaviour
{
    public List<string> additiveScenes;
    private void Start()
    {
        foreach (var sceneName in additiveScenes)
        {
            SceneManager.LoadScene(sceneName,LoadSceneMode.Additive);
        }
    }
}
