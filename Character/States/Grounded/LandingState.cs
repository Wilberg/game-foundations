using System.Collections;
using UnityEngine;

namespace Character.States.Grounded
{
    public class LandingState : GroundedState
    {
        public LandingState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Character.StartCoroutine(Land());
        }

        private IEnumerator Land()
        {
            yield return new WaitForSeconds(0.1f);
            if (Character.motor.Velocity.magnitude > 0.1f)
            {
                Character.StateMachine.SetState<WalkingState>();
            }
            else
            {
                Character.StateMachine.SetState<IdleState>();
            }
        }
    }
}