using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Project.ExtensionMethod
{
    public static class ForceRebuildLayoutExtensions
    {
        public static void RebuildLayout(this RectTransform rect, int repeatCount = 0, float interval = 0.1f)
        {
            RebuildAsync(rect, repeatCount, interval);
        }

        public static void RebuildLayoutAllChilds(this RectTransform rect, int repeatCount = 0, float interval = 0.1f)
        {
            var childRects = rect.gameObject.GetComponentsInChildren<RectTransform>();

            for (int i = 0; i < childRects.Length; i++)
            {
                RebuildAsync(childRects[i], repeatCount, interval);
            }
        }

        public static async void RebuildAsync(RectTransform rect, int repeatCount = 0, float interval = 0.1f)
        {
            int limit = 0;
            var secInterval = (int)(interval * 1000);

            while (limit <= repeatCount)
            {
                limit++;
                await UniTask.Delay(secInterval);

                if (rect != null)
                {
                    LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
                }
                else
                {
                    Debug.LogWarning($"Rect transform is null or disabled");
                }
            }
        }

        public static async void RefreshLayoutGroupsImmediateAndRecursive(this LayoutGroup root, int repeatCount = 1, float interval = 0.1f)
        {
            var secInterval = (int)(interval * 1000);

            for (int i = 0; i < repeatCount; i++)
            {
                await UniTask.Delay(secInterval);

                LayoutRebuilder.ForceRebuildLayoutImmediate(root.GetComponent<RectTransform>());
                foreach (var layoutGroup in root.GetComponentsInChildren<LayoutGroup>())
                {
                    LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
                }
            }
        }
    }
}
