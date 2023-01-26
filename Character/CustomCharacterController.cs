using SquareDinoTestTask.Character.Health;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


namespace SquareDinoTestTask.Character
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(HealthController))]

    public class CustomCharacterController : MonoBehaviour
    {
        protected Animator _animator;
        protected CapsuleCollider _collider;
        protected NavMeshAgent _agent;
        protected HealthController _healthController;
        public UnityEvent OnDead = new UnityEvent();

        public virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<CapsuleCollider>();
            _agent = GetComponent<NavMeshAgent>();
            _healthController = GetComponent<HealthController>();

            _healthController.OnNoHealthLeft.AddListener(Die);
        }

        public virtual void Die() 
        {
            OnDead.Invoke();
            Debug.Log(gameObject.name + " died");
        }
    }
}
