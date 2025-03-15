using UnityEngine;

namespace Project.Audio
{
    public class UIAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioPlayerPreset clickAudioClip;
        [SerializeField] private AudioPlayerPreset mainMenuMusic;

        public void PlayMainMenuMusic()
        {
            mainMenuMusic.TryPlayWithSource(waitPrevious: true);
        }

        public void StopMainMenuMusic()
        {
            mainMenuMusic.TryStopWithAudioSource();
        }

        public void PlayClick()
        {
            clickAudioClip.TryPlayWithSource();
        }
    }
}
