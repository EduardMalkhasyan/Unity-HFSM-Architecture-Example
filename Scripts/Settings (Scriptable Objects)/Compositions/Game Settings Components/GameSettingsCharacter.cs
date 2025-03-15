using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Project.Settings
{
    [Serializable]
    public class GameSettingsCharacter
    {
        [SerializeField, HideInInspector] private float mouseSensitivity;
        [JsonProperty, ShowInInspector, PropertyRange(0.1f, 20f)]
        public float MouseSensitivity
        {
            get => mouseSensitivity;
            set
            {
                mouseSensitivity = value;
                GameSettingsObserver.OnMouseSensitivityChangeInvoke(value);
            }
        }
    }
}
