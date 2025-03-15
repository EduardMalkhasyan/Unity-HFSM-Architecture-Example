using Project.Settings;
using Project.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Project.Main
{
    public class InitialSceneLoader : MonoBehaviour
    {
        [SerializeField] private WaitLoadingSpinnerDots waitLoadingSpinnerDots;
        private float awaitTime = 1f;

        private IEnumerator Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            waitLoadingSpinnerDots.EnableLoadingScreen();
            yield return new WaitForSeconds(awaitTime);

            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(GameSettings.Value.GameSceneAddress);
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                yield return handle.Result.ActivateAsync();
            }
        }
    }
}
