using SquareDinoTestTask.Character.Player;
using UnityEngine;

namespace SquareDinoTestTask.Way.Spawn
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] PlayerController _spawnedObject;
        [SerializeField] Transform _spawnTransform;
        [SerializeField] bool _spawnOnAwake;

        private void Awake()
        {
            if (_spawnOnAwake)
                Spawn();            
        }

        public void Spawn()
        {
            Instantiate<PlayerController>(_spawnedObject, _spawnTransform.position, _spawnTransform.rotation);
        }
    }
}
