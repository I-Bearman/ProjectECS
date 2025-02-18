using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class CharacterResources : MonoBehaviour
{
    public PlayerResources playerResources;
    [SerializeField] private Text goldText;
    [SerializeField] private string jsonResourcesUrl;
    private string jsonText;

    private void Awake()
    {
        StartCoroutine(LoadTextFromServer(jsonResourcesUrl));
        playerResources = JsonUtility.FromJson<PlayerResources>(jsonText);
    }

    IEnumerator LoadTextFromServer(string url)
    {
        var request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (!request.isHttpError && !request.isNetworkError)
        {
            jsonText = request.downloadHandler.text;
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
        }

        request.Dispose();
    }

    private void Start()
    {
        
    }

    private void WriteStatistics()
    {

    }
}
