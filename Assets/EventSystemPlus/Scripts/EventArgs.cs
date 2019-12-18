using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace EventSystemPlus
{
	//Contains class inherited from EventArgs for triggering with events
	//eg using to pass 		PassString newPassString = new PassString("Pass");
	//eg usage to read 		string value = obj.GetObject<string>();
	public class PassObject : EventArgs
	{
		protected object _passedObject;

		public PassObject(object i_object)
		{
			_passedObject = i_object;
		}

		public T GetObject<T>()
		{
			if (typeof(T) != _passedObject.GetType())
			{
				Debug.LogError("Passed Type doesn't match recieved type");
				return default(T);
			}
			return (T)_passedObject;
		}
	}
}


