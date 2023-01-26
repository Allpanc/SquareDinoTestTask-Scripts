using UnityEngine;

namespace SquareDinoTestTask
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] AudioSource _backgroundMusicSource;

        public void OnSoundButtonClick()
        {
            _backgroundMusicSource.volume = _backgroundMusicSource.volume > 0 ? 0 : 1;
        }
    }
}
