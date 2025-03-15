using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Project.Tools.DictionaryHelp;
using Newtonsoft.Json;
using Project.Tools.SOHelp;

namespace Project.Settings
{
    public class LevelSettings : SOLoader<LevelSettings>
    {
        [SerializeField, JsonIgnore, FolderPath(AbsolutePath = false)] private string levelsFolderPath;
        [SerializeField, JsonIgnore] private string levelName;

        [SerializeField, JsonIgnore] private SerializableDictionary<int, LevelPreset> levelPresetsKVP;

#pragma warning disable 0414
        private bool isLevelsCountRight;
        [ShowIf(nameof(isLevelsCountRight)), InfoBox("Levels count not same with prefabs", InfoMessageType.Error)]
#pragma warning restore 0414
        [ShowInInspector, JsonIgnore, ReadOnly] private int MaxLevelsCountInFolder => LevelsCountInFolder();

        [SerializeField, JsonIgnore] private int levelsCount = int.MaxValue;
        [JsonIgnore] public int LevelsCount => levelsCount;

        private const int initialLevelIndex = 1;

        [SerializeField, ReadOnly] private int levelIndex;
        [JsonProperty]
        public int LevelIndex
        {
            get => levelIndex;
            private set
            {
                if (LevelsCount > value)
                {
                    levelIndex = value;
                }
                else
                {
                    Debug.Log($"You achieved to max level {LevelsCount}, all levels count is {LevelsCount}");
                    levelIndex = LevelsCount;
                    PossibleUpdatedLevelCount = (LevelsCount + initialLevelIndex);
                }
            }
        }

        [SerializeField, ReadOnly] private int possibleUpdatedLevelCount;
        [JsonProperty]
        public int PossibleUpdatedLevelCount
        {
            get => possibleUpdatedLevelCount;
            private set
            {
                possibleUpdatedLevelCount = value;
            }
        }

        public bool IsAnyLevelPassed()
        {
            return LevelIndex > initialLevelIndex;
        }

        public bool IsLastLevelByIndex(int nextLevelIndex)
        {
            return nextLevelIndex >= LevelsCount;
        }

        public bool IsLastLevel()
        {
            return LevelIndex >= LevelsCount;
        }

        public string LevelFullName()
        {
            return levelName + LevelIndex.ToString();
        }

        public string LevelByIndexFullName(int index)
        {
            return levelName + index.ToString();
        }

        public void IncrementLevel(int amount = 1)
        {
            LevelIndex += amount;
        }

        public void TryLevelUp(int currentIndex)
        {
            var levelUpIndex = currentIndex++;
            if (LevelIndex > levelUpIndex)
            {
                return;
            }

            LevelIndex = currentIndex;
        }

        [Button]
        public void SetLevelDataManually(int amount = 1)
        {
            PossibleUpdatedLevelCount = initialLevelIndex;
            LevelIndex = Mathf.Max(initialLevelIndex, amount);
        }

        public void CheckLevelsStatus()
        {
            CheckIfLevelsCountIsRight();
            CheckIfLevelIndexIsSame();
        }

        private void CheckIfLevelsCountIsRight()
        {
#if UNITY_EDITOR
            if (MaxLevelsCountInFolder != LevelsCount)
            {
                Debug.LogError($"LevelCount: {LevelsCount}, must be same with prefab levels count: {MaxLevelsCountInFolder} in folder");
            }

            if (MaxLevelsCountInFolder != levelPresetsKVP.Count)
            {
                Debug.LogError($"LevelPresetsKVP: {levelPresetsKVP.Count}," +
                               $" must be same with prefab levels count: {MaxLevelsCountInFolder} in folder");
            }
#endif

            if (LevelsCount > LevelIndex)
            {
                if (PossibleUpdatedLevelCount > LevelIndex)
                {
                    LevelIndex = PossibleUpdatedLevelCount;
                    Debug.Log($"LevelData: {LevelIndex} updated to PossibleUpdatedLevelCount: {PossibleUpdatedLevelCount}, reason is thats new level added");
                    PossibleUpdatedLevelCount = initialLevelIndex;
                }
            }
        }

        private void CheckIfLevelIndexIsSame()
        {
            foreach (var keyValuePair in levelPresetsKVP)
            {
                if (keyValuePair.Value.LevelIndex != keyValuePair.Key)
                {
                    Debug.LogError($"Level index {keyValuePair.Key} is not same with his level preset index {keyValuePair.Value.LevelIndex}");
                }
            }
        }

        private int LevelsCountInFolder()
        {
#if UNITY_EDITOR
            string[] guids = AssetDatabase.FindAssets("t:Prefab", new[] { levelsFolderPath });

            if (guids.Length != LevelsCount)
            {
                var warningText = $"LevelCount: {LevelsCount}, must be same with prefab levels count: {guids.Length} in folder";
                isLevelsCountRight = true;
                Debug.LogError(warningText);
            }
            else
            {
                isLevelsCountRight = false;
            }

            return guids.Length;
#else
            return 0;
#endif
        }
    }
}

