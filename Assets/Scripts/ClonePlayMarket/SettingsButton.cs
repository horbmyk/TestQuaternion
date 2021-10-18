using UnityEngine;

namespace ClonePlayMarket
{
    public class SettingsButton : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        private bool _isClick;
        //Retourn Start pos
        //Animatoins

        private void Awake()
        {
            _mainMenu.SetActive(false);
        }

        public void OnClickSettingsButton()
        {
            _isClick = !_isClick;

            if (_isClick)
                _mainMenu.SetActive(true);
            else
                _mainMenu.SetActive(false);
        }
    }
}
