using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI.Widget
{
    public class PauseWidget : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button settingsButton;

        public event Action OnContinue;
        public event Action OnMainMenu;
        public event Action OnSettings;

        private void OnEnable()
        {
            continueButton.onClick.AddListener(() => OnContinue.Invoke());
            mainMenuButton.onClick.AddListener(() => OnMainMenu.Invoke());
            settingsButton.onClick.AddListener(() => OnSettings.Invoke());
        }

        private void OnDisable()
        {
            continueButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.RemoveAllListeners();
            settingsButton.onClick.RemoveAllListeners();
        }
    }
}
