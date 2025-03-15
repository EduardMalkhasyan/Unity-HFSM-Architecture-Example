using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System;

namespace Project.UI
{
    public class FadeInOut : MonoBehaviour
    {
        [SerializeField] private Image image;

        private Vector3 originalPosition;

        [SerializeField] private float fadeDuration = 1.0f;

        public bool IsUsable { get; private set; }

        private void Awake()
        {
            transform.localPosition = originalPosition;

            if (IsUsable == false)
            {
                gameObject.SetActive(false);
            }
        }

        private void EnableLoadingScreen()
        {
            transform.localPosition = Vector3.zero;
            IsUsable = true;
            gameObject.SetActive(true);
        }

        private void DisableLoadingScreen()
        {
            transform.localPosition = originalPosition;
            gameObject.SetActive(false);
        }

        [Button]
        public void FadeIn(Action OnComplete = null)
        {
            EnableLoadingScreen();
            image.DOFade(1f, fadeDuration).OnComplete(() =>
            {
                OnComplete?.Invoke();
            });
        }

        [Button]
        public void FadeOut(Action OnComplete = null)
        {
            image.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                DisableLoadingScreen();
                OnComplete?.Invoke();
            });
        }

        [Button]
        public void FadeOutWithDelay(float delay, Action OnComplete = null)
        {
            StartCoroutine(FadeOutCoroutine(delay));
        }

        private IEnumerator FadeOutCoroutine(float delay, Action OnComplete = null)
        {
            yield return new WaitForSeconds(delay);
            image.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                DisableLoadingScreen();
                OnComplete?.Invoke();
            });
        }
    }
}
