using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Project.Tools.LocalizationHelp
{
    [InfoBox("Please check if dropdownKVP must be same size with TMP_Dropdown.dropdown", InfoMessageType.Warning)]
    public class LocalizationTMPDropDown : LocalizationAbstractSceneComponent
    {
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private LocalizationTMPDropdownType dropDownType;

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
            var localizationTexts = LocalizationDataHolder.Value.GetTMPDropDown(dropDownType);

            for (int i = 0; i < dropdown.options.Count; i++)
            {
                if (dropdown.captionText.text == dropdown.options[i].text)
                {
                    dropdown.captionText.text = localizationTexts[i];
                }

                TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
                {
                    image = null,
                    text = localizationTexts[i],
                };

                dropdown.options[i] = optionData;
            }
        }

        protected override void OnLanguageChange(GameLanguage newLanguage)
        {
            InitLocalizationData(newLanguage);
        }
    }
}
