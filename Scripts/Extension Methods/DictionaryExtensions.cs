using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Project.ExtensionMethod
{
    public static class DictionaryExtensions
    {
        public static TKey FindKeyByValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value)
        {
            foreach (var pair in dictionary)
            {
                if (EqualityComparer<TValue>.Default.Equals(pair.Value, value))
                {
                    return pair.Key;
                }
            }
            throw new KeyNotFoundException("The given value was not found in the dictionary.");
        }
    }

}
