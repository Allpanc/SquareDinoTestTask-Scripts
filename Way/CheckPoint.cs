using UnityEngine;
using UnityEngine.Events;

namespace SquareDinoTestTask.Way
{
    public class CheckPoint : MonoBehaviour
    {
        public static UnityEvent OnReached = new UnityEvent();
        [SerializeField] bool _isReached;

        public bool IsReached { get => _isReached; set => _isReached = value; }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player") || _isReached)
                return;
            _isReached = true;
            OnReached.Invoke();
        }
    }
}