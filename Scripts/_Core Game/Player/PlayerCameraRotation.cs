using Project.InputSystem;
using Project.Settings;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Project.Player
{
    public class PlayerCameraRotation : MonoBehaviour
    {
        [Inject] private PlayerInputSystem playerInputSystem;
        [SerializeField] private Transform cinemachineCameraTarget;

        private float rotationSpeed;
        [SerializeField] private float topClamp = 76f;
        [SerializeField] private float bottomClamp = -76f;

        public void SetupRotationSpeedAndSubscribeForUpdate()
        {
            var sensitivity = GameSettings.Value.Character.MouseSensitivity;
            GameSettingsObserver.OnMouseSensitivityChange += OnMouseSensitivityChange;
            rotationSpeed = sensitivity;
        }

        private void OnMouseSensitivityChange(float sensitivity)
        {
            rotationSpeed = sensitivity;
        }

        [SerializeField, ReadOnly] private float rotation_Y;
        public float Rotation_Y
        {
            get => rotation_Y;
            set
            {
                rotation_Y = ClampAngle(value);
            }
        }

        [SerializeField, ReadOnly] private float rotation_X;
        public float Rotation_X
        {
            get => rotation_X;
            set
            {
                rotation_X = ClampAngle(value, bottomClamp, topClamp);
            }
        }

        [SerializeField, ReadOnly] private bool isCameraRotationActive;

        public void Rotate()
        {
            if (isCameraRotationActive)
            {
                Vector2 look = playerInputSystem.LookInputAction.ReadValue<Vector2>();

                Rotation_X += look.y * rotationSpeed;
                Rotation_Y += look.x * rotationSpeed;

                TryPreventNaNorInfinity();

                cinemachineCameraTarget.localRotation = Quaternion.Euler(Rotation_X, 0f, 0f);
                transform.localRotation = Quaternion.Euler(0, Rotation_Y, 0);
            }
        }

        private float ClampAngle(float lfAngle, float lfMin = -360f, float lfMax = 360f)
        {
            float fullAngle = 360f;

            if (lfAngle < -fullAngle)
            {
                lfAngle += fullAngle;
            }

            if (lfAngle > fullAngle)
            {
                lfAngle -= fullAngle;
            }

            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }

        private void TryPreventNaNorInfinity()
        {
            if (float.IsNaN(Rotation_X) || float.IsInfinity(Rotation_X))
            {
                ResetRotation_X();
                Debug.LogWarning($"Detection of NaN or Infinity CinemachineTargetPitch is force set to 0");
            }

            if (float.IsNaN(Rotation_Y) || float.IsInfinity(Rotation_Y))
            {
                ResetRotation_Y();
                Debug.LogWarning($"Detection of NaN or Infinity RotationVelocity is force set to 0");
            }
        }

        public void EnableCameraRotation()
        {
            isCameraRotationActive = true;
        }

        public void DisableCameraRotation()
        {
            isCameraRotationActive = false;
        }

        public void SetRotation_X(float rotation_X)
        {
            Rotation_X = rotation_X;
        }

        public void ResetRotation_X()
        {
            Rotation_X = 0;
        }

        public void SetRotation_Y(float rotation_Y)
        {
            Rotation_Y = rotation_Y;
        }

        public void ResetRotation_Y()
        {
            Rotation_Y = 0;
        }
    }
}
