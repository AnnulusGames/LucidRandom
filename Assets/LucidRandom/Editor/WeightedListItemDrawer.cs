using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AnnulusGames.LucidTools.RandomKit
{
    [CustomPropertyDrawer(typeof(WeightedListItem<>))]
    internal class WeightedListItemDrawer : PropertyDrawer
    {
        private readonly GUIContent emptyLabel = new GUIContent(string.Empty);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty valueProperty = property.FindPropertyRelative("value");
            SerializedProperty weightProperty = property.FindPropertyRelative("weight");

            float itemWidth = position.width * 0.77f;
            float weightWidth = position.width * 0.2f;
            Rect itemFieldRect = new Rect(position.x, position.y, itemWidth, position.height);
            Rect weightFieldRect = new Rect(position.x + itemWidth + position.width * 0.03f, position.y, weightWidth, EditorGUIUtility.singleLineHeight);

            EditorGUI.PropertyField(itemFieldRect, valueProperty, label);
            EditorGUI.PropertyField(weightFieldRect, weightProperty, emptyLabel);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProperty = property.FindPropertyRelative("value");
            return EditorGUI.GetPropertyHeight(valueProperty);
        }
    }
}