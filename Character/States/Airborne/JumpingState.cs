using Character.Motor;
using UnityEngine;

namespace Character.States.Airborne
{
    public class JumpingState : AirborneState
    {
        public JumpingState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Character.motor.disableStickToGround = true;
            
            var velocity = Character.motor.Velocity;
            
            var jumpSpeed = Mathf.Sqrt(2.0f * Physics.gravity.magnitude * 1.0f);
            
            MotorHelper.Launch(ref velocity, Vector3.up, jumpSpeed);
            
            Character.motor.SetVelocity(velocity);
        }

        public override void OnPhysicsUpdate()
        {
            base.OnLogicUpdate();
            
            if (Character.motor.Velocity.y < -0.1f)
            {
                Character.StateMachine.SetState<FallingState>();
            }
        }
    }
}