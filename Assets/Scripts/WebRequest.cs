using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Test
{
    public class WebRequest : MonoBehaviour
    {
        public delegate void ShowJsonEventHandler(string json);

        void Start()
        {
            EventHandler instance = new EventHandler();
            instance.EventShowJson += instance.ViewJsonFirst;
            instance.EventShowJson += instance.ViewJsonSecond;

            //StartCoroutine(GetText(instance));
            StartCoroutine(Upload());

            //  гет передавать с параметрами
        }


        private IEnumerator GetText(EventHandler eventHandler)
        {
            UnityWebRequest www = UnityWebRequest.Get("https://www.postman-echo.com/get");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);

            else
            {
                string json = www.downloadHandler.text;
                var desirializetGetData = JsonUtility.FromJson<ExampleJson>(json);
                eventHandler.InvokeEvent(desirializetGetData.url);
            }
        }

        IEnumerator Upload()
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
