using Project.Main;
using Project.Player.State;
using Project.Settings;
using Project.State;
using Zenject;

namespace Project.GameState
{
    public class NextLevelState : AbstractMainGameState
    {
        [Inject] private MainGameStates mainGameStates;
        [Inject] private LevelHolder levelHolder;
        [Inject] private PlayerGameStates playerGameStates;

        public override void Enter()
        {
            playerGameStates.EnterState<PlayerWaitForNextLevelState>();
            LevelSettings.Value.TryLevelUp(levelHolder.currentLevelTuple.index);
            mainGameStates.EnterState<PrepareGameState>();
        }

        public override void Exit()
        {

        }
    }
}

