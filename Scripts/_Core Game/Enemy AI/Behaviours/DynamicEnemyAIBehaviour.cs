using Project.EnemyAI.State;
using Project.State;
using UnityEngine;

namespace Project.EnemyAI
{
    public class DynamicEnemyAIBehaviour : MonoBehaviour, IEnemyAIBehaviour
    {
        [field: SerializeField] public GameObject ParentGameObject { get; private set; }

        protected EnemyAIStateMachine enemyAIStateMachine;
        [SerializeReference] private DynamicEnemyAIAbstractState initialState;
        public IGameState CurrentState => enemyAIStateMachine.CurrentState;
        [field: SerializeField] public bool Debug { get; private set; }

        private void Awake()
        {
            enemyAIStateMachine = new EnemyAIStateMachine();
            enemyAIStateMachine.Debug = Debug;

            EnterInitialState();
        }

        public void EnterState<T>() where T : DynamicEnemyAIAbstractState, new()
        {
            enemyAIStateMachine.EnterState<T, DynamicEnemyAIBehaviour>(this);
        }

        public void EnterInitialState()
        {
            enemyAIStateMachine.EnterState(initialState, this);
        }

        public void Deactivate()
        {
            ParentGameObject.SetActive(false);
        }

        public void Activate()
        {
            ParentGameObject.SetActive(true);
        }
    }
}
