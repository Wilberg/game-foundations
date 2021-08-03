namespace Character.States.Grounded.Crouching
{
    public class CrouchWalkingState : CrouchState
    {
        public CrouchWalkingState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnPhysicsUpdate()
        {
            base.OnPhysicsUpdate();

            if (Character.motor.Velocity.magnitude < 0.1f)
            {
                Character.StateMachine.SetState<CrouchIdleState>();
            }
        }
    }
}