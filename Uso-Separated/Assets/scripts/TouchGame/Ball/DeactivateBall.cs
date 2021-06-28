using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBall : MonoBehaviour
{
	[SerializeField] private float timeToDisappear = 3;
	bool hasRun = false;
	Action OnBallDisable;
	private void Update()
	{
		if (gameObject.activeSelf && !hasRun)
		{
			StartCoroutine(TimeToDeactivate(timeToDisappear));
			hasRun = true;
		}
	}
	 void ReturnToPool()
	{
		StopCoroutine(TimeToDeactivate(timeToDisappear));
		gameObject.transform.SetParent(null);
		hasRun = false;
		gameObject.SetActive(false);
	}
	public void AddToDisableCallback(Action callback) => OnBallDisable += callback;
	IEnumerator TimeToDeactivate(float time)
	{
		yield return new WaitForSeconds(time);
		OnBallDisable();
		ReturnToPool();
	}
}
