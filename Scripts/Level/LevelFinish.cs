using Project.Player;
using Project.Player.Observer;
using UnityEngine;

namespace Project.InLevel
{
    public class LevelFinish : MonoBehaviour
    {
        [SerializeField] private Collider selfCollider;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerCollisions player))
            {
                selfCollider.enabled = false;
                PlayerObserver.InvokeOnLevelFinish();
            }
        }
    }
}
