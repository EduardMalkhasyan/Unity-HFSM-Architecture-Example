using Sirenix.OdinInspector;
using Project.Tools.SOHelp;
using Newtonsoft.Json;
using UnityEngine;

namespace Project.Tools.LocalizationHelp
{
    public class LocalizationLanguage : SOLoader<LocalizationLanguage>
    {
        [SerializeField, HideInInspector] private GameLanguage currentLanguage;

        [JsonProperty, ShowInInspector]
        public GameLanguage CurrentLanguage
        {
            get => currentLanguage;
            set
            {
                currentLanguage = value;
                LocalizationLanguageObserver.OnLanguageChangeInvoke(currentLanguage);
            }
        }
    }
}
