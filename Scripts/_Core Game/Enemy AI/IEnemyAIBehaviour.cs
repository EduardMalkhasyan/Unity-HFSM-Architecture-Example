using UnityEngine;

namespace Project.EnemyAI
{
    public interface IEnemyAIBehaviour
    {
        GameObject ParentGameObject { get; }
    }

    public interface IStateWithBehavior<T> where T : IEnemyAIBehaviour
    {
        void SetBehavior(T behaviour);
    }
}
