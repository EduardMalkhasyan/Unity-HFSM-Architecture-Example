using Project.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    public class SoundButton : Button
    {
        [Inject] private UIAudioManager audioManager;

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            if (this.interactable)
            {
                audioManager.PlayClick();
            }
        }
    }
}
