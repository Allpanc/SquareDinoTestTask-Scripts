using UnityEngine;
using SquareDinoTestTask.Level;

namespace SquareDinoTestTask.Character.Player.States 
{
    public class IdleState : BaseState
    {
        public override void Initialize(PlayerController player)
        {
            base.Initialize(player);
        }

        public override void Enter()
        {
            base.Enter();
            _animator.SetBool("isRunning", false);
            Debug.LogWarning("Idle");
        }

        public override void Tick()
        {
            base.Tick();
            if (_player._isActive)
                RotateToEnemy();
        }

        private void RotateToEnemy()
        {
            Vector3 lookPosition =  _way.CurrentPoint._enemiesLocation.position;
            Vector3 direction = (lookPosition - _player.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, lookRotation, Time.deltaTime * 5);
        }
    }
}