using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystemPlus;
using System;
using UnityEngine.UI;

public class SampleUsage : MonoBehaviour
{
    private void Start()
    {
		//Listen To Button Event
		EventManager.StartListening(ButtonEvent.OnClickTestButton, OnClickTestButton);
		//Listen To TextInput
		EventManager.StartListening(InputEvents.OnInputFieldChanged, OnInputFieldChanged);
		//Listen To Slider
		EventManager.StartListening(SliderEvents.OnSliderChanged, OnSliderChanged);
		//Listen To Dropdown
		EventManager.StartListening(DropDownEvents.OnDropDownValueChanged, OnDropDownValueChanged);
		//Listen To Toggle
		EventManager.StartListening(ToggleEvents.OnToggleChanged, OnToggleChanged);
	}

	private void OnInputFieldChanged(PassObject obj)
	{
		InputField value = obj.GetObject<InputField>();
		Debug.Log($"Updated Text: {value.text}");
	}

	private void OnClickTestButton(PassObject obj)
	{
		Debug.Log("OnClickTestButton");
	}

	private void OnToggleChanged(PassObject obj)
	{
		bool value = obj.GetObject<bool>();
		Debug.Log($"Toggle Value: {value}");
	}

	private void OnDropDownValueChanged(PassObject obj)
	{
		int value = obj.GetObject<int>();
		Debug.Log($"DropDown Value: {value}");
	}

	private void OnSliderChanged(PassObject obj)
	{
		float value = obj.GetObject<float>();
		string sliderValue = $"Slider Value: {value}";
		EventManager.TriggerEvent(UIValueUpdateEvents.OnUpdateSliderText, new PassObject(sliderValue));
	}
}
