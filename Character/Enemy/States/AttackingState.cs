using SquareDinoTestTask.Character.Player;
using UnityEngine;

namespace SquareDinoTestTask.Character.Enemy.States
{
    public class AttackingState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isAttacking", true);
            int attackIndex = Random.Range(1, 3);
            _animator.SetInteger("attackIndex", attackIndex);
            _agent.enabled = false;
        }

        public override void Tick()
        {
            base.Tick();
        }
    }
}
