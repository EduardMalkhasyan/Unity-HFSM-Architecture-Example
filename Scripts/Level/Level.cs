using Project.Tools.Help;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.InLevel
{
    public class Level : MonoBehaviour
    {
        [SerializeField, ReadOnly] private int index;

        public void Setup(int index)
        {
            this.index = index;
        }

        private void OnDestroy()
        {
            CancellationTokenPool.KillPoolInLevelTokens();
        }
    }
}
