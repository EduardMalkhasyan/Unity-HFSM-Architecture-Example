using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Project.Settings
{
    [Serializable]
    public class GameSettingsLanguage
    {
        [SerializeField, HideInInspector] private bool isInitialLanguageSelected;
        [JsonProperty, ShowInInspector]
        public bool IsInitialLanguageSelected
        {
            get => isInitialLanguageSelected;
            set
            {
                isInitialLanguageSelected = value;
            }
        }
    }
}
