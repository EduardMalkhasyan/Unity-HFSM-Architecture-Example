using Project.State;
using UnityEngine;

namespace Project.EnemyAI.State
{
    public abstract class DynamicEnemyAIAbstractState : IGameState, IStateWithBehavior<DynamicEnemyAIBehaviour>
    {
        protected DynamicEnemyAIBehaviour behaviour;

        public abstract void Enter();
        public abstract void Exit();

        public void SetBehavior(DynamicEnemyAIBehaviour behaviour)
        {
            this.behaviour = behaviour;
        }
    }
}
