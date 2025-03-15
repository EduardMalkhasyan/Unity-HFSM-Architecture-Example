using Project.InputSystem;
using Project.State;
using Project.UI;
using Project.UI.Widget;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Zenject;
using Project.Settings;

namespace Project.GameState
{
    public class LevelsState : AbstractMainGameState
    {
        [Inject] private UIScreensController screensController;
        [Inject] private MainGameStates mainGameStates;
        [Inject] private LevelsWidget levelsWidget;
        [Inject] private UIMainBackground uIMainBackground;
        [Inject] private PrepareGameState prepareGameState;
        [Inject] private MainInputSystem mainInputSystem;

        public event Action<int> OnLoadLevelByIndex;
        private CancellationTokenSource cancellationTokenSource;

        public override void Enter()
        {
            uIMainBackground.Open();

            screensController.ShowUIScreen(UIScreenEnum.Levels, OnCompleteCB: () =>
            {
                RunDetection();
            });

            levelsWidget.OnGoBack += EnterMainMenu;
            TryInitLevelCards();
            FilterLevelCards();

            OnLoadLevelByIndex += LoadLevelByIndexAndEnterStart;
        }

        public override void Exit()
        {
            StopDetection();
            uIMainBackground.Close();
            levelsWidget.OnGoBack -= EnterMainMenu;
            OnLoadLevelByIndex -= LoadLevelByIndexAndEnterStart;
        }

        private async void RunDetection()
        {
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await UniTask.NextFrame(cancellationToken: cancellationTokenSource.Token);

                while (cancellationTokenSource.IsCancellationRequested == false)
                {
                    if (mainInputSystem.GoBackInputAction.WasPressedThisFrame())
                    {
                        OnGoBack();
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

        private void OnGoBack()
        {
            EnterMainMenu();
        }

        private void TryInitLevelCards()
        {
            if (levelsWidget.LevelCards.Count != 0)
            {
                return;
            }

            for (int i = 0; i < LevelSettings.Value.LevelsCount; i++)
            {
                var index = i + 1;
                var isActive = LevelSettings.Value.LevelIndex >= i + 1;
                levelsWidget.CreateLevelCardAndSetup(index, isActive,
                             OnLevelOpen: () =>
                              {
                                  OnLoadLevelByIndex.Invoke(index);
                              });
            }
        }

        private void FilterLevelCards()
        {
            for (int i = 0; i < levelsWidget.LevelCards.Count; i++)
            {
                var isActive = LevelSettings.Value.LevelIndex >= i + 1;
                levelsWidget.LevelCards[i].CheckCard(isActive);
            }
        }

        private void EnterMainMenu()
        {
            mainGameStates.EnterState<MainMenuState>();
        }

        public void LoadLevelByIndexAndEnterStart(int levelIndex)
        {
            prepareGameState.SetLevelLoadByIndex(levelIndex);
            mainGameStates.EnterState<PrepareGameState>();
        }
    }
}
