using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.UI
{
    public class InvisibleBlocker : MonoBehaviour
    {
        private Vector3 originalPosition;

        public bool IsUsable { get; private set; }

        private void Awake()
        {
            originalPosition = transform.localPosition;

            if (IsUsable == false)
            {
                gameObject.SetActive(false);
            }
        }

        [Button]
        public void EnableBlocker()
        {
            transform.localPosition = Vector3.zero;
            IsUsable = true;
            gameObject.SetActive(true);
        }

        [Button]
        public void DisableBlocker()
        {
            transform.localPosition = originalPosition;
            gameObject.SetActive(false);
        }
    }
}
