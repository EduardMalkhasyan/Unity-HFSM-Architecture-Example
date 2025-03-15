using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Player
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Collider selfCollider;
        [ShowInInspector] public bool CanCollide => selfCollider.enabled;

        public void EnableCollider()
        {
            selfCollider.enabled = true;
        }

        public void DisableCollider()
        {
            selfCollider.enabled = false;
        }
    }
}
