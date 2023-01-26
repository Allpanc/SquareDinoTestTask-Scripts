using UnityEngine;
using UnityEngine.UI;

namespace SquareDinoTestTask.Character.Health
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        private float _totalHealth;
        private Slider _slider;

        public void Initialize(float totalHealth)
        {
            _totalHealth = totalHealth;
            _slider = GetComponent<Slider>();
            _slider.value = 1;
        }

        public void ChangeValueTo(int currentHealth)
        {
            float targetSliderValue = currentHealth / _totalHealth;

            if (targetSliderValue > 1)
                targetSliderValue = 1;
            else if (targetSliderValue <= 0)
            {
                targetSliderValue = 0;
                gameObject.SetActive(false);
            }

            _slider.value = targetSliderValue;
        }
    }
}