using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.ExtensionMethod
{
    public static class UIExtensions
    {
        public static Tween DoToTop(this ScrollRect scrollRect, float duration = 0,
                                   Ease ease = Ease.Linear, Action onComplete = null)
        {
            RectTransform contentTransform = scrollRect.content;
            float currentPosition = contentTransform.anchoredPosition.y;
            float targetPosition = 0f;

            return DOTween.To(() => currentPosition, x =>
                   {
                       currentPosition = x;
                       contentTransform.anchoredPosition = new Vector2(contentTransform.anchoredPosition.x, currentPosition);
                   }, targetPosition, duration)
                   .SetEase(ease)
                   .OnComplete(() => { onComplete?.Invoke(); });
        }

        public static Tween DoToBottom(this ScrollRect scrollRect, float duration = 0,
                                      Ease ease = Ease.Linear, Action onComplete = null)
        {
            RectTransform contentTransform = scrollRect.content;
            float currentPosition = contentTransform.anchoredPosition.y;
            float targetPosition = contentTransform.rect.height - scrollRect.viewport.rect.height;

            return DOTween.To(() => currentPosition, x =>
                   {
                       currentPosition = x;
                       contentTransform.anchoredPosition = new Vector2(contentTransform.anchoredPosition.x, currentPosition);
                   }, targetPosition, duration)
                   .SetEase(ease)
                   .OnComplete(() => { onComplete?.Invoke(); });
        }

        public static void RestartInteractable(this Selectable toggle)
        {
            toggle.interactable = false;
            toggle.interactable = true;
        }
    }
}
