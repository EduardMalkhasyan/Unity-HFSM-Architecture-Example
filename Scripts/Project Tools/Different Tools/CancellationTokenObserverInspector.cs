using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Tools.Help
{
    public class CancellationTokenObserverInspector : MonoBehaviour
    {
        [ShowInInspector] private int InLevelPoolCount => ShowPoolCount(CancellationTokenPoolType.InLevel);
        [ShowInInspector] private int InScenePoolCount => ShowPoolCount(CancellationTokenPoolType.InScene);

        private int ShowPoolCount(CancellationTokenPoolType cancellationTokenPoolType)
        {
            return CancellationTokenPool.PoolCount(cancellationTokenPoolType);
        }

        [Button]
        private void KillPoolTokens(CancellationTokenPoolType cancellationTokenPoolType)
        {
            CancellationTokenPool.KillPoolTokens(cancellationTokenPoolType);
        }
    }
}
