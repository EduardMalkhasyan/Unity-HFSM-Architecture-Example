using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Player
{
    public class PlayerPositionSetter : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [field: SerializeField, ReadOnly] public Vector3 InitialPosition { get; private set; }

        public void StoreInitialPosition()
        {
            InitialPosition = playerTransform.localPosition;
        }

        public void TransferPlayerToInitialPosition()
        {
            TransferPlayerToPosition(InitialPosition);
        }

        public void TransferPlayerToPosition(Vector3 position)
        {
            playerTransform.localPosition = position;
        }
    }
}
