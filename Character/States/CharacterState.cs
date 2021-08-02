using System;
using System.Collections.Generic;
using State;

namespace Character.States
{
    public abstract class CharacterState : IState
    {
        protected readonly CharacterBehaviour Character;

        protected CharacterState(CharacterBehaviour character)
        {
            Character = character;
        }
        
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnPhysicsUpdate();
        public abstract void OnLogicUpdate();
        public abstract void OnAction(string action);
    }
}
