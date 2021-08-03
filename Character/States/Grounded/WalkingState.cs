using Character.States.Airborne;
using Character.States.Grounded.Crouching;
using UnityEngine;

namespace Character.States.Grounded
{
    public class WalkingState : GroundedState
    {
        public WalkingState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();

            if (Character.motor.Velocity.magnitude <= 0.1f)
            {
                Character.StateMachine.SetState<IdleState>();
            }
        }

        public override void OnAction(string action, bool shouldPerform)
        {
            base.OnAction(action, shouldPerform);
            
            switch (action)
            {
                case CharacterActions.Crouch when shouldPerform:
                    Character.StateMachine.SetState<CrouchWalkingState>();
                    break;;
                case CharacterActions.Jump when shouldPerform:
                    Character.StateMachine.SetState<JumpingState>();
                    break;
            }
        }
    }
}