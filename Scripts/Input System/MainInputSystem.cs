using MainInputMap;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.InputSystem
{
    public class MainInputSystem : MonoBehaviour, IGameInputSystem
    {
        public MainInputSystemMap mainInputSystemMap;
        public InputAction PauseInputAction { get; private set; }
        public InputAction GoBackInputAction { get; private set; }

        public void Setup()
        {
            mainInputSystemMap = new MainInputSystemMap();
            PauseInputAction = mainInputSystemMap.Menu.Pause;
            GoBackInputAction = mainInputSystemMap.Menu.GoBack;
            mainInputSystemMap.Enable();
        }

        public void Enable()
        {
            mainInputSystemMap.Enable();
        }

        public void Disable()
        {
            mainInputSystemMap.Disable();
        }
    }
}
