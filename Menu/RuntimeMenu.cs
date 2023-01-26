using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SquareDinoTestTask
{
    public class RuntimeMenu : MonoBehaviour
    {
        [SerializeField] Button _menuButton;

        // Start is called before the first frame update
        void Start()
        {
            _menuButton.onClick.AddListener(LoadMenuScene);
        }

        private void LoadMenuScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
