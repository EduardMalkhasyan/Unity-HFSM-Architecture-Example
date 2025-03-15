using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI.Widget
{
    public class MainMenuWidget : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button levelsButton;
        [SerializeField] private Button exitButton;

        public event Action OnPlayGame;
        public event Action OnGoToSettings;
        public event Action OnGoToLevels;
        public event Action OnGameExit;

        private void OnEnable()
        {
            playButton.onClick.AddListener(() => OnPlayGame.Invoke());
            settingsButton.onClick.AddListener(() => OnGoToSettings.Invoke());
            levelsButton.onClick.AddListener(() => OnGoToLevels.Invoke());
            exitButton.onClick.AddListener(() => OnGameExit.Invoke());
        }

        private void OnDisable()
        {
            playButton.onClick.RemoveAllListeners();
            settingsButton.onClick.RemoveAllListeners();
            levelsButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }
    }
}
