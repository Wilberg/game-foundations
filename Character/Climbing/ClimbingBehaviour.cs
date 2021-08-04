using Character.Climbing.States;
using UnityEngine;

namespace Character.Climbing
{
    [RequireComponent(typeof(CharacterBehaviour))]
    public class ClimbingBehaviour : MonoBehaviour
    {
        private CharacterBehaviour _character;
        private void Start()
        {
            _character = GetComponent<CharacterBehaviour>();

            var walkingState = new WalkingState(_character);
            _character.StateMachine.ExtendState<Character.States.Grounded.WalkingState, WalkingState>(walkingState);   
        }
    }
}