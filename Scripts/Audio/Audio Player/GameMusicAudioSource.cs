using Project.Settings;

namespace Project.Audio
{
    public class GameMusicAudioSource : AbstractGameAudioSource
    {
        private void Awake()
        {
            audioSource.volume = GameSettings.Value.Audio.MusicAudioVolume;
            GameSettingsObserver.OnMusicVolumeChange += UpdateVolume;
            UpdateVolume(audioSource.volume);
        }

        private void OnDestroy()
        {
            GameSettingsObserver.OnMusicVolumeChange -= UpdateVolume;
        }

        public override void UpdateVolume(float newVolume)
        {
            base.UpdateVolume(newVolume);
        }
    }
}
