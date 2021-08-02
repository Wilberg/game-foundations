using System;
using UnityEngine;

namespace Character.Motor
{
    [Serializable]
    public class MotorData
    {
        [Header("Speed")]
        public float groundedSpeed = 10.0f;
        public float airborneSpeed = 1.0f;

        [Header("Acceleration")]
        public float groundedAcceleration = 10.0f;
        public float airborneAcceleration = 300.0f;
        
        [Header("Deceleration")]
        public float groundedDeceleration = 10.0f;
        public float airborneDeceleration = 0.0f;
    }
}