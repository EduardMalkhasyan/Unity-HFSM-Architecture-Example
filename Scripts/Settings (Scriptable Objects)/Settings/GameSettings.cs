using Newtonsoft.Json;
using Project.Tools.SOHelp;
using UnityEngine;

namespace Project.Settings
{
    public class GameSettings : SOLoader<GameSettings>
    {
        [SerializeField, JsonIgnore] private GameInitialState initialState;
        [JsonIgnore] public GameInitialState InitialState => initialState;

        [SerializeField, JsonIgnore] private string gameSceneAddress;
        [JsonIgnore] public string GameSceneAddress => gameSceneAddress;

        [SerializeField, JsonIgnore, Space] private float gravity_Y;
        [SerializeField, JsonIgnore, Space] private int fpsCount;

        [SerializeField] private GameSettingsAudio audio;
        [JsonProperty] public GameSettingsAudio Audio { get => audio; private set => audio = value; }

        [SerializeField] private GameSettingsGraphics graphics;
        [JsonProperty] public GameSettingsGraphics Graphics { get => graphics; private set => graphics = value; }

        [SerializeField] private GameSettingsCharacter character;
        [JsonProperty] public GameSettingsCharacter Character { get => character; private set => character = value; }

        [SerializeField] private GameSettingsLanguage language;
        [JsonProperty] public GameSettingsLanguage Language { get => language; private set => language = value; }

        public void InitSettings()
        {
            SetNewGravity();
            SetGameFPS();
            Graphics.UpdateVSync();
            Graphics.UpdateShadows();
            Graphics.UpdateQualityLevel(Graphics.QualityLevel);
        }

        private void SetNewGravity()
        {
            Physics.gravity = new Vector3(0, gravity_Y, 0);
        }

        private void SetGameFPS()
        {
            Application.targetFrameRate = fpsCount;
        }

        public void DeleteAllStoredData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
