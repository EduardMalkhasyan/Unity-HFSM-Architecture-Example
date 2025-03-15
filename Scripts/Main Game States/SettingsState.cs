using Project.InputSystem;
using Project.Settings;
using Project.State;
using Project.UI;
using Project.UI.Widget;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;
using Project.Tools.LocalizationHelp;

namespace Project.GameState
{
    public class SettingsState : AbstractMainGameState
    {
        [Inject] private UIScreensController screensController;
        [Inject] private SettingsWidget settingsWidget;
        [Inject] private MainGameStates mainGameStates;
        [Inject] private UIMainBackground uIMainBackground;
        [Inject] private MainInputSystem mainInputSystem;

        private CancellationTokenSource cancellationTokenSource;

        public override void Enter()
        {
            uIMainBackground.Open();

            screensController.ShowUIScreen(UIScreenEnum.Settings, OnCompleteCB: () =>
            {
                RunDetection();
            });

            settingsWidget.SetQualityDropDown(GameSettings.Value.Graphics.QualityLevel);
            settingsWidget.SetLanguageDropDown(LocalizationLanguage.Value.CurrentLanguage);
            settingsWidget.SetEffectsAudioSlider(GameSettings.Value.Audio.EffectAudioVolume);
            settingsWidget.SetMusicAudioSlider(GameSettings.Value.Audio.MusicAudioVolume);
            settingsWidget.SetMouseSensitivitySlider(GameSettings.Value.Character.MouseSensitivity);
            settingsWidget.SetVSyncToggle(GameSettings.Value.Graphics.VSync);
            settingsWidget.SetShadowsToggle(GameSettings.Value.Graphics.Shadows);

            settingsWidget.OnGoBack += EnterGoBackState;
            settingsWidget.OnDeleteAllData += OnDeleteAllData;

            settingsWidget.OnQualityChanged += SetQualityLevel;

            settingsWidget.OnEffectsAudioChanged += SetEffectAudioVolume;
            settingsWidget.OnMusicAudioChanged += SetMusicAudioVolume;

            settingsWidget.OnMouseSensitivityChanged += SetMouseSensitivity;
            settingsWidget.OnLanguageChanged += SetLanguage;
            settingsWidget.OnVSyncChanged += SetVSync;
            settingsWidget.OnShadowsChanged += SetShadows;
        }

        public override void Exit()
        {
            StopDetection();
            uIMainBackground.Close();

            settingsWidget.OnGoBack -= EnterGoBackState;
            settingsWidget.OnDeleteAllData -= OnDeleteAllData;
            settingsWidget.OnQualityChanged -= SetQualityLevel;
            settingsWidget.OnEffectsAudioChanged -= SetEffectAudioVolume;
            settingsWidget.OnMusicAudioChanged -= SetMusicAudioVolume;
            settingsWidget.OnMouseSensitivityChanged -= SetMouseSensitivity;
            settingsWidget.OnLanguageChanged -= SetLanguage;
            settingsWidget.OnVSyncChanged -= SetVSync;
            settingsWidget.OnShadowsChanged -= SetShadows;
        }

        private async void RunDetection()
        {
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await UniTask.NextFrame(cancellationToken: cancellationTokenSource.Token);

                while (cancellationTokenSource.IsCancellationRequested == false)
                {
                    if (mainInputSystem.GoBackInputAction.WasPressedThisFrame())
                    {
                        OnGoBack();
                    }

                    await UniTask.Yield(cancellationToken: cancellationTokenSource.Token);
                }
            }
            catch
            {

            }
        }

        private void StopDetection()
        {
            cancellationTokenSource?.Cancel();
        }

        private void OnGoBack()
        {
            EnterGoBackState();
        }

        private void OnDeleteAllData()
        {
            settingsWidget.OpenDeleteDataWindow();
            settingsWidget.OnYesDeleteData += OnYesDeleteAllData;
            settingsWidget.OnNoDeleteData += OnNoDeleteAllData;
        }

        private void OnYesDeleteAllData()
        {
            settingsWidget.OnYesDeleteData -= OnYesDeleteAllData;
            GameSettings.Value.DeleteAllStoredData();
            settingsWidget.CloseDeleteDataWindow();
            Application.Quit();
        }

        private void OnNoDeleteAllData()
        {
            settingsWidget.OnNoDeleteData -= OnNoDeleteAllData;
            settingsWidget.CloseDeleteDataWindow();
        }

        public void SetMouseSensitivity(float value)
        {
            GameSettings.Value.Character.MouseSensitivity = value;
        }

        public void SetQualityLevel(int value)
        {
            GameSettings.Value.Graphics.QualityLevel = value;
            GameSettings.Value.Graphics.UpdateQualityLevel(value);
        }

        public void SetLanguage(GameLanguage value)
        {
            LocalizationLanguage.Value.CurrentLanguage = value;
        }

        public void SetEffectAudioVolume(float value)
        {
            GameSettings.Value.Audio.EffectAudioVolume = value;
        }

        public void SetMusicAudioVolume(float value)
        {
            GameSettings.Value.Audio.MusicAudioVolume = value;
        }

        public void SetVSync(bool isOn)
        {
            GameSettings.Value.Graphics.VSync = isOn;
            GameSettings.Value.Graphics.UpdateVSync();
        }

        public void SetShadows(bool isOn)
        {
            GameSettings.Value.Graphics.Shadows = isOn;
            GameSettings.Value.Graphics.UpdateShadows();
        }

        public void EnterGoBackState()
        {
            mainGameStates.EnterGoBackState();
        }
    }
}
