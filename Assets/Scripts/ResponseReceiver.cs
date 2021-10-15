using UnityEngine;

namespace Test
{
    public class ResponseReceiver : MonoBehaviour
    {
        [SerializeField] private WebRequest _webRequest;

        private void OnEnable()
        {
            _webRequest.ResponseReceived += ResponseReceivedHandler;
        }

        private void ResponseReceivedHandler(string response)
        {
            Debug.Log(response);
        }
    }
}
