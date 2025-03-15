using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Debugger
{

    public class ShowFPS : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fPSText;
        [SerializeField] private Toggle showFPSToggle;

        private const string IsShowFpsOnKey = "IsShowFpsOnKey";
        [ShowInInspector]
        public bool IsShowFpsOn
        {
            get => PlayerPrefs.GetInt(IsShowFpsOnKey, 0) == 1;
            set
            {
                PlayerPrefs.SetInt(IsShowFpsOnKey, value ? 1 : 0);
            }
        }

        private float deltaTime = 0.0f;

        private void Awake()
        {
            showFPSToggle.isOn = IsShowFpsOn;

            fPSText.gameObject.SetActive(showFPSToggle.isOn);
            enabled = showFPSToggle.isOn;

            showFPSToggle.onValueChanged.AddListener((isON) =>
            {
                enabled = isON;
                fPSText.gameObject.SetActive(isON);
                IsShowFpsOn = isON;
            });
        }

        private void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            UpdateFPS();
        }

        private void UpdateFPS()
        {
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)  ", msec, fps);
            fPSText.text = text;
        }
    }
}
