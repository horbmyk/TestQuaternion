using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Test
{
    public class WebRequest : MonoBehaviour
    {

        void Start()
        {
            StartCoroutine(GetText());
            // пост Html
            // 1 postman
            // 2 сделать post
            // 3 гет передавать с параметрами
            // Код ревью Microsoft
        }
        private IEnumerator GetText()
        {
            UnityWebRequest www = UnityWebRequest.Get("https://www.postman-echo.com/get");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);

            else
            {
                string json = www.downloadHandler.text;
                var desirializetGetData = JsonUtility.FromJson<ExampleJson>(json);
            }
        }
    }
}
