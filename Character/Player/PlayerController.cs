using SquareDinoTestTask.Character.Player.States;
using SquareDinoTestTask.Way;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SquareDinoTestTask.Character.Player
{
    public class PlayerController : CustomCharacterController
    {
        private StateMachine _stateMachine;
        private ShootingSystem _shootingSystem;
        public bool _isActive { get; private set; }

        public override void Awake()
        {
            base.Awake();
        }

        void Start()
        {
            WayPoint.OnCompleted.AddListener(Run);
            CheckPoint.OnReached.AddListener(Idle);

            InputController.OnFirstTapDone.AddListener(Activate);
            InputController.OnTapped.AddListener(Shoot);
            InputController.OnFirstTapDone.AddListener(Run);

            _shootingSystem = GetComponent<ShootingSystem>();
            _stateMachine = GetComponent<StateMachine>();
            StartCoroutine(InitialIdle());         
        }

        private void Run()
        {
            _stateMachine.SetState(StateMachine.States.Run);
        }

        private void Idle()
        {
            _stateMachine.SetState(StateMachine.States.Idle);
        }

        public void Shoot()
        {
            if (!_isActive)
                return;

            _animator.SetTrigger("Shoot");
            _shootingSystem.Fire();
        }

        private void Activate()
        {
            _isActive = true;
        }

        public override void Die()
        {
            base.Die();
            _isActive = false;
        }

        IEnumerator InitialIdle()
        {
            yield return null;
            Idle();
        }
    }
}