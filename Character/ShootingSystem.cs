using UnityEngine;

namespace SquareDinoTestTask.Character
{
    public class ShootingSystem : MonoBehaviour
    {
        [SerializeField] float _shootingForce = 5;
        [SerializeField] Transform _startBulletLocation;
        [SerializeField] float _timeBetweenShots = 0.1f;
        [SerializeField] LayerMask _ignoreLayerMask;
        
        [SerializeField]  float _maxX = 0.6f;
        [SerializeField]  float _maxZ = 0.3f;
        [SerializeField] float _closeShotMaxDistance = 1f;

        private float _lastShotTime;
        private bool isReady = true;
        private ObjectPool _pool;

        private void Start()
        {
            _pool = FindObjectOfType<ObjectPool>();
        }

        private void Update()
        {
            if (Time.time - _lastShotTime > _timeBetweenShots)
                isReady = true;
        }

        public void Fire()
        {
            if (!isReady)
                return;

            GameObject bullet = _pool.Get().gameObject;
            if (bullet == null)
                return;

            Vector3 clickPosition;

#if (!UNITY_EDITOR)
        clickPosition = Input.GetTouch(0).position;
#endif
            clickPosition = Input.mousePosition;
            Vector3 shootingDirection = GetShootingDirection(clickPosition);

            if (shootingDirection == Vector3.zero)
                return;

            bullet.SetActive(true);
            bullet.transform.position = _startBulletLocation.position;
            bullet.GetComponent<Rigidbody>().freezeRotation = false;
            bullet.transform.forward = shootingDirection.normalized;
            bullet.GetComponent<Rigidbody>().freezeRotation = true;
            bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * _shootingForce, ForceMode.Impulse);

            _lastShotTime = Time.time;
            isReady = false;
        }

        private Vector3 GetShootingDirection(Vector3 clickPosition)
        {
            clickPosition.z = Camera.main.nearClipPlane + 1;

            Ray ray = Camera.main.ScreenPointToRay(clickPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,1000,~_ignoreLayerMask))
            {
                Vector3 worldClickPosition = ray.GetPoint(hit.distance);
                Vector3 shootingDirection;
                if (hit.distance < _closeShotMaxDistance)
                {
                    shootingDirection = hit.transform.position - _startBulletLocation.position;// hit.point - _startBulletLocation.position;
                    //Debug.Log("Short shot");
                }
                else
                {
                    shootingDirection = (worldClickPosition - _startBulletLocation.position).normalized;
                    shootingDirection = LimitShootDirection(shootingDirection);
                }

                Debug.DrawRay(_startBulletLocation.position, shootingDirection * 100, Color.red, 5f);
                //Debug.LogWarning("Hit " + hit.transform.gameObject.name);
                //Debug.Log("worldClickPosition = " + worldClickPosition + " _startBulletLocation.position " + _startBulletLocation.position + " shootingDirection" + shootingDirection);
                //Debug.Log("hit.distance = " + hit.distance + " hit.gameObject =" + hit.transform.gameObject);
                return shootingDirection;
            }
            return Vector3.zero;
        }

        private Vector3 LimitShootDirection(Vector3 shootingDirection)
        {
            if (Mathf.Abs(shootingDirection.y) > _maxZ)
                shootingDirection.y = shootingDirection.y > 0 ? _maxZ : -_maxZ;
            if (Mathf.Abs(shootingDirection.x) > _maxX)
                shootingDirection.x = shootingDirection.x > 0 ? _maxX : -_maxX;
            return shootingDirection;
        }
    }
}