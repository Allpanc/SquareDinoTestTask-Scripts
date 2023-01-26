using SquareDinoTestTask.Menu;
using System;

namespace SquareDinoTestTask.Data
{
    [Serializable]
    public class LevelDescription
    {
        public Location _location;
        public int _number;
        public int _buildIndex;
        public bool _isCompleted;

        public LevelDescription(Location location, int number, int buildIndex, bool isCompleted = false)
        {
            _location = location;
            _number = number;
            _buildIndex = buildIndex;
            _isCompleted = isCompleted;
        }

        public string GetName()
        {
            return _location.ToString() + " " + _number.ToString();
        }
    }
}
