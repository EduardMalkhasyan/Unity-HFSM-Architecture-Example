using Project.Camera;
using Zenject;
using Project.Player.Observer;
using Project.InputSystem;

namespace Project.Player.State
{
    public class PlayerResetState : AbstractPlayerGameState
    {
        [Inject] private PlayerPositionSetter positionSetter;
        [Inject] private GameCursor gameCursor;
        [Inject] private PlayerCameraRotation cameraRotation;
        [Inject] private PlayerFirstPersonController fpsController;
        [Inject] private PlayerActivator playerActivator;
        [Inject] private VirtualCamera virtualCamera;

        public override void Enter()
        {
            gameCursor.HideMouseCursor();

            playerActivator.Deactivate();
            cameraRotation.DisableCameraRotation();
            fpsController.DisableMovement();

            positionSetter.TransferPlayerToInitialPosition();
            cameraRotation.ResetRotation_Y();
            cameraRotation.ResetRotation_X();

            fpsController.EnableMovement();
            cameraRotation.EnableCameraRotation();
            playerActivator.Activate();

            virtualCamera.SwitchCamera(VirtualCameraType.Idle);
            PlayerObserver.InvokeOnResetComplete();
        }

        public override void Exit()
        {

        }
    }
}
