using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Player
{
    public class PlayerActivator : MonoBehaviour
    {
        [field: SerializeField, ReadOnly] public bool IsPlayerActive { get; private set; }

        public void Activate()
        {
            IsPlayerActive = true;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            IsPlayerActive = false;
            gameObject.SetActive(false);
        }
    }
}
