using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AnnulusGames.LucidTools.RandomKit
{
    [CustomPropertyDrawer(typeof(WeightedList<>))]
    internal class WeightedListDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property.FindPropertyRelative("list"), label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("list"));
        }
    }
}
