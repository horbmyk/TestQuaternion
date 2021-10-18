using UnityEngine;
using UnityEngine.UI;

namespace ClonePlayMarket
{
    public class AppsController : MonoBehaviour
    {
        [SerializeField] private Sprite[] AppImagesSource;
        [SerializeField] private GameObject PrefabItemApp;
        [SerializeField] private Transform ContentApp;

        private void Awake()
        {
            foreach (var item in AppImagesSource)
            {
                GameObject itemSources = Instantiate(PrefabItemApp, ContentApp.transform);
                itemSources.GetComponent<Image>().sprite = item;
                itemSources.GetComponentInChildren<Text>().text = item.name;
            }
        }
    }
}
