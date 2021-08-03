namespace Character.States.Grounded.Crouching
{
    public class CrouchIdleState : CrouchState
    {
        public CrouchIdleState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnPhysicsUpdate()
        {
            base.OnPhysicsUpdate();
            if (Character.motor.Velocity.magnitude > 0.1f)
            {
                Character.StateMachine.SetState<CrouchWalkingState>();
            }
        }
    }
}