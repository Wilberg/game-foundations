using Character.Motor;
using Character.States.Airborne;
using UnityEngine;

namespace Character.States.Grounded
{
    public abstract class GroundedState : CharacterState
    {
        protected GroundedState(CharacterBehaviour character) : base(character)
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
            
            var acceleration = Character.motor.data.groundedAcceleration;
            var deceleration = Character.motor.data.groundedDeceleration;
            var speed = Character.motor.data.groundedSpeed;
            
            MotorHelper.Decelerate(ref velocity, deceleration * Time.deltaTime);
            MotorHelper.Accelerate(ref velocity, direction, acceleration * Time.deltaTime, speed);
            
            Character.motor.SetVelocity(velocity);
        }

        public override void OnLogicUpdate()
        {
            if (!Character.motor.IsGrounded)
            {
                Character.StateMachine.SetState<FallingState>();
            }
        }

        public override void OnAction(string action)
        {
        }
    }
}