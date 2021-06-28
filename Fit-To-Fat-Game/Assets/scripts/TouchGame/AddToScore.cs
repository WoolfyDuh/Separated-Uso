using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToScore : MonoBehaviour
{
	DeactivateBall deactivateBall;
	[SerializeField] private float amountOfScoreToAdd = 1f;
	private void Awake()
	{
		deactivateBall = gameObject.GetComponent<DeactivateBall>();
		deactivateBall.AddToDisableCallback(AddMisses);
	}
	public void AddScore()
	{
		ScoreSystem.Instance.AddScore(amountOfScoreToAdd);
	}
	
	public void AddMisses()
	{
		ScoreSystem.Instance.AddMisses(1f);
	}
}
