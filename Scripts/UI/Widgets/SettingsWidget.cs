using Project.ExtensionMethod;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Project.Tools.LocalizationHelp;

namespace Project.UI.Widget
{

    public class SettingsWidget : MonoBehaviour
    {
        [SerializeField] private CanvasGroup deleteDataWindow;
        [SerializeField] private ScrollRect scrollRect;

        [SerializeField] private Button backButton;
        [SerializeField] private Button deleteAllDataButton;
        [SerializeField] private Button yesDeleteAllDataButton;
        [SerializeField] private Button noDeleteAllDataButton;
        [SerializeField] private TMP_Dropdown qualityDropDown;
        [SerializeField] private TMP_Dropdown languageDropDown;

        [SerializeField] private Slider effectsAudioSlider;
        [SerializeField] private TextMeshProUGUI effectsAudioSliderValueText;
        [SerializeField] private Slider musicAudioSlider;
        [SerializeField] private TextMeshProUGUI musicAudioSliderValueText;
        [SerializeField] private Slider mouseSensitivitySlider;
        [SerializeField] private TextMeshProUGUI mouseSensitivitySliderValueText;

        [SerializeField] private Toggle vSyncToggle;
        [SerializeField] private Toggle shadowsToggle;

        public event Action OnGoBack;
        public event Action OnDeleteAllData;
        public event Action OnYesDeleteData;
        public event Action OnNoDeleteData;
        public event Action<int> OnQualityChanged;
        public event Action<float> OnEffectsAudioChanged;
        public event Action<float> OnMusicAudioChanged;
        public event Action<float> OnMouseSensitivityChanged;
        public event Action<bool> OnVSyncChanged;
        public event Action<bool> OnShadowsChanged;
        public event Action<GameLanguage> OnLanguageChanged;

        private const string format = "F1";
        private const float multiplayer = 100f;
        private float deleteDataWindowAlphaTime = 0.25f;

        private void OnEnable()
        {
            deleteDataWindow.gameObject.SetActive(false);
            deleteDataWindow.interactable = false;
            deleteDataWindow.alpha = 0;

            scrollRect.DoToTop();

            backButton.onClick.AddListener(() => OnGoBack.Invoke());
            deleteAllDataButton.onClick.AddListener(() => OnDeleteAllData.Invoke());
            yesDeleteAllDataButton.onClick.AddListener(() => OnYesDeleteData.Invoke());
            noDeleteAllDataButton.onClick.AddListener(() => OnNoDeleteData.Invoke());

            qualityDropDown.onValueChanged.AddListener((value) => OnQualityChanged.Invoke(value));
            languageDropDown.onValueChanged.AddListener((value) => OnLanguageChanged.Invoke((GameLanguage)value));

            effectsAudioSlider.onValueChanged.AddListener((value) =>
            {
                effectsAudioSliderValueText.text = (effectsAudioSlider.value * multiplayer).ToString(format);
                OnEffectsAudioChanged.Invoke(value);
            });

            musicAudioSlider.onValueChanged.AddListener((value) =>
            {
                musicAudioSliderValueText.text = (musicAudioSlider.value * multiplayer).ToString(format);
                OnMusicAudioChanged.Invoke(value);
            });

            mouseSensitivitySlider.onValueChanged.AddListener((value) =>
            {
                mouseSensitivitySliderValueText.text = mouseSensitivitySlider.value.ToString(format);
                OnMouseSensitivityChanged.Invoke(value);
            });

            vSyncToggle.onValueChanged.AddListener((value) =>
            {
                OnVSyncChanged.Invoke(value);
            });
            shadowsToggle.onValueChanged.AddListener((value) =>
            {
                OnShadowsChanged.Invoke(value);
            });
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveAllListeners();
            deleteAllDataButton.onClick.RemoveAllListeners();
            yesDeleteAllDataButton.onClick.RemoveAllListeners();
            noDeleteAllDataButton.onClick.RemoveAllListeners();
            qualityDropDown.onValueChanged.RemoveAllListeners();
            languageDropDown.onValueChanged.RemoveAllListeners();
            effectsAudioSlider.onValueChanged.RemoveAllListeners();
            musicAudioSlider.onValueChanged.RemoveAllListeners();
            mouseSensitivitySlider.onValueChanged.RemoveAllListeners();
            vSyncToggle.onValueChanged.RemoveAllListeners();
            shadowsToggle.onValueChanged.RemoveAllListeners();
        }

        public void SetQualityDropDown(int qualitySettingsLevel)
        {
            qualityDropDown.value = qualitySettingsLevel;
        }

        public void SetLanguageDropDown(GameLanguage languageLevel)
        {
            languageDropDown.value = (int)languageLevel;
        }

        public void SetEffectsAudioSlider(float value)
        {
            effectsAudioSlider.value = value;
            effectsAudioSliderValueText.text = (effectsAudioSlider.value * multiplayer).ToString(format);
        }

        public void SetMusicAudioSlider(float value)
        {
            musicAudioSlider.value = value;
            musicAudioSliderValueText.text = (musicAudioSlider.value * multiplayer).ToString(format);
        }

        public void SetMouseSensitivitySlider(float value)
        {
            mouseSensitivitySlider.value = value;
            mouseSensitivitySliderValueText.text = mouseSensitivitySlider.value.ToString(format);
        }

        public void SetVSyncToggle(bool value)
        {
            vSyncToggle.isOn = value;
        }

        public void SetShadowsToggle(bool value)
        {
            shadowsToggle.isOn = value;
        }

        public void OpenDeleteDataWindow()
        {
            deleteDataWindow.gameObject.SetActive(true);

            deleteDataWindow.DOFade(1, deleteDataWindowAlphaTime).OnComplete(() =>
            {
                deleteDataWindow.interactable = true;
            });
        }

        public void CloseDeleteDataWindow()
        {
            deleteDataWindow.DOFade(0, deleteDataWindowAlphaTime).OnComplete(() =>
            {
                deleteDataWindow.interactable = false;
                deleteDataWindow.gameObject.SetActive(false);
            });
        }
    }
}
