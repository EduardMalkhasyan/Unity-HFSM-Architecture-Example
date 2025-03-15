using Project.Audio;
using Project.Camera;
using Project.InputSystem;
using Project.Main;
using Project.Player.State;
using Project.State;
using Project.UI;
using Project.UI.Widget;
using UnityEngine;
using Zenject;

namespace Project.GameState
{
    public class MainMenuState : AbstractMainGameState
    {
        [Inject] private UIScreensController screensController;
        [Inject] private MainMenuWidget mainMenuWidget;
        [Inject] private MainGameStates mainGameStates;
        [Inject] private LevelHolder levelHolder;
        [Inject] private UIMainBackground uIMainBackground;
        [Inject] private GameCursor gameCursor;
        [Inject] private PlayerGameStates playerGameStates;
        [Inject] private VirtualCamera virtualCamera;
        [Inject] private UIAudioManager uIAudioManager;

        public override void Enter()
        {
            gameCursor.ShowMouseCursor();

            levelHolder.TryReleaseAndDestroyCurrentLevel();
            playerGameStates.EnterState<PlayerDisabledState>();

            uIMainBackground.Open();
            uIAudioManager.PlayMainMenuMusic();

            virtualCamera.CloseAllVirtualCameras();
            virtualCamera.ResetMainCameraTransform();

            screensController.ShowUIScreen(UIScreenEnum.MainMenu);

            mainMenuWidget.OnGoToSettings += EnterSettings;
            mainMenuWidget.OnPlayGame += EnterPrepareGameState;
            mainMenuWidget.OnGoToLevels += EnterLevels;
            mainMenuWidget.OnGameExit += OnGameExit;
        }

        public override void Exit()
        {
            mainMenuWidget.OnGoToSettings -= EnterSettings;
            mainMenuWidget.OnPlayGame -= EnterPrepareGameState;
            mainMenuWidget.OnGoToLevels -= EnterLevels;
            mainMenuWidget.OnGameExit -= OnGameExit;
        }

        private void OnGameExit()
        {
            Application.Quit();
        }

        private void EnterSettings()
        {
            mainGameStates.SetGoBackState<MainMenuState>();
            mainGameStates.EnterState<SettingsState>();
        }

        private void EnterLevels()
        {
            mainGameStates.EnterState<LevelsState>();
        }

        private void EnterPrepareGameState()
        {
            mainGameStates.EnterState<PrepareGameState>();
        }
    }
}
