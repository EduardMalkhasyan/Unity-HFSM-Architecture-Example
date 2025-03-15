using System;

namespace Project.State
{
    public class StateMachine
    {
        public Type CurrentStateClass => (currentState != null) ? currentState.GetType() : null;
        private IGameState currentState;

        public void SetState(IGameState state)
        {
            currentState?.Exit();
            currentState = state;
            currentState.Enter();
        }
    }
}
