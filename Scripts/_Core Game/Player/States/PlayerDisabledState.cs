using Project.InputSystem;
using Project.State;
using Zenject;

namespace Project.Player.State
{
    public class PlayerDisabledState : AbstractPlayerGameState
    {
        [Inject] private PlayerActivator playerActivator;
        [Inject] private PlayerInputSystem playerInputSystem;

        public override void Enter()
        {
            playerActivator.Deactivate();
            playerInputSystem.Disable();
        }

        public override void Exit()
        {

        }
    }
}
