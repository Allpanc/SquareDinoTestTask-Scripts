using System.Collections.Generic;
using UnityEngine;

namespace SquareDinoTestTask
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] List<PooledObject> _pooledObjects;
        [SerializeField] PooledObject _objectToPool;
        [SerializeField] int _amountToPool;

        private void Start()
        {
            PooledObject tmp;
            for (int i = 0; i < _amountToPool; i++)
            {
                tmp = Instantiate(_objectToPool);
                tmp.OwnerPool = this;
                tmp.gameObject.SetActive(false);
                _pooledObjects.Add(tmp);
            }
        }

        public PooledObject Get()
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                if (!_pooledObjects[i].gameObject.activeInHierarchy)
                    return _pooledObjects[i];
            }
            return null;
        }

        public void Release(PooledObject objectToRelease, float releaseTime = 0)
        {
            if (_pooledObjects.Contains(objectToRelease))
            {
                objectToRelease.gameObject.SetActive(false);
                //Debug.Log("Release");
            }
        }
    }
}