using SquareDinoTestTask.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SquareDinoTestTask.Menu
{
    [RequireComponent(typeof(Button))]
    public class LevelDisplay : MonoBehaviour
    {
        [SerializeField] private LevelDescription levelDescription;
        [SerializeField] private TMP_Text text;

        public TMP_Text Text { get => text; set => text = value; }
        public LevelDescription LevelDescription { get => levelDescription; set => levelDescription = value; }
    }
}
