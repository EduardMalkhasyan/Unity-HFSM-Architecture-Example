using UnityEngine;

namespace Project.InputSystem
{
    public class GameCursor : MonoBehaviour
    {
        public void ShowMouseCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void HideMouseCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
