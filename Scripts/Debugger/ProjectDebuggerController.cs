using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using Zenject;
using Project.ExtensionMethod;
using Project.Main;
using UnityEditor;
using UnityEngine.InputSystem;
using Project.InputSystem;
using Project.Settings;

namespace Project.Debugger
{
    public class ProjectDebuggerController : MonoBehaviour
    {
        [SerializeField] private bool showExternalDebugObjects;

        [Inject] private GameCursor gameCursor;
        [Inject] private LevelHolder levelHolder;
        [SerializeField] private Reporter reporter;

        [SerializeField] private ShowFPS showFPS;
        [SerializeField] private FPSEditor fPSEditor;

        [SerializeField] private ScrollRect scrollRect;

        [SerializeField] private GameObject debugPanel;
        [SerializeField] private GameObject background;
        [SerializeField] private Transform debugScreen;

        [SerializeField] private Button backButton;
        [SerializeField] private Button setFPSButton;
        [SerializeField] private Button setRenderScaleButton;

        [SerializeField] private Button unlockLevelButton;
        [SerializeField] private Button deleteAllDataButton;

        [SerializeField] private Button reporterButton;
        [SerializeField] private Button openPanelButton;

        [SerializeField] private Slider unlockLevelSlider;
        [SerializeField] private Slider setFPSSlider;
        [SerializeField] private Slider setRenderScaleSlider;

        [SerializeField] private TextMeshProUGUI unlockLevelText;
        [SerializeField] private TextMeshProUGUI setFPSText;
        [SerializeField] private TextMeshProUGUI setRenderScaleText;

        [SerializeField] private TextMeshProUGUI whatCurrentLevelText;

        private UniversalRenderPipelineAsset GetCurrentRenderPipelineAsset()
        {
            return QualitySettings.renderPipeline as UniversalRenderPipelineAsset;
        }

        public void Awake()
        {
#if PROJECT_DEBUGGER
            gameObject.SetActive(true);
            Setup();
            TryShowExternalDebugObjects();
#else
            Destroy(reporter.gameObject);
            Destroy(gameObject);
#endif
        }

        public void Update()
        {
            if (Keyboard.current != null)
            {
                if (Keyboard.current.pKey.wasPressedThisFrame)
                {
                    Pause();
                }

                if (Keyboard.current.iKey.wasPressedThisFrame)
                {
                    OpenPanel();
                }

                if (Keyboard.current.oKey.wasPressedThisFrame)
                {
                    ShowReporter();
                }
            }

            if (Gamepad.current != null)
            {
                if (Gamepad.current.selectButton.wasPressedThisFrame)
                {
                    OpenPanel();
                }
            }
        }

        private void Pause()
        {
#if UNITY_EDITOR
            EditorApplication.isPaused = true;
#endif
        }

        private void Setup()
        {
            debugScreen.localPosition = Vector3.zero;
            background.transform.localPosition = Vector3.zero;

            ClosePanel();
            backButton.onClick.AddListener(ClosePanel);

            unlockLevelSlider.minValue = 1;
            unlockLevelSlider.maxValue = LevelSettings.Value.LevelsCount;
            unlockLevelSlider.value = unlockLevelSlider.maxValue;
            unlockLevelText.text = unlockLevelSlider.maxValue.ToString();
            unlockLevelSlider.onValueChanged.AddListener((value) => { unlockLevelText.text = value.ToString(); });

            setFPSSlider.value = setFPSSlider.maxValue;
            setFPSText.text = setFPSSlider.maxValue.ToString();
            setFPSSlider.onValueChanged.AddListener((value) => { setFPSText.text = value.ToString(); });

            UpdateCurrentRenderPipelineAssetSettings();

            setFPSButton.onClick.AddListener(SetFPSFromSliderValue);
            unlockLevelButton.onClick.AddListener(UnlockLevelsFromSliderValue);

            reporterButton.onClick.AddListener(() =>
            {
                ShowReporter();
            });

            openPanelButton.onClick.AddListener(() =>
            {
                OpenPanel();
            });

            deleteAllDataButton.onClick.AddListener(() =>
            {
                PlayerPrefs.DeleteAll();
                Debug.Log($"All data deleted");
            });
        }

        private void UpdateCurrentRenderPipelineAssetSettings()
        {
            setRenderScaleText.text = GetCurrentRenderPipelineAsset().renderScale.ToString();
            setRenderScaleSlider.value = GetCurrentRenderPipelineAsset().renderScale;
            setRenderScaleSlider.onValueChanged.AddListener((value) => { setRenderScaleText.text = value.ToString(); });
            setRenderScaleButton.onClick.AddListener(() => { GetCurrentRenderPipelineAsset().renderScale = setRenderScaleSlider.value; });
        }

        private void UnlockLevelsFromSliderValue()
        {
            LevelSettings.Value.SetLevelDataManually((int)unlockLevelSlider.value);
        }

        private void SetFPSFromSliderValue()
        {
            fPSEditor.ChangeFPS((int)setFPSSlider.value);
        }

        private void TryShowCurrentLevel()
        {
            if (levelHolder.currentLevelTuple.level != null)
            {
                whatCurrentLevelText.text = levelHolder.currentLevelTuple.index.ToString();
            }
            else
            {
                whatCurrentLevelText.text = string.Empty;
            }
        }

        private void TryShowExternalDebugObjects()
        {
            var externalDebugObjects = FindObjectsOfType<ExternalDebugObject>(true);

            foreach (var item in externalDebugObjects)
            {
                item.gameObject.SetActive(showExternalDebugObjects);
            }
        }

        private void ShowReporter()
        {
            gameCursor.ShowMouseCursor();
            reporter.DoShow();
        }

        private void OpenPanel()
        {
            gameCursor.ShowMouseCursor();
            scrollRect.DoToTop();

            UpdateCurrentRenderPipelineAssetSettings();
            TryShowCurrentLevel();

            debugPanel.SetActive(true);
            background.SetActive(true);
        }

        private void ClosePanel()
        {
            debugPanel.SetActive(false);
            background.SetActive(false);
        }
    }
}
