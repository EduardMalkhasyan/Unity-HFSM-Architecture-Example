using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Rendering.Universal;

namespace Project.ExtensionMethod
{
    public static class ScriptableRendererExtensions
    {
        /// <summary>
        /// Toggles a specific renderer feature by its name and type.
        /// </summary>
        /// <typeparam name="T">The type of the renderer feature to toggle.</typeparam>
        /// <param name="renderer">The ScriptableRenderer instance.</param>
        /// <param name="enable">Whether to enable or disable the feature.</param>
        /// <param name="featureName">The name of the feature to toggle.</param>
        public static void ToggleRendererFeature<T>(this ScriptableRenderer renderer, bool enable, string featureName) where T : ScriptableRendererFeature
        {
            var property = typeof(ScriptableRenderer).GetProperty("rendererFeatures", BindingFlags.NonPublic | BindingFlags.Instance);
            if (property == null)
            {
                //Debug.LogError("Could not find 'rendererFeatures' property in ScriptableRenderer.");
                return;
            }

            List<ScriptableRendererFeature> features = property.GetValue(renderer) as List<ScriptableRendererFeature>;
            if (features == null)
            {
                //Debug.LogError("Could not retrieve renderer features list.");
                return;
            }

            foreach (var feature in features)
            {
                if (feature is T && feature.name == featureName)
                {
                    feature.SetActive(enable);
                    //Debug.Log($"Toggled feature '{featureName}' of type {typeof(T).Name} to {enable}.");
                    return;
                }
            }

            //Debug.LogWarning($"Could not find feature '{featureName}' of type {typeof(T).Name}.");
        }
    }
}
