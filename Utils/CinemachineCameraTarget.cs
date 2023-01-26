using UnityEngine;
using Cinemachine;

namespace SquareDinoTestTask.Utils
{
    public class CinemachineCameraTarget : MonoBehaviour
    {
        [SerializeField] Transform _follow;
        [SerializeField] Transform _lookAt;

        private void Start()
        {
            BindCameraToThis();
        }

        public void BindCameraToThis()
        {
            CinemachineVirtualCamera camera = FindObjectOfType<CinemachineVirtualCamera>();
            camera.Follow = _follow;
            camera.LookAt = _lookAt;
        }
    }
}
