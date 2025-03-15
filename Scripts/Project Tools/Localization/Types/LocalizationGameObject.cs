using Project.ExtensionMethod;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Tools.LocalizationHelp
{
    public class LocalizationGameObject : LocalizationAbstractSceneComponent
    {
        [ShowInInspector, ReadOnly] private Dictionary<GameLanguage, GameObject> pairs = new Dictionary<GameLanguage, GameObject>();
        [SerializeField] private bool disableAllChildren = true;
        [SerializeField, HideIf(nameof(disableAllChildren))] private GameObject[] gameObjectsToDisable;
        [SerializeField] private LocalizationGameObjectType gameObjectType;

        private void Awake()
        {
            pairs.Clear();

            if (disableAllChildren == false)
            {
                gameObjectsToDisable.ForEach(gameObject => { gameObject.SetActive(false); });
            }
            else
            {
                var children = transform.GetComponentsInChildrenWithoutParent<Transform>(includeInactive: true);
                children.ForEach(transform => { transform.gameObject.SetActive(false); });
            }

            InitLocalizationData(LocalizationLanguage.Value.CurrentLanguage);
            LocalizationLanguageObserver.OnLanguageChange += OnLanguageChange;
        }

        private void OnDestroy()
        {
            LocalizationLanguageObserver.OnLanguageChange -= OnLanguageChange;
        }

        protected override void InitLocalizationData(GameLanguage newLanguage)
        {
            pairs.ForEach(pair => { pair.Value.SetActive(false); });

            if (pairs.ContainsKey(LocalizationLanguage.Value.CurrentLanguage))
            {
                pairs[LocalizationLanguage.Value.CurrentLanguage].SetActive(true);
            }
            else
            {
                var gameObject = Instantiate(LocalizationDataHolder.Value.GetGameObject(gameObjectType));
                gameObject.transform.SetParent(transform, false);
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localRotation = Quaternion.identity;
                gameObject.transform.localScale = Vector3.one;
                gameObject.SetActive(true);
                pairs.TryAdd(LocalizationLanguage.Value.CurrentLanguage, gameObject);
            }
        }

        protected override void OnLanguageChange(GameLanguage newLanguage)
        {
            InitLocalizationData(newLanguage);
        }
    }
}
