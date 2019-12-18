using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EventSystemPlus
{
	[CustomEditor(typeof(DebugEventManager))]
	public class EditorEventManager : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUILayout.LabelField("UI Events:");

			for (int i = 0; i < Enum.GetNames(typeof(ButtonEvent)).Length; i++)
			{
				if (GUILayout.Button(((ButtonEvent)i).ToString()))
				{
					EventManager.TriggerEvent(((ButtonEvent)i));
				}
			}

			EditorGUILayout.LabelField("Toggle Events:");

			for (int i = 0; i < Enum.GetNames(typeof(ToggleEvents)).Length; i++)
			{
				if (GUILayout.Button(((ToggleEvents)i).ToString()))
				{
					EventManager.TriggerEvent(((ToggleEvents)i));
				}
			}

			EditorGUILayout.LabelField("App Events:");

			for (int i = 0; i < Enum.GetNames(typeof(AppEvent)).Length; i++)
			{
				if (GUILayout.Button(((AppEvent)i).ToString()))
				{
					EventManager.TriggerEvent(((AppEvent)i));
				}
			}
		}
	}
}