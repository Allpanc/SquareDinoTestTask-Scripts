using SquareDinoTestTask.Way;
using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestTask.Character.Enemy.States
{
    public class BaseState
    {
        protected EnemyController _enemy;
        protected Animator _animator;
        protected NavMeshAgent _agent;
        protected WayController _way;

        public virtual void Initialize(EnemyController enemy)
        {
            _enemy = enemy;
            _animator = _enemy.GetComponent<Animator>();
            _agent = _enemy.GetComponent<NavMeshAgent>();
            _way = GameObject.FindObjectOfType<WayController>();
        }

        public virtual void Enter()
        {
        }

        public virtual void Tick() { }
    }
}