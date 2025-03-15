using Project.Main;
using Project.Player.Observer;
using Project.Player.State;
using Project.State;
using Project.UI;
using Cysharp.Threading.Tasks;
using Zenject;
using Project.Settings;
using Project.Audio;

namespace Project.GameState
{
    public class PrepareGameState : AbstractMainGameState
    {
        [Inject] private UIMainBackground uIMainBackground;
        [Inject] private LevelHolder levelHolder;
        [Inject] private WaitLoadingSpinnerDots waitLoadingSpinnerDots;
        [Inject] private FadeInOut fadeInOut;
        [Inject] private MainGameStates mainGameStates;
        [Inject] private PlayerGameStates playerGameStates;
        [Inject] private UIAudioManager uIAudioManager;

        private bool isLeveLoadByIndex = false;
        private int levelLoadIndex;

        public override void Enter()
        {
            uIAudioManager.StopMainMenuMusic();
            uIMainBackground.Close();
            LoadAssetsAndEnterLevel();
            PlayerObserver.OnResetComplete += EnterPlayGameState;
        }

        public override void Exit()
        {
            PlayerObserver.OnResetComplete -= EnterPlayGameState;
        }

        private void LoadAssetsAndEnterLevel()
        {
            fadeInOut.FadeIn();
            var index = LevelSettings.Value.LevelIndex;
            waitLoadingSpinnerDots.EnableLoadingScreen();

            if (isLeveLoadByIndex)
            {
                levelHolder.LoadLevelByIndex(levelLoadIndex, SuccessLoad);
                isLeveLoadByIndex = false;
            }
            else
            {
                levelHolder.LoadStoredLevel(SuccessLoad);
            }
        }

        private async void SuccessLoad()
        {
            var delay = 1.5f;
            var activatePlayerDelay = 0.35f;
            fadeInOut.FadeOutWithDelay(delay);
            waitLoadingSpinnerDots.DisableLoadingScreenWithDelay(delay);
            await UniTask.WaitForSeconds(activatePlayerDelay);
            playerGameStates.EnterState<PlayerResetState>();
        }

        private void EnterPlayGameState()
        {
            mainGameStates.EnterState<PlayGameState>();
        }

        public void SetLevelLoadByIndex(int index)
        {
            isLeveLoadByIndex = true;
            levelLoadIndex = index;
        }

        public void SetLevelLoadByStored()
        {
            isLeveLoadByIndex = false;
        }
    }
}
