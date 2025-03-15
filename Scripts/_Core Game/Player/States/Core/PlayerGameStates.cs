using Project.State;
using Project.Tools.Help;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Project.Player.State
{
    public class PlayerGameStates : MonoBehaviour
    {
        [Inject] private DiContainer container;
        private StateMachine stateMachine;
        public System.Type CurrentStateType => stateMachine.CurrentStateClass;

        [SerializeField] private bool debug;

        public void Initialize()
        {
            stateMachine = new StateMachine();
        }

        public void EnterState<T>() where T : AbstractPlayerGameState
        {
            if (stateMachine.CurrentStateClass == typeof(T)) return;

            if (debug)
            {
                DebugColor.LogBlue($"Entering state: {typeof(T)}", bold: false);
            }

            var state = container.Resolve<T>();
            stateMachine.SetState(state);
        }

        [Button]
        private void ShowCurrentState()
        {
            DebugColor.LogBlue($"Entering state: {stateMachine.CurrentStateClass}", bold: false);
        }
    }
}
