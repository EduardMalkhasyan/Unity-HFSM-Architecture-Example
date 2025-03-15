using Project.State;
using Zenject;
using Cysharp.Threading.Tasks;
using System.Threading;
using Project.InputSystem;
using Project.Main;
using Project.Player.Observer;
using Project.GameState;

namespace Project.Player.State
{
    public class PlayerFPSState : AbstractPlayerGameState
    {
        [Inject] private PlayerInputSystem playerInputSystem;
        [Inject] private PlayerFirstPersonController fpsController;
        [Inject] private PlayerCameraRotation cameraRotation;
        [Inject] private GameCursor gameCursor;
        [Inject] private MainInputSystem mainInputSystem;
        [Inject] private MainGameStates mainGameStates;

        private CancellationTokenSource cameraRotationCancellation;
        private CancellationTokenSource actionsRotationCancellation;
        private CancellationTokenSource playerInputAsyncCancellation;

        private float playerInputAsyncDuration = 0.5f;

        public override void Enter()
        {
            gameCursor.HideMouseCursor();

            CameraRotation();
            ProcessActions();

            mainInputSystem.Enable();
            EnablePlayerInputAsync();
            PlayerObserver.OnLevelFinish += OnLevelFinish;
        }

        public override void Exit()
        {
            Stop();
            StopCameraRotation();
            StopProcessActions();
            PlayerObserver.OnLevelFinish -= OnLevelFinish;
        }

        public async void EnablePlayerInputAsync()
        {
            playerInputAsyncCancellation?.Cancel();
            playerInputAsyncCancellation = new CancellationTokenSource();

            try
            {
                await UniTask.WaitForSeconds(playerInputAsyncDuration, cancellationToken: playerInputAsyncCancellation.Token);
                playerInputSystem.Enable();
            }
            catch
            {

            }
        }

        private void Stop()
        {
            playerInputAsyncCancellation?.Cancel();
        }

        private void OnLevelFinish()
        {
            mainGameStates.EnterState<NextLevelState>();
        }

        private async void CameraRotation()
        {
            cameraRotationCancellation = new CancellationTokenSource();

            try
            {
                while (cameraRotationCancellation.Token.IsCancellationRequested == false)
                {
                    cameraRotation.Rotate();
                    await UniTask.Yield(PlayerLoopTiming.PreLateUpdate, cancellationToken: cameraRotationCancellation.Token);
                }
            }
            catch
            {

            }
        }

        private void StopCameraRotation()
        {
            cameraRotationCancellation?.Cancel();
        }

        private async void ProcessActions()
        {
            actionsRotationCancellation = new CancellationTokenSource();

            try
            {
                while (actionsRotationCancellation.Token.IsCancellationRequested == false)
                {
                    fpsController.ProcessMovement();
                    await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken: actionsRotationCancellation.Token);
                }
            }
            catch
            {

            }
        }

        private void StopProcessActions()
        {
            actionsRotationCancellation?.Cancel();
        }
    }
}
