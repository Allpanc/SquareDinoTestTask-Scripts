using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SquareDinoTestTask
{
    public class InputController : MonoBehaviour
    {
        public static UnityEvent OnFirstTapDone = new UnityEvent();
        public static UnityEvent OnTapped = new UnityEvent();

        private bool _isFirstTapDone;
        private float _timeoutAfterFirstTap = 0.2f;
        private float _firstTapime;

        public static InputController _instance { get; private set; }

        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                _instance = this;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                if (IsPointerOverUI())
                    return;

                if (!_isFirstTapDone)
                {
                    OnFirstTapDone.Invoke();
                    _isFirstTapDone = true;
                    _firstTapime = Time.time;
                    Debug.Log("First tap");
                }
                else if (Time.time - _firstTapime > _timeoutAfterFirstTap)
                    OnTapped.Invoke();
            }
        }

        private bool IsPointerOverUI()
        {
#if (!UNITY_EDITOR)
        return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#endif
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}