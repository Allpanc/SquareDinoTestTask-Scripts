namespace SquareDinoTestTask.Character.Enemy.States
{
    public class IdleState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isAttacking", false);
        }
    }
}
