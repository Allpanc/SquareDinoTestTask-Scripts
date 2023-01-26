using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;
using SquareDinoTestTask.Character.Enemy;

namespace SquareDinoTestTask.Way
{
    //[RequireComponent(typeof(Collider))]
    public class WayPoint : MonoBehaviour
    {
        public static UnityEvent OnCompleted = new UnityEvent();
        public int _index;
        public CheckPoint _checkPoint;
        public Transform _enemiesLocation;
        public List<EnemyController> _enemies { get; private set; }

        private void Start()
        {
            _enemies = _enemiesLocation.GetComponentsInChildren<EnemyController>().ToList();
            foreach (EnemyController enemy in _enemies)
            {
                enemy.OnDead.AddListener(CheckEnemyNumber);
            }
        }

        public void ActivateEnemies()
        {
            foreach (EnemyController enemy in _enemies)
            {
                enemy._isVulnerable = true;
            }
        }

        public void ResetWayBlock()
        {
            foreach (EnemyController enemy in _enemies)
            {
                enemy.SetToInitialState();
            }
            _checkPoint.IsReached = false;
        }

        private void CheckEnemyNumber()
        {
            //Debug.Log("Check enemy number");
            StartCoroutine(UpdateEnemiesList());
        }

        IEnumerator UpdateEnemiesList()
        {
            yield return null;

            for (int i = 0; i < _enemies.Count; i++)
            {
                if (!_enemies[i].enabled)
                    _enemies.RemoveAt(i);
            }
            if (_enemies.Count == 0)
                OnCompleted.Invoke();
        }
    }
}