using Project.Tools.LocalizationHelp;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class ChooseLanguage : MonoBehaviour
    {
        [SerializeField] private Button englishLanguageButton;
        [SerializeField] private Button russianLanguageButton;

        private Vector3 originalPosition;
        public event Action<GameLanguage> OnAnyLanguageSelection;

        public void SetupAndClose()
        {
            originalPosition = transform.localPosition;
            Close();

            englishLanguageButton.onClick.AddListener(() =>
            {
                SelectLanguage(GameLanguage.English);
            });

            russianLanguageButton.onClick.AddListener(() =>
            {
                SelectLanguage(GameLanguage.Russian);
            });
        }

        private void OnDisable()
        {
            englishLanguageButton.onClick.RemoveAllListeners();
            russianLanguageButton.onClick.RemoveAllListeners();
        }

        private void SelectLanguage(GameLanguage gameLanguage)
        {
            OnAnyLanguageSelection?.Invoke(gameLanguage);
        }

        public void OpenLanguages()
        {
            gameObject.SetActive(true);
            transform.localPosition = Vector3.zero;
        }

        public void Close()
        {
            transform.localPosition = originalPosition;
            gameObject.SetActive(false);
        }
    }
}
