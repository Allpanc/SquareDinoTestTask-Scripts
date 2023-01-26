using UnityEngine;
using SquareDinoTestTask.Character.Enemy.States;
using SquareDinoTestTask.Way;
using SquareDinoTestTask.Character.Player;

namespace SquareDinoTestTask.Character.Enemy
{
    public class EnemyController : CustomCharacterController
    {
        [SerializeField] EnemyWearpon _wearpon;
        private StateMachine _stateMachine;
        
        public bool _isVulnerable;
        public int _health = 3;        
        public Vector3 _initialPosition { get; private set; }
        public Quaternion _initialRotation { get; private set; }

        private void Start()
        {
            _initialPosition = transform.position;
            _initialRotation = transform.rotation;

            _stateMachine = GetComponent<StateMachine>();
            _stateMachine.Initialize(this);
            _wearpon._owner = this;
            CheckPoint.OnReached.AddListener(Walk);
            Idle();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);

            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet == null || bullet._isUsed)
                return;

            bullet._isUsed = true;
            bullet.GetComponent<Rigidbody>().velocity /= 5;
         
            TakeDamage();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null && !_stateMachine.IsInAttackingState()) 
            {
                Attack();
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                transform.LookAt(player.transform);
                transform.Rotate(new Vector3(0, 50, 0));
            }              
        }

        private void Idle()
        {
            Debug.Log("Idle");
            _stateMachine.SetState(StateMachine.States.Idle);
        }

        private void Walk ()
        {
            if (!_isVulnerable)
                return;

            Debug.Log("Walk");
            _stateMachine.SetState(StateMachine.States.Walk);
        }

        private void Attack()
        {
            Debug.Log("Attack");
            _agent.enabled = false;
            _stateMachine.SetState(StateMachine.States.Attack);
        }

        private void TakeDamage()
        {
            if (_isVulnerable)
            {
                _healthController.TakeDamage(1);
                Debug.Log("Attacked " + gameObject.name);
            }
        }

        public override void Die()
        {
            base.Die();
            _agent.enabled = false;
            _animator.enabled = false;
            _collider.enabled = false;
            _wearpon.Deactivate();
            FixRagdollPhysics();
            enabled = false;
        }

        public bool IsAttacking()
        {
            return _stateMachine.IsInAttackingState();
        }

        private void FixRagdollPhysics()
        {
            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            {
                rb.velocity /= 10;
            }
        }

        public void SetToInitialState()
        {
            transform.position = _initialPosition;
            transform.rotation = _initialRotation;
            _isVulnerable = false;
            _agent.enabled = true;
            _animator.enabled = true;
            _collider.enabled = true;
            _wearpon.Deactivate();
            Idle();
        }
    }
}