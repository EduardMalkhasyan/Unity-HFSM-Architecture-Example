using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class WaitLoadingSpinnerDots : MonoBehaviour
    {
        [SerializeField] private Image background;
        private Vector3 originalPosition;

        [SerializeField] private bool disableOnAwake = false;
        public bool IsUsable { get; private set; }

        private void Awake()
        {
            transform.localPosition = originalPosition;

            if (IsUsable == false)
            {
                if (disableOnAwake)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        [Button]
        public void EnableLoadingScreen()
        {
            transform.localPosition = Vector3.zero;
            IsUsable = true;
            gameObject.SetActive(true);
        }

        [Button]
        public void DisableLoadingScreen()
        {
            transform.localPosition = originalPosition;
            gameObject.SetActive(false);
        }

        [Button]
        public void DisableLoadingScreenWithDelay(float delay)
        {
            StartCoroutine(DisableLoadingScreenCoroutine(delay));
        }

        private IEnumerator DisableLoadingScreenCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            DisableLoadingScreen();
        }
    }
}
