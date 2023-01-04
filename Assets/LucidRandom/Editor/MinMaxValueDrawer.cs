using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AnnulusGames.LucidTools.RandomKit
{
    internal class MinMaxValueDrawer : PropertyDrawer
    {
        protected readonly GUIContent emptyLabel = new GUIContent(string.Empty);
        protected const string MIN_NAME = "minValue";
        protected const string MAX_NAME = "maxValue";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty minProperty = property.FindPropertyRelative(MIN_NAME);
            SerializedProperty maxProperty = property.FindPropertyRelative(MAX_NAME);

            Rect rect = EditorGUI.PrefixLabel(position, label);
            rect.width *= 0.5f;

            EditorGUI.PropertyField(rect, minProperty, emptyLabel);
            rect.x += rect.width;
            EditorGUI.PropertyField(rect, maxProperty, emptyLabel);

            EditorGUI.EndProperty();
        }
    }

    internal class MinMaxVectorDrawer : MinMaxValueDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty minProperty = property.FindPropertyRelative(MIN_NAME);
            SerializedProperty maxProperty = property.FindPropertyRelative(MAX_NAME);

            Rect rect = EditorGUI.PrefixLabel(position, label);

            EditorGUI.PropertyField(rect, minProperty, emptyLabel);
            rect.y += EditorGUI.GetPropertyHeight(minProperty);
            EditorGUI.PropertyField(rect, maxProperty, emptyLabel);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative(MIN_NAME)) +
                EditorGUI.GetPropertyHeight(property.FindPropertyRelative(MAX_NAME));
        }
    }

    [CustomPropertyDrawer(typeof(MinMaxInt))]
    internal class MinMaxIntDrawer : MinMaxValueDrawer { }

    [CustomPropertyDrawer(typeof(MinMaxFloat))]
    internal class MinMaxFloatDrawer : MinMaxValueDrawer { }

    [CustomPropertyDrawer(typeof(MinMaxVector2))]
    internal class MinMaxVector2Drawer : MinMaxVectorDrawer { }

    [CustomPropertyDrawer(typeof(MinMaxVector2Int))]
    internal class MinMaxVector2IntDrawer : MinMaxVectorDrawer { }

    [CustomPropertyDrawer(typeof(MinMaxVector3))]
    internal class MinMaxVector3Drawer : MinMaxVectorDrawer { }

    [CustomPropertyDrawer(typeof(MinMaxVector3Int))]
    internal class MinMaxVector3IntDrawer : MinMaxVectorDrawer { }
}
