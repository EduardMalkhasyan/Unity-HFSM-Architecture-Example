using DG.Tweening;
using UnityEngine.Rendering;

namespace Project.ExtensionMethod
{
    public static class VolumeExtensions
    {
        public static Tweener DOWeight(this Volume volume, float endValue, float duration)
        {
            return DOTween.To(() => volume.weight, x => volume.weight = x, endValue, duration);
        }
    }
}
