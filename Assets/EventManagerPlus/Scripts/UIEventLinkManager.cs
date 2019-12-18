using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace EventSystemPlus
{
	//Triggers
	[Serializable]
	public struct ButtonPair
	{
		public Button button;
		public ButtonEvent @event;
	}

	[Serializable]
	public struct InputFieldPair
	{
		public InputField inputField;
		public InputEvents @event;
	}

	[Serializable]
	public struct TogglePair
	{
		public Toggle toggle;
		public ToggleEvents @event;
	}

	[Serializable]
	public struct SliderPair
	{
		public Slider slider;
		public SliderEvents @event;
	}

	[Serializable]
	public struct DropDownPair
	{
		public Dropdown dropdown;
		public DropDownEvents @event;
	}

	//Listeners
	[Serializable]
	public class TextUpdatePair
	{
		public Text text;
		public UIValueUpdateEvents @event;
		public void eventTrigger(PassObject obj)
		{
			text.text = obj.GetObject<String>();
		}
	}

	[Serializable]
	public class TextColorUpdatePair
	{
		public Text text;
		public UIValueUpdateEvents @event;
		public void eventTrigger(PassObject obj)
		{
			text.color = obj.GetObject<Color>();
		}
	}

	[Serializable]
	public class InputFieldUpdatePair
	{
		public InputField input;
		public UIValueUpdateEvents @event;
		public void eventTrigger(PassObject obj)
		{
			input.text = obj.GetObject<String>();
		}
	}

	[Serializable]
	public class ProgressBarUpdatePair
	{
		public Image progressBar;
		public Text progressText;
		public void eventTrigger(PassObject obj)
		{
			progressText.text = $"{Mathf.RoundToInt(obj.GetObject<float>())}%";
			progressBar.fillAmount = obj.GetObject<float>();
		}
	}

	public class UIEventLinkManager : MonoBehaviour
	{
		[Header("Triggers")]
		[SerializeField] private ButtonPair[] buttonPairs;
		[SerializeField] private InputFieldPair[] inputFieldPairs;
		[SerializeField] private TogglePair[] togglePairs;
		[SerializeField] private SliderPair[] sliderPairs;
		[SerializeField] private DropDownPair[] dropDownPairs;

		[Header("Listeners")]
		[SerializeField] private TextUpdatePair[] textUpdatePairs;
		[SerializeField] private TextColorUpdatePair[] textColorUpdatePairs;
		[SerializeField] private InputFieldUpdatePair[] InputFieldUpdatePairs;

		private void Start()
		{
			foreach (ButtonPair pair in buttonPairs) pair.button.onClick.AddListener(delegate { EventManager.TriggerEvent(pair.@event); });
			foreach (InputFieldPair pair in inputFieldPairs) pair.inputField.onValueChanged.AddListener(delegate { EventManager.TriggerEvent(pair.@event, new PassObject(pair.inputField)); });
			foreach (TogglePair pair in togglePairs) pair.toggle.onValueChanged.AddListener(delegate { EventManager.TriggerEvent(pair.@event, new PassObject(pair.toggle.isOn)); });
			foreach (SliderPair pair in sliderPairs) pair.slider.onValueChanged.AddListener(delegate { EventManager.TriggerEvent(pair.@event, new PassObject(pair.slider.value)); });
			foreach (DropDownPair pair in dropDownPairs) pair.dropdown.onValueChanged.AddListener(delegate { EventManager.TriggerEvent(pair.@event, new PassObject(pair.dropdown.value)); });

			foreach (TextUpdatePair pair in textUpdatePairs) EventManager.StartListening(pair.@event, pair.eventTrigger);
			foreach (TextColorUpdatePair pair in textColorUpdatePairs) EventManager.StartListening(pair.@event, pair.eventTrigger);
			foreach (InputFieldUpdatePair pair in InputFieldUpdatePairs) EventManager.StartListening(pair.@event, pair.eventTrigger);
		}

		private void OnDestroy()
		{
			foreach (TextUpdatePair pair in textUpdatePairs) EventManager.StopListening(pair.@event, pair.eventTrigger);
			foreach (TextColorUpdatePair pair in textColorUpdatePairs) EventManager.StopListening(pair.@event, pair.eventTrigger);
			foreach (InputFieldUpdatePair pair in InputFieldUpdatePairs) EventManager.StopListening(pair.@event, pair.eventTrigger);
		}
	}
}
