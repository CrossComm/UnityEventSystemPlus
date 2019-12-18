using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystemPlus
{
	public static class EventManager
	{
		private static Dictionary<string, Action<PassObject>> eventDictionary;

		private static void Init()
		{
			if (eventDictionary == null)
			{
				eventDictionary = new Dictionary<string, Action<PassObject>>();
			}
		}

		public static void StartListening<T>(T i_eventName, Action<PassObject> i_listener)
		{
			Init();
			Type t = i_eventName.GetType();
			if (t.IsEnum)
			{
				//Debug.Log($"<color=blue>Listening: {i_eventName}</color>");
				Action<PassObject> thisEvent = null;
				if (eventDictionary.TryGetValue(i_eventName.ToString(), out thisEvent))
				{
					thisEvent += i_listener;
					eventDictionary[i_eventName.ToString()] = thisEvent;
				}
				else
				{
					thisEvent += i_listener;
					eventDictionary.Add(i_eventName.ToString(), thisEvent);
				}
			}
			else
			{
				Debug.LogError($"{i_eventName} is not an enum Type");
			}
		}
		public static void TriggerEvent<T>(T i_eventName, PassObject i_passObject = null)
		{
			Type t = i_eventName.GetType();
			if (t.IsEnum)
			{
				//Debug.Log($"<color=green>Triggered: {i_eventName}</color>");
				Action<PassObject> thisEvent = null;
				if (eventDictionary.TryGetValue(i_eventName.ToString(), out thisEvent) && thisEvent != null)
				{
					thisEvent(i_passObject);
				}
			}
			else
			{
				Debug.LogError($"{i_eventName.ToString()} is not an enum Type");
			}
		}

		public static void StopListening<T>(T i_eventName, Action<PassObject> i_listener)
		{
			Type t = i_eventName.GetType();
			if (t.IsEnum)
			{
				Action<PassObject> thisEvent = null;
				if (eventDictionary.TryGetValue(i_eventName.ToString(), out thisEvent))
				{
					thisEvent -= i_listener;
				}
				else
				{
					Debug.LogError($"{i_eventName.ToString()} doesn't exist in Event Dictionary");
				}
			}
			else
			{
				Debug.LogError($"{i_eventName} is not an enum Type");
			}
		}
	}
}
