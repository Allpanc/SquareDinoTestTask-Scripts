using UnityEngine;

namespace SquareDinoTestTask.Character.Enemy.States
{
    public class StateMachine : MonoBehaviour
    {
        public enum States
        {
            Idle,
            Walk,
            Attack
        };

        public BaseState _currentState { get; private set; }

        private WalkingState _walkingState = new WalkingState();
        private IdleState _idleState = new IdleState();
        private AttackingState _attackingState = new AttackingState();

        public void Initialize(EnemyController enemy)
        {
            _walkingState.Initialize(enemy);
            _idleState.Initialize(enemy);
            _attackingState.Initialize(enemy);
        }

        void Update()
        {
            if (_currentState != null)
                _currentState.Tick();
        }

        public void SetState(States state)
        {
            switch (state)
            {
                case States.Idle:
                    _currentState = _idleState;
                    break;
                case States.Walk:
                    _currentState = _walkingState;
                    break;
                case States.Attack:
                    _currentState = _attackingState;
                    break;
                default:
                    _currentState = _idleState;
                    break;
            }
            _currentState.Enter();
        }

        public bool IsInWalktate()
        {
            return IsInState(States.Walk);
        }

        public bool IsInIdleState()
        {
            return IsInState(States.Idle);
        }

        public bool IsInAttackingState()
        {
            return IsInState(States.Attack);
        }

        private bool IsInState(States state)
        {
            BaseState stateToCheck;

            switch (state)
            {
                case States.Idle:
                    stateToCheck = _idleState;
                    break;
                case States.Walk:
                    stateToCheck = _walkingState;
                    break;
                case States.Attack:
                    stateToCheck = _attackingState;
                    break;
                default:
                    stateToCheck = _idleState;
                    break;
            }

            return _currentState == stateToCheck;
        }
    }
}