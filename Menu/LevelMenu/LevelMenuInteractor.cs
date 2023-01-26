using SquareDinoTestTask.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace SquareDinoTestTask.Menu
{
    public class LevelMenuInteractor : MenuInteractor
    {
        private Location _previuosLocation;
        [SerializeField] private Location _location;

        public Location Location { get => _location; set => _location = value; }

        private void Start()
        {
            _previuosLocation = Location;
            _closeButton.onClick.AddListener(_menuSwitcher.ShowLocationMenu);
        }

        public void GoToSelectedLevel()
        {    
            SceneManager.LoadScene(GetSelectedLevel().LevelDescription.GetName());
        }

        public LevelDisplay GetSelectedLevel()
        {
            return EventSystem.current.currentSelectedGameObject.GetComponent<LevelDisplay>();           
        }

        public List<LevelDescription> GetCurrentLocationLevelDescriptions()
        {
            _previuosLocation = _location;
            return LevelDescriptionRepository.GetLevelDescriptionsByLocation(_location);
        }

        public bool IsLocationChanged()
        {
            return Location != _previuosLocation;
        }
    }
}
