using UnityEngine;
using DG.Tweening;
using System;
using Project.Settings;

namespace Project.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        private Vector3 originalPosition;

        public void Show(Action OnCompleteCB = null)
        {
            gameObject.SetActive(true);
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;

            var sequence = DOTween.Sequence();

            sequence.Append(canvasGroup.DOFade(1, UISettings.Value.ScreenFadeDuration))
                    .AppendCallback(() =>
                    {
                        OnCompleteCB?.Invoke();
                    });
        }

        public void ShowWithDelay(Action OnCompleteCB = null, float interval = 0f)
        {
            gameObject.SetActive(true);
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;

            var sequence = DOTween.Sequence();

            sequence.AppendInterval(interval)
                    .Append(canvasGroup.DOFade(1, UISettings.Value.ScreenFadeDuration))
                    .AppendCallback(() =>
                    {
                        OnCompleteCB?.Invoke();
                    });
        }

        public void Hide(Action OnCompleteCB = null)
        {
            canvasGroup.blocksRaycasts = false;

            var sequence = DOTween.Sequence();

            sequence.Append(canvasGroup.DOFade(0, UISettings.Value.ScreenFadeDuration))
                    .AppendCallback(() =>
                     {
                         transform.localPosition = originalPosition;
                         gameObject.SetActive(false);
                         OnCompleteCB?.Invoke();
                     });
        }

        public void HideWithDelay(Action OnCompleteCB = null, float interval = 0f)
        {
            canvasGroup.blocksRaycasts = false;

            var sequence = DOTween.Sequence();

            sequence.AppendInterval(interval)
                    .Append(canvasGroup.DOFade(0, UISettings.Value.ScreenFadeDuration))
                    .AppendCallback(() =>
                    {
                        transform.localPosition = originalPosition;
                        gameObject.SetActive(false);
                        OnCompleteCB?.Invoke();
                    });
        }

        public void HideInstant(Action OnCompleteCB = null)
        {
            originalPosition = transform.localPosition;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0;
            gameObject.SetActive(false);
            OnCompleteCB?.Invoke();
        }

        public void ShowInstant(Action OnCompleteCB = null)
        {
            transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;
            gameObject.SetActive(true);
            OnCompleteCB?.Invoke();
        }
    }
}
