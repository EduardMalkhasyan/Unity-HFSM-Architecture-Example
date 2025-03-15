using TMPro;
using UnityEngine;

namespace Project.Tools.LocalizationHelp
{
    public class LocalizationTMPText : LocalizationAbstractSceneComponent
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;
        [SerializeField] private LocalizationTMPTextType textType;

        private void Awake()
        {
            InitLocalizationData(LocalizationLanguage.Value.CurrentLanguage);
            LocalizationLanguageObserver.OnLanguageChange += OnLanguageChange;
        }

        private void OnDestroy()
        {
            LocalizationLanguageObserver.OnLanguageChange -= OnLanguageChange;
        }

        protected override void InitLocalizationData(GameLanguage newLanguage)
        {
            textMeshProUGUI.text = LocalizationDataHolder.Value.GetTMPTextName(textType);
        }

        protected override void OnLanguageChange(GameLanguage newLanguage)
        {
            InitLocalizationData(newLanguage);
        }
    }
}
