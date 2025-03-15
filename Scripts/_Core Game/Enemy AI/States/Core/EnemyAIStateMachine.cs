using Project.State;
using Project.Tools.Help;
using System;

namespace Project.EnemyAI.State
{
    public class EnemyAIStateMachine
    {
        public IGameState CurrentState { get; private set; }
        public bool Debug { get; set; }

        public void EnterState<T>(IGameState newState, T enemyAIBehaviour) where T : IEnemyAIBehaviour
        {
            CurrentState?.Exit();
            CurrentState = newState;
            (CurrentState as IStateWithBehavior<T>).SetBehavior(enemyAIBehaviour);
            CurrentState.Enter();

            if (Debug)
            {
                DebugColor.LogBlue($"AI: Enter state: {CurrentState.GetType().Name}", true);
            }
        }

        public void EnterState<StateType, BehaviourType>(BehaviourType enemyAIBehaviour)
                               where BehaviourType : IEnemyAIBehaviour
                               where StateType : IGameState, new()
        {
            CurrentState?.Exit();
            CurrentState = Activator.CreateInstance<StateType>();
            (CurrentState as IStateWithBehavior<BehaviourType>).SetBehavior(enemyAIBehaviour);
            CurrentState.Enter();

            if (Debug)
            {
                DebugColor.LogBlue($"AI: Enter state: {CurrentState.GetType().Name}", true);
            }
        }
    }
}
