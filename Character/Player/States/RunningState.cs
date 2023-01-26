using SquareDinoTestTask.Level;
using UnityEngine;

namespace SquareDinoTestTask.Character.Player.States
{
    public class RunningState : BaseState
    {
        public override void Initialize(PlayerController player)
        {
            base.Initialize(player);
        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isRunning", true);
            Debug.LogWarning("Running");
            _way.SetCurrentPointToNext();

            _agent.SetDestination(_way.CurrentPoint._checkPoint.transform.position);
        }
    }
}