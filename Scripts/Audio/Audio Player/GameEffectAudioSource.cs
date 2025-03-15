using Project.Settings;

namespace Project.Audio
{
    public class GameEffectAudioSource : AbstractGameAudioSource
    {
        private void Awake()
        {
            audioSource.volume = GameSettings.Value.Audio.EffectAudioVolume;
            GameSettingsObserver.OnEffectVolumeChange += UpdateVolume;
            UpdateVolume(audioSource.volume);
        }

        private void OnDestroy()
        {
            GameSettingsObserver.OnEffectVolumeChange -= UpdateVolume;
        }

        public override void UpdateVolume(float newVolume)
        {
            base.UpdateVolume(newVolume);
        }
    }
}
