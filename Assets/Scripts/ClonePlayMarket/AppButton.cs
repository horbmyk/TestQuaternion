using UnityEngine;
using UnityEngine.UI;

namespace ClonePlayMarket
{
    public class AppButton : MonoBehaviour
    {
        private Text _description;

        private void Awake()
        {
            _description = GetComponentInChildren<Text>();
        }

        public void OnClick()
        {
            Debug.Log("You Chose " + _description.text);
        }
    }
}
