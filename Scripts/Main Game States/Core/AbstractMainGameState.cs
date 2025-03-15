using UnityEngine;

namespace Project.State
{
    public abstract class AbstractMainGameState : IGameState
    {
        public abstract void Enter();
        public abstract void Exit();
    }
}
