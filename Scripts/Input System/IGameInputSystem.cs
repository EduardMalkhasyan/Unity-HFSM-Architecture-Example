using UnityEngine;

namespace Project.InputSystem
{
    interface IGameInputSystem
    {
        void Setup();
        void Enable();
        void Disable();
    }
}
