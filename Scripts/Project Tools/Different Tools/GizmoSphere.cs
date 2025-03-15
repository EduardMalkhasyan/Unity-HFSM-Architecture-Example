using UnityEngine;
using Sirenix.OdinInspector;

namespace Project.Tools.Help
{
    public class GizmoSphere : MonoBehaviour
    {
        [SerializeField] private bool disableOnStart = false;

        [SerializeField, Range(0.01f, 5f)] private float sphereSize = 0.5f;
        [EnumToggleButtons, SerializeField] private GizmoColor gizmoColor = GizmoColor.Green;

        [SerializeField] private bool showDirection = false;

        private void Awake()
        {
            if (disableOnStart)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnDrawGizmos()
        {
            Color selectedColor = GetColorFromEnum(gizmoColor);
            Gizmos.color = selectedColor;
            Gizmos.DrawSphere(transform.position, sphereSize);

            if (showDirection)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawRay(transform.position, transform.forward * 1);
            }
        }

        private Color GetColorFromEnum(GizmoColor colorEnum)
        {
            switch (colorEnum)
            {
                case GizmoColor.Red:
                    return Color.red;
                case GizmoColor.Blue:
                    return Color.blue;
                case GizmoColor.Cyan:
                    return Color.cyan;
                case GizmoColor.Yellow:
                    return Color.yellow;

                case GizmoColor.Green:
                default:
                    return Color.green;
            }
        }
    }

    public enum GizmoColor
    {
        Red,
        Blue,
        Cyan,
        Green,
        Yellow,
    }
}
