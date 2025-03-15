using UnityEngine;

namespace Project.Debugger
{
    public class ExternalDebugObject : MonoBehaviour
    {
        private void Awake()
        {
#if !PROJECT_DEBUGGER
            gameObject.SetActive(false);
#endif
        }
    }
}
