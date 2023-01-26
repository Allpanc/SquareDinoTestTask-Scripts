using SquareDinoTestTask.Character.Player;
using System;
using UnityEngine;

namespace SquareDinoTestTask.Way
{
    public class WayController : MonoBehaviour
    {
        [SerializeField] PlayerController _player;
        [SerializeField] private int _index;
        [SerializeField] private WayPoint _lastPoint;
        private WayPoint _currentPoint;

        public int _currentPointIndex = 0;
        public WayPoint[] _points;

        public int Index { get => _index; set => _index = value; }
        public WayPoint CurrentPoint { get => _currentPoint; set => _currentPoint = value; }

        void Start()
        {
            Initialize();

            if (_player == null)
                _player = FindObjectOfType<PlayerController>();
        }

        public void Initialize()
        {
            _points = GetComponentsInChildren<WayPoint>(false);
            Array.Sort(_points, new WayPointComparer());

            _lastPoint = _points[_points.Length - 1];

            if (_currentPointIndex == 0)
                _currentPoint = _points[_currentPointIndex];
        }

        public void ResetWayPoints()
        {
            _currentPointIndex = 0;
            foreach (WayPoint point in _points)
            {
                point.ResetWayBlock();
            }
        }

        public void SetCurrentPointToNext()
        {
            Debug.LogWarning("SetCurrentPointToNext" + _currentPointIndex);
            _currentPointIndex++;
            _currentPoint = _points[_currentPointIndex];
            _currentPoint.ActivateEnemies();
        }

        public bool IsLastPointReached()
        {
            return _lastPoint._checkPoint.IsReached;
        }
    }
}
