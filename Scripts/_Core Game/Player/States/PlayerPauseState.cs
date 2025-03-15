using Project.InputSystem;
using Project.State;
using System.Threading;
using Zenject;

namespace Project.Player.State
{
    public class PlayerPauseState : AbstractPlayerGameState
    {
        [Inject] private PlayerFirstPersonController fpsController;
        [Inject] private PlayerInputSystem playerInputSystem;

        private CancellationTokenSource checkIfQuitCancellation;

        public override void Enter()
        {
            playerInputSystem.Disable();
            fpsController.DisableMovement();
        }

        public override void Exit()
        {
            StopLoop();
            fpsController.EnableMovement();
            playerInputSystem.Enable();
        }

        private void StopLoop()
        {
            checkIfQuitCancellation?.Cancel();
        }
    }
}
