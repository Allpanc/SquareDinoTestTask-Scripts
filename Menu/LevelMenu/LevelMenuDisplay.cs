using SquareDinoTestTask.Data;
using SquareDinoTestTask.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SquareDinoTestTask.Menu
{
    public class LevelMenuDisplay : MenuDisplay
    {
        [SerializeField] LevelMenuInteractor _levelMenuInteractor;
        [SerializeField] List<LevelDisplay> _levelDisplays = new List<LevelDisplay>();

        protected override void Start()
        {
            base.Start();
            SetUpContent();
        }

        private IEnumerator InitializeContent()
        {
            yield return null;
            SetUpContent();
        }

        private void SetUpContent()
        {
            List<LevelDescription> levelDescriptions = _levelMenuInteractor.GetCurrentLocationLevelDescriptions();
            string jsonString = Resources.Load<TextAsset>("GachiRanks").text;
            string[] gachiRanks = JsonHelper.FromJson<string>(jsonString);

            for (int i = 0; i < _levelDisplays.Count; i++)
            {
                _levelDisplays[i].LevelDescription = levelDescriptions[i];
                _levelDisplays[i].Text.text = gachiRanks[i];

                Button button = _levelDisplays[i].GetComponent<Button>();
                button.onClick.AddListener(_levelMenuInteractor.GoToSelectedLevel);
               
                if (_levelDisplays[i].LevelDescription._number == 1)
                    button.interactable = true;
                else
                    button.interactable = levelDescriptions.Find(x => x._buildIndex + 1 == _levelDisplays[i].LevelDescription._buildIndex)._isCompleted;
            }
            Debug.Log("Set up level menu content");
        }

        private void UpdateContent()
        {
            if (!_levelMenuInteractor.IsLocationChanged())
                return;

            List<LevelDescription> levelDescriptions = _levelMenuInteractor.GetCurrentLocationLevelDescriptions();
            for (int i = 0; i < _levelDisplays.Count; i++)
            {
                Button button = _levelDisplays[i].GetComponent<Button>();
                button.interactable = false;
                _levelDisplays[i].LevelDescription = null;
                if (levelDescriptions[i] == null)
                    continue;
                
                _levelDisplays[i].LevelDescription = levelDescriptions[i];
                if (_levelDisplays[i].LevelDescription._number == 1)
                    button.interactable = true;
                else
                    button.interactable = levelDescriptions.Find(x => x._buildIndex + 1 == _levelDisplays[i].LevelDescription._buildIndex)._isCompleted;
            }

            Debug.Log("Update level menu content");
        }

        private void ClearContent()
        {
            foreach (LevelDisplay levelDisplay in _levelDisplays)
            {
                Destroy(levelDisplay.gameObject);
            }
        }

        public override void ShowContent()
        {
            base.ShowContent();
            UpdateContent();
        }
    }
}
