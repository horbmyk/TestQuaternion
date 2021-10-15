using UnityEngine;
using UnityEngine.UI;

namespace ClonePlayMarket
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Sprite[] Sources;
        [SerializeField] private GameObject PrefabItem;
        [SerializeField] private Transform Content;

        private void Awake()
        {
            foreach (var item in Sources)
            {
                GameObject itemSources = Instantiate(PrefabItem, Content.transform);
                itemSources.GetComponent<Image>().sprite = item;
                itemSources.GetComponentInChildren<Text>().text = item.name;
            }
        }
    }
}
