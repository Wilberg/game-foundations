using UnityEngine;

namespace Character.Brain
{
    public class PlayerBrain : MonoBehaviour
    {
        public CharacterBehaviour character;

        [Header("Mouse")]
        public float sensitivity;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            HandleMovement();
            HandleJump();
            HandleLook();
        }

        private void HandleMovement()
        {
            character.motor.direction = Input.GetAxis("Horizontal") * transform.right +
                                        Input.GetAxis("Vertical") * transform.forward;;
        }

        private void HandleJump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                character.Invoke(CharacterActions.Jump, true);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                character.Invoke(CharacterActions.Crouch, true);
            }
            
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                character.Invoke(CharacterActions.Crouch, false);
            }
        }

        private void HandleLook()
        {
            var delta = new Vector2
            {
                x = Input.GetAxisRaw("Mouse Y"),
                y = Input.GetAxisRaw("Mouse X")
            }.normalized;
            character.Turn(delta * (sensitivity * 100.0f * Time.deltaTime));
        }
    }
}