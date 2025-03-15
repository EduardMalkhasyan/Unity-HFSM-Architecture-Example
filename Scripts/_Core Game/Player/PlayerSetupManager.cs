using UnityEngine;
using Zenject;
using Project.InputSystem;

namespace Project.Player
{
    public class PlayerSetupManager : MonoBehaviour
    {
        [Inject] private PlayerInputSystem playerInputSystem;
        [Inject] private PlayerPositionSetter positionSetter;
        [Inject] private PlayerCameraRotation cameraRotation;

        public void Setup()
        {
            playerInputSystem.Setup();
            positionSetter.StoreInitialPosition();
            cameraRotation.SetupRotationSpeedAndSubscribeForUpdate();
        }
    }
}
