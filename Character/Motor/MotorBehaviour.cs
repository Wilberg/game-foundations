using System;
using UnityEngine;

namespace Character.Motor
{
    [RequireComponent(typeof(Rigidbody))]
    public class MotorBehaviour : MonoBehaviour
    {
        public new Rigidbody rigidbody;
        
        [Space]
        public MotorData data;
        public Vector3 direction;
        public bool disableStickToGround;
        [Space]
        [Header("Ground Hover")]
        public float padding = 0.5f;
        public float dampening = 40.0f;
        public float strength = 2000.0f;
        public float threshold = 0.033f;

        private float _distance;

        public Vector3 Velocity { get; private set; }
        public bool IsGrounded { get; private set; }

        private void Update()
        {
            Velocity = rigidbody.velocity;
            IsGrounded = DetectGround();
        }
        
        private void FixedUpdate()
        {
            HandleGround();
        }

        public void SetVelocity(Vector3 velocity)
        {
            rigidbody.velocity = velocity;
        }

        private bool DetectGround()
        {
            const float buffer = 0.3f;
            var downDirection = Physics.gravity.normalized;
            var ray = new Ray(transform.position, downDirection);

            var length = padding + buffer;
            
            Debug.DrawRay(ray.origin, ray.direction * length, Color.red);

            if (!Physics.Raycast(ray, out var hit, length)) return false;

            _distance = hit.distance;
            return _distance < padding + threshold;
        }

        private void HandleGround()
        {
            if (!IsGrounded || disableStickToGround) return;

            var downDirection = Physics.gravity.normalized;
            var spring = (_distance - padding) * strength;
            var damper = Vector3.Dot(downDirection, rigidbody.velocity) * dampening;

            rigidbody.velocity += downDirection * ((spring - damper) * Time.deltaTime);
        }
    }
}