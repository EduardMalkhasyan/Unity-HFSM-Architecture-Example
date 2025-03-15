using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Project.Settings
{
    [Serializable]
    public class GameSettingsAudio
    {
        [SerializeField, HideInInspector] private float effectAudioVolume;
        [JsonProperty, ShowInInspector, PropertyRange(0f, 1f)]
        public float EffectAudioVolume
        {
            get => effectAudioVolume;
            set
            {
                effectAudioVolume = value;
                GameSettingsObserver.OnEffectVolumeChangeInvoke(value);
            }
        }

        [SerializeField, HideInInspector] private float musicAudioVolume;
        [JsonProperty, ShowInInspector, PropertyRange(0f, 1f)]
        public float MusicAudioVolume
        {
            get => musicAudioVolume;
            set
            {
                musicAudioVolume = value;
                GameSettingsObserver.OnMusicVolumeChangeInvoke(value);
            }
        }
    }
}
