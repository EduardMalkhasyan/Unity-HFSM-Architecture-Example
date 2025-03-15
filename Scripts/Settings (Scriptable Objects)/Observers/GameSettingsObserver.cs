using UnityEngine;

namespace Project.Settings
{
    public static class GameSettingsObserver
    {
        public static event System.Action<float> OnEffectVolumeChange;
        public static event System.Action<float> OnMusicVolumeChange;
        public static event System.Action<float> OnMouseSensitivityChange;

        public static void OnMouseSensitivityChangeInvoke(float value)
        {
            OnMouseSensitivityChange?.Invoke(value);
        }

        public static void OnEffectVolumeChangeInvoke(float value)
        {
            OnEffectVolumeChange?.Invoke(value);
        }

        public static void OnMusicVolumeChangeInvoke(float value)
        {
            OnMusicVolumeChange?.Invoke(value);
        }
    }
}
