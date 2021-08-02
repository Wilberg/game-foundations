using Character.States.Grounded;

namespace Character.States.Airborne
{
    public class FallingState : AirborneState
    {
        public FallingState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnEnter()
        {
                base.OnEnter();
                
                Character.motor.disableStickToGround = false;
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();
            
            if (Character.motor.IsGrounded)
            {
                Character.StateMachine.SetState<LandingState>();
            }
        }
    }
}