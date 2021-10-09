using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

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
            StartCoroutine(GetText(instance));
            // пост Html
            // 1 postman
            // 2 сделать post
            // 3 гет передавать с параметрами
            // Код ревью Microsoft
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
