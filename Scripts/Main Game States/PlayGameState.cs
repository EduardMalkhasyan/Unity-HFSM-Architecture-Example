using Project.InputSystem;
using Project.Main;
using Project.Player.State;
using Project.State;
using Project.Tools;
using Project.UI;
using Cysharp.Threading.Tasks;
using System.Threading;
using Zenject;

namespace Project.GameState
{
    public class PlayGameState : AbstractMainGameState
    {
        [Inject] private UIScreensController screensController;
        [Inject] private MainGameStates mainGameStates;
        [Inject] private PlayerGameStates playerGameStates;
        [Inject] private MainInputSystem mainInputSystem;

        private CancellationTokenSource cancellationTokenSource;

        public override void Enter()
        {
            screensController.ShowInstantUIScreen(UIScreenEnum.Gameplay);
            playerGameStates.EnterState<PlayerFPSState>();
            RunDetection();
        }

        public override void Exit()
        {
            StopDetection();
        }

        private async void RunDetection()
        {
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await UniTask.NextFrame(cancellationToken: cancellationTokenSource.Token);

                while (cancellationTokenSource.IsCancellationRequested == false)
                {
                    if (mainInputSystem.PauseInputAction.WasPressedThisFrame())
                    {
                        mainGameStates.EnterState<PauseState>();
                    }

                    await UniTask.Yield(cancellationToken: cancellationTokenSource.Token);
                }
            }
            catch
            {

            }
        }

        private void StopDetection()
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
