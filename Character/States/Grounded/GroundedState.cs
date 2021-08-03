using Character.Motor;
using Character.States.Airborne;
using Character.States.Grounded.Crouching;
using UnityEngine;

namespace Character.States.Grounded
{
    public abstract class GroundedState : CharacterState
    {
        protected float Speed;
        protected float Deceleration;
        protected float Acceleration;
        
        protected GroundedState(CharacterBehaviour character) : base(character)
        {
        }
        
        public override void OnEnter()
        {
            Speed = Character.motor.data.groundedSpeed;
            Acceleration = Character.motor.data.groundedAcceleration;
            Deceleration = Character.motor.data.groundedDeceleration;
        }

        public override void OnExit()
        {
        }

        public override void OnPhysicsUpdate()
        {
            var velocity = Character.motor.Velocity;
            var direction = Character.motor.direction;

            MotorHelper.Decelerate(ref velocity, Deceleration * Time.deltaTime);
            MotorHelper.Accelerate(ref velocity, direction, Acceleration * Time.deltaTime, Speed);
            
            Character.motor.SetVelocity(velocity);
        }

        public override void OnLogicUpdate()
        {
            if (!Character.motor.IsGrounded)
            {
                Character.StateMachine.SetState<FallingState>();
            }
        }

        public override void OnAction(string action, bool shouldPerform)
        {
            switch (action)
            {
                case CharacterActions.Crouch when shouldPerform:
                    Character.StateMachine.SetState<CrouchIdleState>();
                    break;
                case CharacterActions.Jump when shouldPerform:
                    Character.StateMachine.SetState<JumpingState>();
                    break;
            }
        }
    }
}