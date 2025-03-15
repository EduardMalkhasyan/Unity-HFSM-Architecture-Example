using System;
using UnityEngine;

namespace Project.ExtensionMethod
{
    public static class EnumExtensions
    {
        public static T GetNextEnumValue<T>(this T currentValue) where T : System.Enum
        {
            T[] values = (T[])System.Enum.GetValues(typeof(T));
            int currentIndex = System.Array.IndexOf(values, currentValue);
            int nextIndex = (currentIndex + 1) % values.Length;
            return values[nextIndex];
        }

        public static T GetPreviousEnumValue<T>(this T currentValue) where T : System.Enum
        {
            T[] values = (T[])System.Enum.GetValues(typeof(T));
            int currentIndex = System.Array.IndexOf(values, currentValue);
            int previousIndex = (currentIndex - 1 + values.Length) % values.Length;
            return values[previousIndex];
        }

        public static string GetName(this Enum enumValue)
        {
            return Enum.GetName(enumValue.GetType(), enumValue);
        }
    }
}


