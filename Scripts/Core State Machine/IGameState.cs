using UnityEngine;

namespace Project.State
{
    public interface IGameState
    {
        void Enter();
        void Exit();
    }
}

