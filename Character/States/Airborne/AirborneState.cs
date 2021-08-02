using Character.Motor;
using UnityEngine;

namespace Character.States.Airborne
{
    public abstract class AirborneState : CharacterState
    {
        protected AirborneState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }
        
        public override void OnPhysicsUpdate()
        {
            var velocity = Character.motor.Velocity;
            var direction = Character.motor.direction;
            
            var acceleration = Character.motor.data.airborneAcceleration;
            var speed = Character.motor.data.airborneSpeed;
            
            MotorHelper.Accelerate(ref velocity, direction, acceleration * Time.deltaTime, speed);
            
            Character.motor.SetVelocity(velocity);
        }

        public override void OnLogicUpdate()
        {
        }

        public override void OnAction(string action)
        {
        }
    }
}