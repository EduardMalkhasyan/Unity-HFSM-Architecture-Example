using Project.Tools.DictionaryHelp;
using Project.Tools.SOHelp;
using UnityEngine;

namespace Project.Tools.LocalizationHelp
{
    public class LocalizationDataHolder : SOLoader<LocalizationDataHolder>
    {
        [SerializeField] private SerializableDictionary<GameLanguage, SerializableDictionary<LocalizationTMPTextType, string>> tMPTexts;
        [SerializeField] private SerializableDictionary<GameLanguage, SerializableDictionary<LocalizationTMPDropdownType, string[]>> tMPDropdowns;
        [SerializeField] private SerializableDictionary<GameLanguage, SerializableDictionary<LocalizationGameObjectType, GameObject>> gameObjects;

        public string GetTMPTextName(LocalizationTMPTextType localizationTMPTextType)
        {
            var currentLanguage = tMPTexts[LocalizationLanguage.Value.CurrentLanguage];
            var value = currentLanguage[localizationTMPTextType];
            return value;
        }

        public string[] GetTMPDropDown(LocalizationTMPDropdownType localizationTMPDropdownType)
        {
            var currentLanguage = tMPDropdowns[LocalizationLanguage.Value.CurrentLanguage];
            var value = currentLanguage[localizationTMPDropdownType];
            return value;
        }

        public GameObject GetGameObject(LocalizationGameObjectType localizationGameObjectType)
        {
            var currentLanguage = gameObjects[LocalizationLanguage.Value.CurrentLanguage];
            var value = currentLanguage[localizationGameObjectType];
            return value;
        }
    }
}
