using Project.Audio;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    public class SoundToggle : Toggle
    {
        [Inject] private UIAudioManager audioManager;

        protected override void Awake()
        {
            base.Start();
            onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool isOn)
        {
            if (this.interactable)
            {
                if (audioManager != null)
                {
                    audioManager.PlayClick();
                }
            }
        }

        protected override void OnDestroy()
        {
            onValueChanged.RemoveListener(OnToggleValueChanged);
            base.OnDestroy();
        }
    }
}