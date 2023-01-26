using SquareDinoTestTask.Way;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SquareDinoTestTask
{
    public class WayDisplay : MonoBehaviour
    {
        [SerializeField] Slider _progressBar;
        [SerializeField] TMP_Text _wayPointCounterText;
        [SerializeField] float _progressBarUpdateSpeed = 2;

        float _startValue;
        float _amountToFill;
        int _wayPointsNumber;
        int _wayPointsCounter = 0;
        float _progressStep;
        bool _isSliderUpdateAllowed;

        // Start is called before the first frame update
        void Start()
        {
            _startValue = _progressBar.value;
            _amountToFill = _progressBar.maxValue - _startValue;
            _wayPointsNumber = FindObjectsOfType<WayPoint>().Length - 2;
            _wayPointCounterText.text = _wayPointsNumber.ToString();
            _progressStep = _amountToFill / _wayPointsNumber;
            WayPoint.OnCompleted.AddListener(UpdateDisplayData);
        }

        private void Update()
        {
            if (!_isSliderUpdateAllowed)
                return;

            if (_progressBar.value < _startValue + _progressStep * _wayPointsCounter)
                _progressBar.value += _progressStep / 10 * Time.deltaTime  * _progressBarUpdateSpeed;
            else
               _isSliderUpdateAllowed = false;          
        }

        private void UpdateDisplayData()
        {
            _wayPointsCounter++;
            _isSliderUpdateAllowed = true;
            _wayPointCounterText.text = (_wayPointsNumber - _wayPointsCounter).ToString();
        }
    }
}
