using UnityEngine;
using UnityEditor;

namespace Project.Tools.AttributeHelp
{
    [CustomPropertyDrawer(typeof(MinMaxAttribute))]
    public class MinMaxDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            MinMaxAttribute minMax = attribute as MinMaxAttribute;

            position = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            Color originalGUIColor = GUI.backgroundColor;

            if (property.propertyType == SerializedPropertyType.Vector2)
            {
                float minValue = property.vector2Value.x;
                float maxValue = property.vector2Value.y;
                float minLimit = minMax.MinLimit;
                float maxLimit = minMax.MaxLimit;

                EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);

                GUI.backgroundColor = new Color(0.68f, 0.7f, 0.71f, 1f);

                var vec = Vector2.zero;
                vec.x = minValue;
                vec.y = maxValue;

                property.vector2Value = vec;

                position.y += EditorGUIUtility.singleLineHeight;
                position.x += 10f;

                float[] vals = new float[] { minValue, maxValue };
                EditorGUI.MultiFloatField(position, new GUIContent("Range"), new GUIContent[] { new GUIContent("MinVal:  "), new GUIContent("MaxVal:  ") }, vals);

                if (minMax.DrawRangeValue)
                {
                    GUI.enabled = false;
                    position.y += (EditorGUIUtility.singleLineHeight + 2f);

                    EditorGUI.FloatField(position, "Selected Range", (float)System.Math.Round(maxValue - minValue, 3));
                    GUI.enabled = true;
                }

                property.vector2Value = new Vector2(vals[0], vals[1]);
            }
            else if (property.propertyType == SerializedPropertyType.Vector2Int)
            {
                float minValue = property.vector2IntValue.x;
                float maxValue = property.vector2IntValue.y;
                int minLimit = Mathf.RoundToInt(minMax.MinLimit);
                int maxLimit = Mathf.RoundToInt(minMax.MaxLimit);

                EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);

                GUI.backgroundColor = new Color(0.68f, 0.7f, 0.71f, 1f);

                var vec = Vector2Int.zero;
                vec.x = Mathf.RoundToInt(minValue);
                vec.y = Mathf.RoundToInt(maxValue);

                property.vector2IntValue = vec;

                position.y += EditorGUIUtility.singleLineHeight;
                position.x += 10f;

                float[] vals = new float[] { minValue, maxValue };
                EditorGUI.MultiFloatField(position, new GUIContent("Range"), new GUIContent[] { new GUIContent("Min Value: "), new GUIContent("Max Value: ") }, vals);

                if (minMax.DrawRangeValue)
                {
                    GUI.enabled = false;
                    position.y += (EditorGUIUtility.singleLineHeight + 2f);

                    EditorGUI.FloatField(position, "Selected Range", maxValue - minValue);
                    GUI.enabled = true;
                }

                property.vector2IntValue = new Vector2Int(Mathf.RoundToInt(vals[0]), Mathf.RoundToInt(vals[1]));
            }

            GUI.backgroundColor = originalGUIColor;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            MinMaxAttribute minMax = attribute as MinMaxAttribute;
            float size = EditorGUIUtility.singleLineHeight;
            size += EditorGUIUtility.singleLineHeight * (minMax.DrawRangeValue ? 2 : 1);
            return size;
        }
    }
}