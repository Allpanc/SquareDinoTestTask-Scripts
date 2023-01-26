using UnityEngine;
using UnityEngine.Events;

namespace SquareDinoTestTask.Character.Health
{
    public class HealthController : MonoBehaviour
    {
        public int _maxHealth;
        public int _currentHealth;
        public UnityEvent<int> OnHealed = new UnityEvent<int>();
        public UnityEvent<int> OnDamaged = new UnityEvent<int>();
        public UnityEvent OnNoHealthLeft = new UnityEvent();

        [SerializeField] HealthBar _healthBar;

        private void Start()
        {
            _currentHealth = _maxHealth;
            if (_healthBar != null)
            {
                _healthBar.Initialize(_currentHealth);
                OnDamaged.AddListener(_healthBar.ChangeValueTo);
                OnHealed.AddListener(_healthBar.ChangeValueTo);
            }
        }

        public void TakeDamage(int damage)
        {
            if (_currentHealth == 0)
                return;

            _currentHealth = _currentHealth <= 0 ? 0 : _currentHealth -= damage;
            OnDamaged.Invoke(_currentHealth);

            if (_currentHealth == 0)
            {
                OnNoHealthLeft.Invoke();
            }
        }

        public void Heal(int healthPoints)
        {
            if (_currentHealth == _maxHealth)
                return;

            if (_currentHealth + healthPoints > _maxHealth)
                _currentHealth = _maxHealth;
            else
                _currentHealth += healthPoints;

            OnHealed.Invoke(_currentHealth);
        }
    }
}
