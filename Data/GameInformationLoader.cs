using SquareDinoTestTask.Data;
using SquareDinoTestTask.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquareDinoTestTask.Data
{
    public class GameInformationLoader : MonoBehaviour
    {
        private void Awake()
        {
            //Debug.Log(Application.persistentDataPath);
            SaveLoadSystem.Initialize();
            LevelDescriptionRepository.Initialize();
            DontDestroyOnLoad(this);
        }
    }
}
