using Project.InLevel;
using Project.Settings;
using Project.Tools;
using Project.Tools.Help;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using Zenject;

namespace Project.Main
{
    public class LevelHolder : MonoBehaviour
    {
        [Inject] private AddressableLoader addressableLoader;
        [Inject] private DiContainer diContainer;

        [ShowInInspector, ReadOnly] public (InLevel.Level level, string name, int index) currentLevelTuple;

        public InLevel.Level Level => currentLevelTuple.level;
        public int Index => currentLevelTuple.index;

        public void LoadStoredLevel(Action OnLoadLevelCB)
        {
            TryReleaseAndDestroyCurrentLevel();

            var levelIndex = LevelSettings.Value.LevelIndex;
            var levelFullName = LevelSettings.Value.LevelByIndexFullName(levelIndex);

            addressableLoader.TryLoadAssetAsync(levelFullName, (levelPrefab) =>
            {
                InitLevel(levelFullName, levelIndex, levelPrefab);
                OnLoadLevelCB?.Invoke();
            });
        }

        public void LoadCurrentLevel(Action OnLoadLevelCB)
        {
            TryReleaseAndDestroyCurrentLevel();

            addressableLoader.TryLoadAssetAsync(currentLevelTuple.name, (levelPrefab) =>
            {
                InitLevel(currentLevelTuple.name, currentLevelTuple.index, levelPrefab);
                OnLoadLevelCB?.Invoke();
            });
        }

        public void TryLoadNextLevel(Action OnLoadLevelCB)
        {
            TryReleaseAndDestroyCurrentLevel();

            var nextLevelIndex = currentLevelTuple.index + 1;

            addressableLoader.TryLoadAssetAsync(LevelSettings.Value.LevelByIndexFullName(nextLevelIndex), (levelPrefab) =>
            {
                var levelFullName = LevelSettings.Value.LevelByIndexFullName(nextLevelIndex);
                InitLevel(levelFullName, nextLevelIndex, levelPrefab);
                OnLoadLevelCB?.Invoke();
            });
        }

        public void LoadLevelByIndex(int levelIndex, Action OnLoadLevelCB)
        {
            TryReleaseAndDestroyCurrentLevel();

            addressableLoader.TryLoadAssetAsync(LevelSettings.Value.LevelByIndexFullName(levelIndex), (levelPrefab) =>
            {
                var levelFullName = LevelSettings.Value.LevelByIndexFullName(levelIndex);
                InitLevel(levelFullName, levelIndex, levelPrefab);
                OnLoadLevelCB?.Invoke();
            });
        }

        private void InitLevel(string levelFullName, int levelIndex, UnityEngine.Object levelPrefab)
        {
            var level = levelPrefab as GameObject;
            currentLevelTuple.name = levelFullName;

            var isLevelExist = diContainer.InstantiatePrefab(level, Vector3.zero, Quaternion.identity, transform)
                                          .TryGetComponent(out Level levelComponent);

            if (isLevelExist)
            {
                currentLevelTuple.level = levelComponent;
                currentLevelTuple.level.Setup(levelIndex);
            }
            else
            {
                Debug.LogError($"{nameof(currentLevelTuple)}.{nameof(currentLevelTuple.level)} - is Null");
            }

            currentLevelTuple.index = levelIndex;
        }

        public void TryReleaseAndDestroyCurrentLevel()
        {
            if (currentLevelTuple.level == null)
            {
                return;
            }

            addressableLoader.ReleaseAsset(currentLevelTuple.name, () =>
            {
                Destroy(currentLevelTuple.level.gameObject);
            });
        }
    }
}

