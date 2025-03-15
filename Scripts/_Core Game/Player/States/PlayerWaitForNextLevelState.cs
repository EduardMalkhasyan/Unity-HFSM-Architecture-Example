using Project.InputSystem;
using Project.State;
using Zenject;

namespace Project.Player.State
{
    public class PlayerWaitForNextLevelState : AbstractPlayerGameState
    {
        [Inject] private PlayerFirstPersonController fpsController;
        [Inject] private PlayerInputSystem playerInputSystem;
        [Inject] private PlayerActivator playerActivator;

        public override void Enter()
        {
            fpsController.DisableMovement();
            playerInputSystem.Disable();
            playerActivator.Deactivate();
        }

        public override void Exit()
        {

        }
    }
}
