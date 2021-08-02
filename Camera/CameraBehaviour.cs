using UnityEngine;

namespace Camera
{
    public class CameraBehaviour : MonoBehaviour
    {
        public Transform target;

        private void LateUpdate()
        {
            var t = transform;
            t.position = target.position;
            t.rotation = target.rotation;
        }
    }
}