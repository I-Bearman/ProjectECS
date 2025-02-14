using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CharacterResources : MonoBehaviour
{
    public PlayerResources playerResources;

    private void Awake()
    {
        var fileList = GoogleDriveTools.FileList();
        Debug.Log(fileList);
    }
    private void WriteStatistics()
    {
        var jsonString = JsonUtility.ToJson(playerResources.gold);
        Debug.Log(jsonString);
        PlayerPrefs.SetString("PlayerResources", jsonString);
        PlayerPrefs.Save();
    }
}
