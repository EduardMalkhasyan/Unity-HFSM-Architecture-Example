using Project.GameState;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class LevelCard : MonoBehaviour
    {
        [SerializeField, ReadOnly] private TextMeshProUGUI levelCountText;
        [SerializeField] private Button openLevelButton;
        [SerializeField, ReadOnly] private int levelIndex;

        private void OnDestroy()
        {
            openLevelButton.onClick.RemoveAllListeners();
        }

        public void Setup(int levelIndex, bool isActive, Action OnLevelOpen)
        {
            this.levelIndex = levelIndex;
            levelCountText.text = levelIndex.ToString();
            CheckCard(isActive);
            openLevelButton.onClick.AddListener(() => OnLevelOpen.Invoke());
        }

        public void CheckCard(bool isActive)
        {
            openLevelButton.interactable = isActive;
        }
    }
}
