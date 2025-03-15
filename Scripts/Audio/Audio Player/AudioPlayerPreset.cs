using Project.Tools.AttributeHelp;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Project.Audio
{
    [Serializable]
    public class AudioPlayerPreset
    {
        [field: SerializeField] public AudioClip Clip { get; private set; }
        [field: SerializeField, MinMax(-3, 3), FoldoutGroup("Pitch")]
        public Vector2 Pitch { get; private set; } = new Vector2(1f, 1.1f);

#pragma warning disable 0414
        [SerializeField] private bool hasAudioSource = false;
        [SerializeField, ShowIf(nameof(hasAudioSource))] private AudioSource audioSource;
#pragma warning restore 0414

        private float GetRange(Vector2 vector2)
        {
            var pitch = UnityEngine.Random.Range(vector2.x, vector2.y);
            return pitch;
        }

        [Button, ShowIf(nameof(hasAudioSource))]
        public void TryPlayWithSource(bool waitPrevious = false)
        {
            if (audioSource == null)
            {
                Debug.LogError("Audio source is null");
                return;
            }

            TryPlay(audioSource, waitPrevious);
        }

        public void TryPlay(AudioSource audioSource, bool waitPrevious = false)
        {
            if (audioSource.enabled == true)
            {
                if (waitPrevious)
                {
                    if (audioSource.isPlaying)
                    {
                        return;
                    }
                }

                audioSource.clip = Clip;
                audioSource.pitch = GetRange(Pitch);
                audioSource.Play();
            }
        }

        public void TryStop(AudioSource audioSource)
        {
            audioSource.Stop();
        }

        [Button, ShowIf(nameof(hasAudioSource))]
        public void TryStopWithAudioSource()
        {
            if (audioSource == null)
            {
                Debug.LogError("Audio source is null");
                return;
            }

            TryStop(audioSource);
        }

        public void Mute()
        {
            if (audioSource == null)
            {
                Debug.LogError("Audio source is null");
                return;
            }

            audioSource.mute = true;
        }

        public void UnMute()
        {
            if (audioSource == null)
            {
                Debug.LogError("Audio source is null");
                return;
            }

            audioSource.mute = false;
        }
    }
}
