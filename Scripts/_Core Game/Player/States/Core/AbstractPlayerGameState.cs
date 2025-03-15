using Project.State;

namespace Project.Player.State
{
    public abstract class AbstractPlayerGameState : IGameState
    {
        public abstract void Enter();
        public abstract void Exit();
    }
}
