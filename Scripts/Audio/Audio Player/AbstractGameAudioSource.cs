using UnityEngine;

namespace Project.Audio
{
    public abstract class AbstractGameAudioSource : MonoBehaviour
    {
        [SerializeField] protected AudioSource audioSource;

        public virtual void UpdateVolume(float newVolume)
        {
            audioSource.volume = newVolume;
        }
    }
}
