using Project.Audio;
using TMPro;
using UnityEngine;
using Zenject;

namespace Project.UI
{
    public class SoundDropdown : TMP_Dropdown
    {
        [Inject] private UIAudioManager audioManager;

        protected override void Awake()
        {
            base.Start();
            onValueChanged.AddListener(OnDropdownValueChanged);
        }

        private void OnDropdownValueChanged(int index)
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
            onValueChanged.RemoveListener(OnDropdownValueChanged);
            base.OnDestroy();
        }
    }
}