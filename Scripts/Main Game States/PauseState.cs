using Project.State;
using Project.UI;
using Zenject;
using Cysharp.Threading.Tasks;
using System.Threading;
using Project.Player.State;
using Project.InputSystem;
using Project.UI.Widget;

namespace Project.GameState
{
    public class PauseState : AbstractMainGameState
    {
        [Inject] private UIScreensController screensController;
        [Inject] private MainGameStates mainGameStates;
        [Inject] private PauseWidget pauseWidget;
        [Inject] private PlayerGameStates playerGameStates;
        [Inject] private GameCursor gameCursor;
        [Inject] private MainInputSystem mainInputSystem;
        [Inject] private UIMainBackground uIMainBackground;

        private CancellationTokenSource cancellationTokenSource;

        public override void Enter()
        {
            gameCursor.ShowMouseCursor();
            uIMainBackground.Open();

            pauseWidget.OnMainMenu += EnterMainMenu;
            pauseWidget.OnContinue += EnterPlayGameState;
            pauseWidget.OnSettings += EnterSettings;

            if (playerGameStates.CurrentStateType == typeof(PlayerFPSState))
            {
                playerGameStates.EnterState<PlayerPauseState>();
            }

            screensController.ShowInstantUIScreen(UIScreenEnum.Pause);

            RunDetection();
        }

        public override void Exit()
        {
            pauseWidget.OnMainMenu -= EnterMainMenu;
            pauseWidget.OnContinue -= EnterPlayGameState;
            pauseWidget.OnSettings -= EnterSettings;
            uIMainBackground.Close();

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
                        EnterPlayGameState();
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

        private void EnterMainMenu()
        {
            mainGameStates.EnterState<MainMenuState>();
        }

        private void EnterPlayGameState()
        {
            gameCursor.HideMouseCursor();
            mainGameStates.EnterState<PlayGameState>();
        }

        private void EnterSettings()
        {
            mainGameStates.SetGoBackState<PauseState>();
            mainGameStates.EnterState<SettingsState>();
        }
    }
}
