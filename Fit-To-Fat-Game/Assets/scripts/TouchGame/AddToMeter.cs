using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddToMeter : MonoBehaviour
{
	ExcitementBar bar;
	[SerializeField] [Range(10, 100f)] private float amountToFill = 10;
	private void Awake()
	{
		bar = GameObject.FindObjectOfType<ExcitementBar>();
	}
	//do the thing to the meter 
 	public void ClickToFillMeter()
	{
		bar.FillMeter(amountToFill);
	}
}
