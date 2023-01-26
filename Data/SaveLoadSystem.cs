using SquareDinoTestTask.Menu;
using SquareDinoTestTask.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquareDinoTestTask.Data
{
    public class SaveLoadSystem
    {
        private static string _path = Application.persistentDataPath + @"\progress.json";

        public static void Initialize()
        {
            //PlayerPrefs.DeleteAll();
            if (String.IsNullOrEmpty(PlayerPrefs.GetString("isFirstLaunch")))
            {
                PlayerPrefs.SetString("isFirstLaunch", "No");
                Debug.Log("Null first launch");
            }

            if (PlayerPrefs.GetString("isFirstLaunch") == "No")
            {
                InitializeLevelDescriptions();
                PlayerPrefs.SetString("isFirstLaunch", "Yes");
                Debug.Log("Set first launch to yes");
            }
            
            Debug.Log("Save Load System: Initialized");
        }

        public static void SaveLevelDescriptions()
        {
            string jsonString = JsonHelper.ToJson(LevelDescriptionRepository._levelsDescriptions.ToArray());
            File.WriteAllText(_path, jsonString);
            Debug.Log("Save Load System: Saved");
        }

        public static List<LevelDescription> LoadLevelDescriptions()
        {
            string jsonString = File.ReadAllText(_path);
            LevelDescription[] levelDescriptions = JsonHelper.FromJson<LevelDescription>(jsonString);
            Debug.Log(levelDescriptions.Length);
            return levelDescriptions.ToList();
        }

        private static void InitializeLevelDescriptions()
        {
            List<LevelDescription> levelDescriptions = new List<LevelDescription>();

            foreach (Location location in Enum.GetValues(typeof(Location)))
            {
                for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
                {
                    string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                    string sceneNamePattern = location.ToString() + @" \d+";
                    string levelNumberPattern = @"\d+";
                    if (Regex.IsMatch(scenePath, sceneNamePattern))
                    {
                        Match match = Regex.Match(scenePath, levelNumberPattern);
                        int levelNumber = int.Parse(match.Value);
                        LevelDescription levelDescription = new LevelDescription(location, levelNumber, i);
                        levelDescriptions.Add(levelDescription);
                    }
                }
            }

            string jsonString = JsonHelper.ToJson(levelDescriptions.ToArray());
            Debug.Log(jsonString);

            File.WriteAllText(_path, jsonString);
        }      
    }
}
