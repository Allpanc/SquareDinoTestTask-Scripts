using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SquareDinoTestTask.Menu
{
    public class MainMenuInteractor : MenuInteractor
    {
        [SerializeField] Button _playButton;
        [SerializeField] Button _levelsButton;
        [SerializeField] Button _settingsButton;
        [SerializeField] Button _shopButton;

        void Start()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _levelsButton.onClick.AddListener(OnLevelsButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            _shopButton.onClick.AddListener(OnShopButtonClick);
        }

        private void OnPlayButtonClick()
        {
            SceneManager.LoadScene(1);
            Debug.Log("OnPlayButtonClick");
        }

        private void OnLevelsButtonClick()
        {
            _menuSwitcher.ShowLocationMenu();
            Debug.Log("OnPlayButtonClick");
        }

        private void OnSettingsButtonClick()
        {

        }

        private void OnShopButtonClick()
        {

        }
    }
}
