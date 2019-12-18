using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EventSystemPlus
{
	[CustomPropertyDrawer(typeof(InputFieldUpdatePair))]
	public class InputFieldUpdatePairDrawer : PropertyDrawer
	{
		// Draw the property inside the given rect
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Using BeginProperty / EndProperty on the parent property means that
			// prefab override logic works on the entire property.
			EditorGUI.BeginProperty(position, label, property);

			// Draw label
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), GUIContent.none);

			// Don't make child fields be indented
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			// Calculate rects
			var uiRect = new Rect(position.x, position.y, 200, position.height);
			var eventNameRect = new Rect(position.x + 210, position.y, 200, position.height);

			// Draw fields - passs GUIContent.none to each so they are drawn without labels
			EditorGUI.PropertyField(uiRect, property.FindPropertyRelative("input"), GUIContent.none);
			EditorGUI.PropertyField(eventNameRect, property.FindPropertyRelative("event"), GUIContent.none);

			// Set indent back to what it was
			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}
	}
}
