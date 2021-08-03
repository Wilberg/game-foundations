using UnityEngine;

namespace Character.States.Grounded.Crouching
{
    public class CrouchState : GroundedState
    {
        private Vector3 _scale;
        
        public CrouchState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            var transform = Character.transform;
            
            _scale = transform.localScale;
            transform.localScale = new Vector3(_scale.x, _scale.y / 2.0f, _scale.x);
            
            Speed = 5.0f;
        }

        public override void OnExit()
        {
            base.OnExit();
            Character.transform.localScale = new Vector3(_scale.x, _scale.y, _scale.x);
        }
        
        public override void OnAction(string action, bool shouldPerform)
        {
            base.OnAction(action, shouldPerform);

            switch (action)
            {
                case CharacterActions.Crouch when !shouldPerform:
                    if (Character.motor.Velocity.magnitude > 0.1f)
                    {
                        Character.StateMachine.SetState<WalkingState>();
                    }
                    else
                    {
                        Character.StateMachine.SetState<IdleState>();
                    }
                    break;
            }
        }
    }
}