using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Project.Debugger
{
    public class FPSEditor : MonoBehaviour
    {
        [Button]
        public void ChangeFPS(int count = 60)
        {
            StartCoroutine(SetFPSCor(count));
        }

        private IEnumerator SetFPSCor(int count)
        {
            yield return new WaitForSeconds(0.2f);
            Application.targetFrameRate = count;
        }
    }
}


