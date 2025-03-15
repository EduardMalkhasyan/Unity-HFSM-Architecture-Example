using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Tools.Help
{
    public static class ObjectPool
    {
        private static Dictionary<string, List<GameObject>> objectPools = new();

        public static IReadOnlyDictionary<string, IReadOnlyList<GameObject>> GetObjectPools
        {
            get
            {
                var readOnlyObjectPools = new Dictionary<string, IReadOnlyList<GameObject>>();

                foreach (var kvp in objectPools)
                {
                    if (kvp.Value.Count == 0)
                    {
                        Debug.LogWarning($"Pool '{kvp.Key}' is empty");
                    }
                    else
                    {
                        readOnlyObjectPools[kvp.Key] = kvp.Value.AsReadOnly();
                    }
                }

                if (objectPools.Count == 0)
                {
                    Debug.LogWarning("No object pools available");
                }

                return readOnlyObjectPools;
            }
        }

        public static void TryClearAndDestroyPool(string key)
        {
            if (objectPools.ContainsKey(key))
            {
                if (objectPools[key].Count > 0)
                {
                    foreach (var item in objectPools[key])
                    {
                        if (item != null)
                        {
                            GameObject.Destroy(item);
                        }
                    }

                    objectPools[key].Clear();
                    objectPools.Remove(key);

                    Debug.Log($"Pool of name {key} cleaned and destroyed");
                }
            }
        }

        public static void TryClearAndDestroyAllPools()
        {
            foreach (var gameObjectList in objectPools.Values)
            {
                foreach (var gameObject in gameObjectList)
                {
                    GameObject.Destroy(gameObject);
                }
            }

            objectPools.Clear();

            Debug.Log($"All pools cleaned and destroyed");
        }

        public static void InitializeObjectPool(string poolKey, GameObject prefab,
                                                Transform parent, int poolSize,
                                                Action<GameObject> OnObjectCreation = null)
        {
            if (!objectPools.ContainsKey(poolKey))
                objectPools[poolKey] = new List<GameObject>();

            List<GameObject> currentPool = objectPools[poolKey];

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = UnityEngine.Object.Instantiate(prefab);
                obj.name = obj.name + $"_{i}";
                obj.SetActive(false);

                if (parent != null)
                {
                    obj.transform.SetParent(parent);
                }

                currentPool.Add(obj);
                OnObjectCreation?.Invoke(obj);
            }
        }

        public static GameObject GetObjectFromPool(string poolKey)
        {
            if (objectPools.ContainsKey(poolKey))
            {
                List<GameObject> currentPool = objectPools[poolKey];

                foreach (GameObject obj in currentPool)
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.SetActive(true);
                        return obj;
                    }
                }

                Debug.LogWarning($"Pool '{poolKey}' is full");
            }
            else
            {
                Debug.LogError($"Pool '{poolKey}' does not exist");
            }

            return null;
        }

        public static GameObject GetObjectFromPool(string poolKey, Vector3 position, Quaternion rotation)
        {
            if (objectPools.ContainsKey(poolKey))
            {
                List<GameObject> currentPool = objectPools[poolKey];

                foreach (GameObject obj in currentPool)
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.transform.position = position;
                        obj.transform.rotation = rotation;
                        obj.SetActive(true);
                        return obj;
                    }
                }

                Debug.LogWarning($"Pool '{poolKey}' is full");
            }
            else
            {
                Debug.LogError($"Pool '{poolKey}' does not exist");
            }

            return null;
        }

        public static bool TryGetObjectFromPool(string poolKey, out GameObject gameObject)
        {
            if (objectPools.ContainsKey(poolKey))
            {
                List<GameObject> currentPool = objectPools[poolKey];

                foreach (GameObject obj in currentPool)
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.SetActive(true);
                        gameObject = obj;
                        return true;
                    }
                }

                Debug.LogWarning($"Pool '{poolKey}' is full");
                gameObject = null;
                return false;
            }
            else
            {
                Debug.LogError($"Pool '{poolKey}' does not exist");
                gameObject = null;
                return false;
            }
        }

        public static bool TryGetObjectFromPool(string poolKey, Vector3 position,
                                                Quaternion rotation, out GameObject gameObject)
        {
            if (objectPools.ContainsKey(poolKey))
            {
                List<GameObject> currentPool = objectPools[poolKey];

                foreach (GameObject obj in currentPool)
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.transform.position = position;
                        obj.transform.rotation = rotation;
                        obj.SetActive(true);
                        gameObject = obj;
                        return true;
                    }
                }

                Debug.LogWarning($"Pool '{poolKey}' is full");
                gameObject = null;
                return false;
            }
            else
            {
                Debug.LogError($"Pool '{poolKey}' does not exist");
                gameObject = null;
                return false;
            }
        }
    }
}
