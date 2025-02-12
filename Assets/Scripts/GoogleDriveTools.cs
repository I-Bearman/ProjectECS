using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityGoogleDrive;
using UnityGoogleDrive.Data;

public class GoogleDriveTools : MonoBehaviour
{
    public static List<File> FileList()
    {
        List<File> output = new List<File>();
        GoogleDriveFiles.List().Send().OnDone += fileList => { output = fileList.Files; };
        return output;
    }

    public static File Upload(string obj, Action onDone)
    {
        var file = new File { Name = "GameData.json", Content = Encoding.ASCII.GetBytes(obj) };
        GoogleDriveFiles.Create(file).Send();
        return file;
    }

    public static File Download(string fileId)
    {
        File output = new File();
        GoogleDriveFiles.Download(fileId).Send().OnDone += file => { output = file; };
        return output;
    }

}
