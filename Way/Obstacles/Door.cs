using SquareDinoTestTask.Character.Player;
using UnityEngine;

namespace SquareDinoTestTask.Way.Obstacles
{
    [RequireComponent(typeof(SphereCollider))]
    public class Door : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
                _animator.SetBool("character_nearby", true);
        }
    }
}
