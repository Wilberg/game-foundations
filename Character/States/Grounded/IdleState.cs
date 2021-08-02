using Character.States.Airborne;
using UnityEngine;

namespace Character.States.Grounded
{
    public class IdleState : GroundedState
    {
        public IdleState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();

            if (Character.motor.Velocity.magnitude > 0.1f)
            {
                Character.StateMachine.SetState<WalkingState>();
            }
        }

        public override void OnAction(string action)
        {
            base.OnAction(action);
            
            if (action == CharacterActions.Jump)
            {
                Character.StateMachine.SetState<JumpingState>();
            }
        }
    }
}