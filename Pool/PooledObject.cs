using UnityEngine;

namespace SquareDinoTestTask
{
    public class PooledObject : MonoBehaviour
    {
        private ObjectPool _ownerPool;
        public ObjectPool OwnerPool { get => _ownerPool; set => _ownerPool = value; }
    }
}
