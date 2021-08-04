using System;
using System.Collections.Generic;

namespace State
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }

        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        
        public void SetState<T>() where T : IState
        {
            if (!_states.ContainsKey(typeof(T))) return;
            
            CurrentState?.OnExit();
            CurrentState = _states[typeof(T)];
            CurrentState.OnEnter();
        }

        public void RegisterState(IState state)
        {
            _states[state.GetType()] = state;
        }

        public void ExtendState<T, TE>(TE stateExtension) where TE : T where T : IState 
        {
            if (CurrentState == _states[typeof(T)])
            {
                CurrentState?.OnExit();
            }

            _states[typeof(T)] = stateExtension;
            CurrentState = _states[typeof(T)];
            CurrentState.OnEnter();
        }
    }
}