using SquareDinoTestTask.Character.Player;
using UnityEngine;

namespace SquareDinoTestTask.Character.Enemy
{
    public class EnemyWearpon : MonoBehaviour
    {
        private Collider _collider;
        public EnemyController _owner;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (!_owner.IsAttacking())
                return;
            if (collider.gameObject.GetComponent<PlayerController>() != null)
            {
                PlayerController player = collider.gameObject.GetComponent<PlayerController>();
                player.Die();
            }
        }

        public void Deactivate()
        {
            _collider.enabled = false;
        }
    }
}
