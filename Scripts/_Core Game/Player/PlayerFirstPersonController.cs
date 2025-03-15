using UnityEngine;
using Sirenix.OdinInspector;
using System;
using Zenject;
using Project.InputSystem;

namespace Project.Player
{
    public class PlayerFirstPersonController : MonoBehaviour
    {
        [Inject] private PlayerInputSystem playerInputSystem;
        [SerializeField] private CharacterController characterController;

        [Space(1), Header("Speed")]
        [SerializeField] private float walkSpeed = 4f;
        [SerializeField] private float sprintSpeed = 6f;
        [SerializeField] private float speedChangeRate = 4f;
        [SerializeField, ReadOnly] private float currentSpeed;
        [SerializeField, ReadOnly] private float verticalVelocity;
        private const float terminalVelocity = 100f;

        [Space(1), Header("Other")]
        [SerializeField] private float gravity;
        [SerializeField, ReadOnly] private bool isMovementActive;

        private const float speedOffset = 0.1f;
        private const float inputMagnitude = 1f;

        public event Action OnIdle;
        public event Action OnWalk;
        public event Action OnMoveStopWithSprintPressed;
        public event Action OnRun;

        public void ProcessMovement()
        {
            if (isMovementActive)
            {
                SimulateGravity();
                Move();
            }
        }

        private void Move()
        {
            var move = playerInputSystem.MoveInputAction.ReadValue<Vector2>();

            float targetSpeed = 0;

            targetSpeed = playerInputSystem.RunInputAction.IsPressed() ? sprintSpeed : walkSpeed;

            if (move == Vector2.zero || playerInputSystem.MoveInputAction.IsPressed() == false)
            {
                targetSpeed = 0;
            }

            float currentHorizontalSpeed = new Vector3(characterController.velocity.x, 0f, characterController.velocity.z).magnitude;

            if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                currentSpeed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * speedChangeRate);
                currentSpeed = Mathf.Round(currentSpeed * 1000f) / 1000f;
            }
            else
            {
                currentSpeed = targetSpeed;
            }

            Vector3 inputDirection = new Vector3(move.x, 0f, move.y).normalized;

            if (move != Vector2.zero)
            {
                inputDirection = transform.right * move.x + transform.forward * move.y;
            }

            if (playerInputSystem.MoveInputAction.IsPressed())
            {
                if (playerInputSystem.RunInputAction.WasPressedThisFrame())
                {
                    OnRun?.Invoke();
                }

                if (playerInputSystem.RunInputAction.WasReleasedThisFrame())
                {
                    OnWalk?.Invoke();
                }

                if (playerInputSystem.MoveInputAction.WasPressedThisFrame())
                {
                    if (playerInputSystem.RunInputAction.IsPressed())
                    {
                        OnRun?.Invoke();
                    }
                    else
                    {
                        OnWalk?.Invoke();
                    }
                }
            }
            else if (playerInputSystem.MoveInputAction.WasReleasedThisFrame())
            {
                OnIdle?.Invoke();
            }

            if (playerInputSystem.MoveInputAction.WasReleasedThisFrame()
                && playerInputSystem.RunInputAction.IsPressed())
            {
                OnMoveStopWithSprintPressed?.Invoke();
            }

            characterController.Move(inputDirection.normalized * (currentSpeed * Time.deltaTime) +
                                     new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime);
        }

        private void SimulateGravity()
        {
            if (verticalVelocity < terminalVelocity)
            {
                verticalVelocity += gravity * Time.deltaTime;
            }
        }

        public void EnableMovement()
        {
            isMovementActive = true;
        }

        public void DisableMovement()
        {
            isMovementActive = false;
        }
    }
}
