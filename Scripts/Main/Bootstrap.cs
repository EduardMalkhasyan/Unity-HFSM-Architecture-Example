using Project.State;
using UnityEngine;
using Zenject;
using Project.UI;
using Project.Player;
using Project.Player.State;
using Project.InputSystem;
using Project.GameState;
using System.Collections.Generic;
using Project.Settings;
using Project.Tools.LocalizationHelp;
using Project.Tools.Help;

namespace Project.Main
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private MainGameStates mainGameStates;
        [Inject] private PlayerGameStates playerGameStates;
        [Inject] private UIScreensController uIScreensController;
        [Inject] private MainCanvas mainCanvas;
        [Inject] private PlayerSetupManager playerSetupManager;
        [Inject] private GameCursor gameCursor;
        [Inject] private ChooseLanguage chooseLanguage;
        [Inject] private IEnumerable<IGameInputSystem> gameInputSystems;

        private void Awake()
        {
            mainCanvas.ScreenSpaceOverlay();
            gameCursor.ShowMouseCursor();
            uIScreensController.Setup();

            if (GameSettings.Value.Language.IsInitialLanguageSelected == false)
            {
                chooseLanguage.SetupAndClose();
                chooseLanguage.OpenLanguages();

                chooseLanguage.OnAnyLanguageSelection += (gameLanguage) =>
                {
                    SetupAndPlayGame();
                    GameSettings.Value.Language.IsInitialLanguageSelected = true;
                    LocalizationLanguage.Value.CurrentLanguage = gameLanguage;
                    chooseLanguage.Close();
                };
            }
            else
            {
                chooseLanguage.Close();
                SetupAndPlayGame();
            }
        }

        private void SetupAndPlayGame()
        {
            LevelSettings.Value.CheckLevelsStatus();
            GameSettings.Value.InitSettings();

            SetupAllInputs();

            mainGameStates.Initialize();
            playerGameStates.Initialize();

            playerSetupManager.Setup();

            playerGameStates.EnterState<PlayerDisabledState>();

#if !PROJECT_DEBUGGER
            mainGameStates.EnterState<MainMenuState>();
#else
            switch (GameSettings.Value.InitialState)
            {
                case GameInitialState.MainMenu:
                    mainGameStates.EnterState<MainMenuState>();
                    break;
                case GameInitialState.Game:
                    mainGameStates.EnterState<PrepareGameState>();
                    break;
            }
#endif
        }

        private void SetupAllInputs()
        {
            foreach (var inputSystem in gameInputSystems)
            {
                inputSystem.Setup();
            }
        }

        private void OnDestroy()
        {
            ObjectPool.TryClearAndDestroyAllPools();
            CancellationTokenPool.KillPoolInSceneTokens();
        }
    }
}



