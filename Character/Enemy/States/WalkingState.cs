using SquareDinoTestTask.Level;

namespace SquareDinoTestTask.Character.Enemy.States
{
    public class WalkingState : BaseState
    {

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isAttacking", false);
            _agent.SetDestination(_way.CurrentPoint._checkPoint.transform.position);
        }
    }
}
