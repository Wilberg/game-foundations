using Character.States.Airborne;
using Character.States.Grounded.Crouching;

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

        public override void OnAction(string action, bool shouldPerform)
        {
            base.OnAction(action, shouldPerform);

            switch (action)
            {
                case CharacterActions.Crouch when shouldPerform:
                    Character.StateMachine.SetState<CrouchIdleState>();
                    break;;
                case CharacterActions.Jump when shouldPerform:
                    Character.StateMachine.SetState<JumpingState>();
                    break;
            }
        }
    }
}