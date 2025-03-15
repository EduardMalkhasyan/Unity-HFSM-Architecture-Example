using Project.Tools.Help;
using System;
using UnityEngine;
using Zenject;

namespace Project.State
{
    public class MainGameStates : MonoBehaviour
    {
        [Inject] private DiContainer container;
        private StateMachine stateMachine;
        public Type CurrentStateType => stateMachine.CurrentStateClass;
        public AbstractMainGameState GoBackState { get; private set; }

        [SerializeField] private bool debug;

        public void Initialize()
        {
            stateMachine = new StateMachine();
        }

        public void EnterState<T>() where T : AbstractMainGameState
        {
            if (stateMachine.CurrentStateClass == typeof(T)) return;

            if (debug)
            {
                DebugColor.LogBlue($"Entering state: {typeof(T)}", bold: true);
            }

            var state = container.Resolve<T>();
            stateMachine.SetState(state);
        }

        public void EnterState(AbstractMainGameState stateType)
        {
            var type = stateType.GetType();
            if (stateMachine.CurrentStateClass == type) return;

            if (debug)
            {
                DebugColor.LogBlue($"Entering state: {stateType}", bold: true);
            }

            var state = container.Resolve(type) as AbstractMainGameState;
            stateMachine.SetState(state);
        }

        public void SetGoBackState<T>() where T : AbstractMainGameState
        {
            this.GoBackState = container.Resolve<T>();
        }

        public void EnterGoBackState()
        {
            EnterState(GoBackState);
        }

        #region Editor
        [ContextMenu(nameof(ShowCurrentState))]
        private void ShowCurrentState()
        {
            DebugColor.LogBlue($"Entering state: {CurrentStateType}", bold: true);
        }
        #endregion
    }
}
