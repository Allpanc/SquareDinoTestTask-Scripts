using SquareDinoTestTask.Character.Player;
using SquareDinoTestTask.Data;
using SquareDinoTestTask.Way;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquareDinoTestTask.Level
{
    public class LevelPlayer : MonoBehaviour
    {
        [SerializeField] PlayerController _player;
        protected WayController _way;
        [SerializeField] bool _reloadLevelOnPlayerKilled = true;
        [SerializeField] bool _goToNextLevelOnCurrentLevelEnd = true;
        private static LevelPlayer _instance;
        
        public static LevelPlayer Instance { get => _instance; set => _instance = value; }
        void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                _instance = this;
        }

        void Start()
        {
            
            _player = FindObjectOfType<PlayerController>();
            _way = FindObjectOfType<WayController>();
            if (_reloadLevelOnPlayerKilled)
            {
                _player.OnDead.AddListener(PlayCurrentLevel);
                //Debug.Log(_player.name + " on dead subscribed to reload");
            }

            if (_goToNextLevelOnCurrentLevelEnd)
                CheckPoint.OnReached.AddListener(PlayNextLevel);
        }

        public void PlayCurrentLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void PlayNextLevel()
        {
            //Debug.Log("TryPlayNextLevel");
            if (!_way.IsLastPointReached())
                return;

            LevelDescriptionRepository.SaveCurrentLevel();
            SaveLoadSystem.SaveLevelDescriptions();
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(nextSceneIndex);
            else
                SceneManager.LoadScene(0);
        }


    }
}
