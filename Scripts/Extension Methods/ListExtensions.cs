using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Project.ExtensionMethod
{
    public static class ListExtensions
    {
        public static void LogContents<T>(this List<T> list, string text = null)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Debug.Log($"{text}. List contents: {json}");
        }

        public static void LogWarningContents<T>(this List<T> list, string text = null)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Debug.LogWarning($"{text}. List contents: {json}");
        }

        public static void LogErrorContents<T>(this List<T> list, string text = null)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Debug.LogError($"{text}. List contents: {json}");
        }

        public static List<Transform> GetAllChildrenExcludingParent(this Transform parent)
        {
            List<Transform> children = new List<Transform>();

            for (int i = 0; i < parent.childCount; i++)
            {
                children.Add(parent.GetChild(i));
            }

            return children;
        }

        public static bool TryAdd<T>(this List<T> list, T item)
        {
            if (list.Contains(item) == false)
            {
                list.Add(item);
                return true;
            }
            return false;
        }
    }
}
