using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Test
{
    public class WebRequest : MonoBehaviour
    {
        [TextArea] [SerializeField] private string _url;
        public delegate void ShowJsonEventHandler(string json);
        public event ShowJsonEventHandler ResponseReceived;

        private void OnEnable()
        {
            StartCoroutine(GetText(_url));
        }

        private IEnumerator GetText(string url)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);

            else
            {
                string json = www.downloadHandler.text;
                var desirializetGetData = JsonUtility.FromJson<ExampleJson>(json);
                ResponseReceived?.Invoke(json);
            }
        }

        private IEnumerator Upload()
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
            formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
            formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));
            UnityWebRequest www = UnityWebRequest.Post("https://www.postman-echo.com/post", formData);

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

        public class EventHandler
        {
            public event ShowJsonEventHandler EventShowJson = null;

            public void InvokeEvent(string json)
            {
                EventShowJson.Invoke(json);
            }

            public void ViewJsonFirst(string json)
            {
                Debug.Log("ViewJsonFirst");
                Debug.Log(json);
            }

            public void ViewJsonSecond(string json)
            {
                Debug.Log("ViewJsonSecond");
                Debug.Log(json);
            }
        }
    }
}
