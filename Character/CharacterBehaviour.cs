using Character.Motor;
using Character.States;
using Character.States.Airborne;
using Character.States.Grounded;
using Character.States.Grounded.Crouching;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(MotorBehaviour))]
    public class CharacterBehaviour : MonoBehaviour
    {
        public Transform head;
        public MotorBehaviour motor;
        public string currentStateName;
        
        public readonly State.StateMachine StateMachine = new State.StateMachine();

        private float _rotationX;
        private float _rotationY;
        
        private void Awake()
        {
            StateMachine.RegisterState(new IdleState(this));
            StateMachine.RegisterState(new WalkingState(this));
            StateMachine.RegisterState(new CrouchIdleState(this));
            StateMachine.RegisterState(new CrouchWalkingState(this));
            StateMachine.RegisterState(new LandingState(this));
            StateMachine.RegisterState(new JumpingState(this));
            StateMachine.RegisterState(new FallingState(this));
            StateMachine.SetState<IdleState>();
        }

        private void FixedUpdate()
        {
            (StateMachine.CurrentState as CharacterState)?.OnPhysicsUpdate();
        }

        private void Update()
        {
            currentStateName = StateMachine.CurrentState?.GetType().Name;
            (StateMachine.CurrentState as CharacterState)?.OnLogicUpdate();
        }

        public void Invoke(string action, bool shouldPerform)
        {
            (StateMachine.CurrentState as CharacterState)?.OnAction(action, shouldPerform);
        }

        public void Turn(Vector2 delta)
        {
            _rotationY += delta.y;
            _rotationX = Mathf.Clamp(_rotationX - delta.x, -90.0f, 90.0f);
            
            head.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation = Quaternion.Euler(0, _rotationY, 0);
        }
    }
}
