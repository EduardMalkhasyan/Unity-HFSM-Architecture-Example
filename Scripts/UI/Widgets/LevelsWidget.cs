using Project.ExtensionMethod;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.UI.Widget
{
    public class LevelsWidget : MonoBehaviour
    {
        [Inject] private DiContainer diContainer;

        [SerializeField] private ScrollRect scrollRect;

        [SerializeField] private LevelCard levelCard;
        [SerializeField] private Button backButton;
        [SerializeField] private RectTransform container;
        [field: SerializeField, ReadOnly] public List<LevelCard> LevelCards { get; private set; }

        public event Action OnGoBack;

        private void OnEnable()
        {
            scrollRect.DoToTop();
            backButton.onClick.AddListener(() => OnGoBack.Invoke());
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveAllListeners();
        }

        public void CreateLevelCardAndSetup(int levelIndex, bool isActive, Action OnLevelOpen)
        {
            var card = diContainer.InstantiatePrefab(levelCard, container).GetComponent<LevelCard>();
            card.transform.localScale = Vector3.one;
            card.gameObject.name = "Level " + levelIndex;
            card.Setup(levelIndex, isActive, OnLevelOpen);
            LevelCards.Add(card);
        }
    }
}
