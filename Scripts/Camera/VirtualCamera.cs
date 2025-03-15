using Cinemachine;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using System;
using System.Threading;
using UnityEngine;
using Project.Tools.DictionaryHelp;

namespace Project.Camera
{
    public class VirtualCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineBrain cinemachineBrain;
        [SerializeField] private SerializableDictionary<VirtualCameraType, CinemachineVirtualCamera> virtualCameras;
        [SerializeField, ReadOnly] private CinemachineVirtualCamera CurrentVirtualCamera;
        private CancellationTokenSource cancellationTokenSource;

        [Button]
        public void SwitchCamera(VirtualCameraType virtualCameraType)
        {
            foreach (var camera in virtualCameras)
            {
                camera.Value.gameObject.SetActive(false);
            }

            CurrentVirtualCamera = virtualCameras[virtualCameraType];
            CurrentVirtualCamera.gameObject.SetActive(true);
        }

        public async void SwitchCamera(VirtualCameraType virtualCameraType, Action OnComplete = null)
        {
            SwitchCamera(virtualCameraType);

            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await UniTask.WaitForSeconds(cinemachineBrain.m_DefaultBlend.m_Time,
                                             cancellationToken: cancellationTokenSource.Token);
                OnComplete?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }
        }

        [Button]
        public void SwitchCameraAndSetFollow(VirtualCameraType virtualCameraType, Transform followTransform)
        {
            SwitchCamera(virtualCameraType);
            SetCurrentCameraFollow(followTransform);
        }

        public void CloseAllVirtualCameras()
        {
            foreach (var camera in virtualCameras)
            {
                camera.Value.gameObject.SetActive(false);
            }
        }

        public void ResetMainCameraTransform()
        {
            var cameraTransform = UnityEngine.Camera.main.transform;

            cameraTransform.localPosition = Vector3.zero;
            cameraTransform.localRotation = Quaternion.identity;
        }

        public void SetCurrentCameraFollow(Transform followTransform)
        {
            CurrentVirtualCamera.Follow = followTransform;
        }
    }
}
