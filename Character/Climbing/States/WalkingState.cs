using UnityEngine;

namespace Character.Climbing.States
{
    public class WalkingState : Character.States.Grounded.WalkingState
    {
        public WalkingState(CharacterBehaviour character) : base(character)
        {
        }

        public override void OnLogicUpdate()
        {
            base.OnLogicUpdate();

            var transform = Character.transform;
            var ray = new Ray(transform.position, transform.forward);

            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            
            if (!Physics.Raycast(ray, out var hit, 1.0f)) return;
            
            Debug.Log("Hit something!");
        }
    }
}