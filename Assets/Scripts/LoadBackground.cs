using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadBackground : MonoBehaviour
{
    public MeshRenderer targetMesh;
    public string fileName = @"background";
    string fileSuffixJPG = @".jpg";
    string fileSuffixPNG = @".png";
    Texture2D targetTex;
    void Start()
    {
        //From Local path
        string root = Application.dataPath + "/../";
        string url = root + fileName + fileSuffixPNG;
        if (!System.IO.File.Exists(url))
            url = root + fileName + fileSuffixJPG;

        Debug.Log(url);
        StartCoroutine(DownloadImage(url, LoadImageToMesh));

        //From internet
        //string netUrl = "https://i.imgur.com/DpRAzV5.png";
        //StartCoroutine(DownloadImage(netUrl));
    }

    IEnumerator DownloadImage(string MediaUrl, System.Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else {
            callback(((DownloadHandlerTexture)request.downloadHandler).texture);
        }
    }

    void LoadImageToMesh(Texture2D tex){
        targetMesh.material.mainTexture = tex;
    }
}
