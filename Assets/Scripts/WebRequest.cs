using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://www.postman-echo.com");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        //else
        //{
        //    string json = www.downloadHandler.text;
        //    var desirializetGetData = JsonUtility.FromJson(json);
        //    Debug.Log(www.downloadHandler.text);
        //}
    }
}
