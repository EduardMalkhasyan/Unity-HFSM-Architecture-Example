using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Tools.Help
{
    public class MeshRendererDisabler : MonoBehaviour
    {
#pragma warning disable 0414
        [SerializeField] private bool isDraggableMeshRenderer = false;
        [SerializeField, ShowIf(nameof(isDraggableMeshRenderer))] private MeshRenderer meshRenderer;
#pragma warning restore 0414

        [SerializeField] private bool disableOnAwake = true;

        private void Awake()
        {
            if (meshRenderer == null)
            {
                meshRenderer = GetComponent<MeshRenderer>();
            }

            if (disableOnAwake)
            {
                Disable();
            }
        }

        public void Disable()
        {
            meshRenderer.enabled = false;
        }

        public void Enable()
        {
            meshRenderer.enabled = true;
        }
    }
}
