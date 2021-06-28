using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExcitementBar : MonoBehaviour
{
    private Slider slider;
	private Action emptyMeterCallback;
	private bool hasBeenCalled = false;
	private float decayRate = 0.8f;
	private float maxExcitement = 1000f;
	private bool isPaused = true;

	private void Awake()
	{
		hasBeenCalled = false;
		slider = GetComponent<Slider>();
	}

	private void Start()
	{
		slider.maxValue = maxExcitement;
		RefillMeter();
	}

	// Update is called once per frame
	void LateUpdate()
    {
		if (slider.value > slider.minValue && !isPaused)
			slider.value -= decayRate;
		else if(slider.value <= 0 && !hasBeenCalled)
			emptyMeterCallback();
    }

	#region public functions
	public void SetDecayRate(float amount) => decayRate = amount;
	public void RefillMeter()
	{
		slider.value = maxExcitement;
		hasBeenCalled = false; 
	}
	public void FillMeter(float amount) => slider.value += amount;
	/// <summary>
	/// adds function to action for callback when meter is empty
	/// </summary>
	/// <param name="callback"></param>
	public void OnMeterEmpty(Action callback)
	{
		emptyMeterCallback += callback;
		hasBeenCalled = true;
	}
	/// <summary>
	///  set the max value of the excitement meter based on amount
	/// </summary>
	/// <param name="amount"></param>
	public void SetMaxExcitement(float amount)
	{
		maxExcitement = amount;
		slider.maxValue = maxExcitement;
	}
	/// <summary>
	/// set the max value of the excitement meter and wether or not meter should be refilled
	/// </summary>
	/// <param name="amount"></param>
	/// <param name="refresh"></param>
	public void SetMaxExcitement(float amount, bool refresh)
	{
		maxExcitement = amount;
		slider.maxValue = maxExcitement;
		RefillMeter();
	}
	public void IsPaused(bool choice) => isPaused = choice;

	#endregion
}
