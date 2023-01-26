using UnityEngine;
using UnityEngine.UI;

namespace SquareDinoTestTask.Menu
{
    public class LocationMenuInteractor : MenuInteractor
    {
        [SerializeField] LevelMenuInteractor _levelMenuController;

        [SerializeField] Button _spaceButton;
        [SerializeField] Button _dungeonButton;
        [SerializeField] Button _forestButton;
        [SerializeField] Button _barButton;
        [SerializeField] Button _gymButton;

        void Start()
        {
            _spaceButton.onClick.AddListener(OnSpaceButtonClick);
            _dungeonButton.onClick.AddListener(OnDungeonButtonClick);
            _forestButton.onClick.AddListener(OnForestButtonClick);
            _barButton.onClick.AddListener(OnBarButtonClick);
            _gymButton.onClick.AddListener(OnGymButtonClick);
            _closeButton.onClick.AddListener(_menuSwitcher.ShowMainMenu);
        }

        public void OnSpaceButtonClick()
        {
            ChooseLocation(Location.Space);
        }

        public void OnDungeonButtonClick()
        {
            ChooseLocation(Location.Dungeon);
        }

        public void OnForestButtonClick()
        {

        }

        public void OnBarButtonClick()
        {

        }

        public void OnGymButtonClick()
        {

        }

        public void ChooseLocation(Location location)
        {
            _levelMenuController.Location = location;
            _menuSwitcher.ShowLevelMenu();
        }
    }
}
