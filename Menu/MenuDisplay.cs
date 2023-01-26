using UnityEngine;

namespace SquareDinoTestTask.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class MenuDisplay : MonoBehaviour
    {
        [SerializeField] MenuType _menuType;

        private Canvas _canvas;
        public MenuType MenuType { get => _menuType; set => _menuType = value; }

        protected virtual void Start()
        {
            _canvas = GetComponent<Canvas>();
        }

        public virtual void ShowContent()
        {
            _canvas.enabled = true;
        }

        public virtual void HideContent()
        {
            _canvas.enabled = false;
        }
    }
}
