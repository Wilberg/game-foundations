using UnityEngine;

namespace Character.Motor
{
    public static class MotorHelper
    {
        public static void Accelerate(ref Vector3 velocity, Vector3 direction, float acceleration, float speed)
        {
            var speedInDirection = Vector3.Dot(velocity, direction);
            var speedLeft = speed - speedInDirection;
            if (speedLeft < 0) return;
            
            var accelerationTick = speed * acceleration;
            if (accelerationTick > speedLeft) accelerationTick = speedLeft;
            
            velocity += direction * accelerationTick;
        }

        public static void Decelerate(ref Vector3 velocity, float deceleration)
        {
            var velY = velocity.y;
            var speed = velocity.magnitude;
            if (0.0f >= speed) return;

            var drop = speed * deceleration;
            if (speed < 1.0f) drop = speed;
            
            velocity *= Mathf.Max(speed - drop, 0) / speed;
            velocity.y = velY;
        }

        public static void Launch(ref Vector3 velocity, Vector3 direction, float speed)
        {
            velocity += direction * speed;
        }
    }
}