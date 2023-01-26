using SquareDinoTestTask.Menu;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquareDinoTestTask.Data
{
    static class LevelDescriptionRepository
    {
        public static List<LevelDescription> _levelsDescriptions = new List<LevelDescription>();

        public static void Initialize()
        {
            _levelsDescriptions = SaveLoadSystem.LoadLevelDescriptions();
        }

        public static void PrintAllLevels()
        {
            _levelsDescriptions.ForEach(x => Debug.Log(x._location + " " + x._number + " " + x._isCompleted));
        }

        public static void SaveCurrentLevel()
        {
            int currentLevelBuildIndex = SceneManager.GetActiveScene().buildIndex;
            LevelDescription levelDescription = _levelsDescriptions.Find(x => x._buildIndex == currentLevelBuildIndex);
            _levelsDescriptions.Remove(levelDescription);
            levelDescription._isCompleted = true;
            _levelsDescriptions.Add(levelDescription);
        }

        public static List<LevelDescription> GetLevelDescriptionsByLocation(Location location)
        {
            try
            {
                LevelDescriptionComparer comparer = new LevelDescriptionComparer();
                List<LevelDescription> list = _levelsDescriptions.FindAll(x => x._location == location);
                list.Sort(comparer);
                return list;
            }
            catch (NullReferenceException)
            {
                Debug.LogError("Null level desctiption list");
                return null;
            }       
        }

        private class LevelDescriptionComparer : IComparer<LevelDescription>
        {
            public int Compare(LevelDescription x, LevelDescription y)
            {
                return x._number.CompareTo(y._number);
            }
        }
    }
}