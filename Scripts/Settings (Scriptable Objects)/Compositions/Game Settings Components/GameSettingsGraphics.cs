using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Project.Settings
{
    [Serializable]
    public class GameSettingsGraphics
    {
        [SerializeField] private UniversalRenderPipelineAsset mainRenderPipeline;

        [SerializeField, HideInInspector] private int qualityLevel;
        [JsonProperty, ShowInInspector, PropertyRange(0, 4)]
        public int QualityLevel
        {
            get => qualityLevel;
            set
            {
                qualityLevel = value;
            }
        }

        [SerializeField, HideInInspector] private bool vSync;
        [JsonProperty, ShowInInspector]
        public bool VSync
        {
            get => vSync;
            set
            {
                vSync = value;
            }
        }

        public void UpdateVSync()
        {
            QualitySettings.vSyncCount = VSync ? 1 : 0;
        }

        [SerializeField, HideInInspector] private bool shadows;
        [SerializeField, ReadOnly] private int shadowDistance = 250;
        [JsonProperty, ShowInInspector]
        public bool Shadows
        {
            get => shadows;
            set
            {
                shadows = value;
            }
        }

        public void UpdateShadows()
        {
            mainRenderPipeline.shadowDistance = Shadows ? shadowDistance : 0;
        }

        public void UpdateQualityLevel(int level)
        {
            // Very Low = 0, Low = 1, Medium = 2, High = 3, Ultra = 4
            switch (QualityLevel)
            {
                case 0:
                    mainRenderPipeline.renderScale = 0.4f;
                    mainRenderPipeline.shadowCascadeCount = 2;
                    mainRenderPipeline.msaaSampleCount = (int)MsaaQuality.Disabled;
                    break;
                case 1:
                    mainRenderPipeline.renderScale = 0.6f;
                    mainRenderPipeline.shadowCascadeCount = 2;
                    mainRenderPipeline.msaaSampleCount = (int)MsaaQuality.Disabled;
                    break;
                case 2:
                    mainRenderPipeline.renderScale = 0.8f;
                    mainRenderPipeline.shadowCascadeCount = 3;
                    mainRenderPipeline.msaaSampleCount = (int)MsaaQuality.Disabled;
                    break;
                case 3:
                    mainRenderPipeline.renderScale = 1;
                    mainRenderPipeline.shadowCascadeCount = 4;
                    mainRenderPipeline.msaaSampleCount = (int)MsaaQuality.Disabled;
                    break;
                case 4:
                    mainRenderPipeline.renderScale = 2;
                    mainRenderPipeline.shadowCascadeCount = 4;
                    mainRenderPipeline.msaaSampleCount = (int)MsaaQuality.Disabled;
                    break;
            }
        }
    }
}
