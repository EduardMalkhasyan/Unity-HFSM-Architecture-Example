using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Project.ExtensionMethod
{
    public static class GameObjectExtensions
    {
        public static async UniTask SetActiveAsync(this GameObject gameObject, bool active, float delay)
        {
            await UniTask.Delay(Mathf.FloorToInt(delay * 1000));
            gameObject.SetActive(active);
        }

        public static IEnumerator SetActiveCoroutine(this GameObject gameObject, bool active, float delay)
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(active);
        }

        public static void OnceCallParticleEffectAfterDisableGameObject(this MonoBehaviour monoBehaviour,
                                                                        params ParticleSystem[] effects)
        {
            foreach (var effect in effects)
            {
                monoBehaviour.StartCoroutine(OnceCallParticleEffectAfterDisableGameObjectCor(effect));
            }
        }

        public static void OnceCallParticleEffectAfterDisableGameObject(this MonoBehaviour monoBehaviour, Action OnFinish,
                                                                        params ParticleSystem[] effects)
        {
            foreach (var effect in effects)
            {
                monoBehaviour.StartCoroutine(OnceCallParticleEffectAfterDisableGameObjectCor(effect, OnFinish));
            }
        }

        public static void OnceCallParticleEffect(this MonoBehaviour monoBehaviour,
                                                  params ParticleSystem[] effects)
        {
            foreach (var effect in effects)
            {
                monoBehaviour.StartCoroutine(OnceCallParticleEffectAfterStopEffectCor(effect));
            }
        }

        public static void OnceCallParticleEffect(this MonoBehaviour monoBehaviour, Action OnFinish,
                                                  params ParticleSystem[] effects)
        {
            foreach (var effect in effects)
            {
                monoBehaviour.StartCoroutine(OnceCallParticleEffectAfterStopEffectCor(effect, OnFinish));
            }
        }

        private static IEnumerator OnceCallParticleEffectAfterDisableGameObjectCor(ParticleSystem effect, Action OnFinish = null)
        {
            effect.gameObject.SetActive(true);
            effect.Play();
            yield return new WaitUntil(() => effect.isPlaying == false);
            OnFinish?.Invoke();
            effect.gameObject.SetActive(false);
        }

        private static IEnumerator OnceCallParticleEffectAfterStopEffectCor(ParticleSystem effect, Action OnFinish = null)
        {
            effect.Play();
            yield return new WaitUntil(() => effect.isPlaying == false);
            OnFinish?.Invoke();
            effect.Stop();
        }

        public static void FindGameObjectAndSetActiveFalse(params GameObject[] objects)
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }

        public static T[] GetComponentsInChildrenWithoutParent<T>(this Transform parent, bool includeInactive = false) where T : Component
        {
            return parent.GetComponentsInChildren<T>(includeInactive).Where(component => component.transform != parent).ToArray();
        }
    }
}
