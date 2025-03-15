using UnityEngine;

namespace Project.UI
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        public void ScreenSpaceCamera()
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
        }

        public void ScreenSpaceOverlay()
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }
}

