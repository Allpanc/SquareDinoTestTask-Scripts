using SquareDinoTestTask.Way;
using UnityEngine;
using UnityEngine.AI;

namespace SquareDinoTestTask.Character.Player.States
{
    public class BaseState
    {
        protected PlayerController _player;
        protected Animator _animator;
        protected NavMeshAgent _agent;
        protected WayController _way;

        public virtual void Initialize(PlayerController player)
        {
            _player = player;
            _animator = _player.GetComponent<Animator>();
            _agent = _player.GetComponent<NavMeshAgent>();
            _way = GameObject.FindObjectOfType<WayController>();
        }

        public virtual void Enter() 
        {
            if (_player == null)
                Debug.LogError("Null player");

            if (_animator == null)
                _animator = _player.GetComponent<Animator>();

            if (_agent == null)
                _agent = _player.GetComponent<NavMeshAgent>();
        }

        public virtual void Tick() { }
    }
}