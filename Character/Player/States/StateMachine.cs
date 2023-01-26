using UnityEngine;

namespace SquareDinoTestTask.Character.Player.States
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] PlayerController _player;
        private RunningState _runningState = new RunningState();
        private IdleState _idleState = new IdleState();

        public BaseState _currentState { get; private set; }
        public enum States
        {
            Run,
            Idle
        };

        void Start()
        {
            InitializeStates();
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
                case States.Run:
                    _currentState = _runningState;
                    break;
                default:
                    _currentState = _idleState;
                    break;
            }
            _currentState.Enter();
        }

        public bool IsInRunState()
        {
            return IsInState(States.Run);
        }

        public bool IsInIdleState()
        {
            return IsInState(States.Idle);
        }

        private bool IsInState(States state)
        {
            BaseState stateToCheck;

            switch (state)
            {
                case States.Idle:
                    stateToCheck = _idleState;
                    break;
                case States.Run:
                    stateToCheck = _runningState;
                    break;
                default:
                    stateToCheck = _idleState;
                    break;
            }

            return _currentState == stateToCheck;
        }

        private void InitializeStates()
        {
            _runningState.Initialize(_player);
            _idleState.Initialize(_player);
        }
    }
}