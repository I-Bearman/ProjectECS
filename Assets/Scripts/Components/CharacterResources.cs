using System.Collections;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class CharacterResources : MonoBehaviour
{
    public PlayerResources playerResources;
    public Text goldText;

    [SerializeField] private string jsonResourcesUrl;

    private int _gold = 0;

    IEnumerator LoadTextFromServer(string url)
    {
        var request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (!request.isHttpError && !request.isNetworkError)
        {
            playerResources = JsonUtility.FromJson<PlayerResources>(request.downloadHandler.text);
        }
        else if (File.Exists(Application.persistentDataPath + "/PlayerResources.json"))
        {
            string path = Application.persistentDataPath + "/PlayerResources.json";
            StreamReader reader = new StreamReader(path);
            playerResources = JsonUtility.FromJson<PlayerResources>(reader.ReadToEnd());
            reader.Close();
        }
        else
        {
            playerResources = new PlayerResources();
        }
        request.Dispose();
    }

    private void Start()
    {
        StartCoroutine(LoadTextFromServer(jsonResourcesUrl));
    }
    private void Update()
    {
        ChangeTitleResources();
    }

    private void ChangeTitleResources()
    {
        if (_gold != playerResources.Gold)
        {
            goldText.text = $"Gold: {playerResources.Gold}";
            _gold = playerResources.Gold;
        }
    }

    private void OnApplicationQuit()
    {
        SaveResources();
    }

    private void SaveResources()
    {
        var jsonString = JsonUtility.ToJson(playerResources);

        string path = Application.persistentDataPath + "/PlayerResources.json";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(jsonString);
        writer.Close();
    }
}
