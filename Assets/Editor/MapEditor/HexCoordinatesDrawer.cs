﻿using UnityEngine;

using UnityEditor;
[CustomPropertyDrawer(typeof(HexCoordinate))]
public class HexCoordinatesDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        HexCoordinate coordinates = new HexCoordinate(
            property.FindPropertyRelative("row").intValue,
            property.FindPropertyRelative("column").intValue
        );

        position = EditorGUI.PrefixLabel(position, label);
        GUI.Label(position, coordinates.ToString());
    }
}
