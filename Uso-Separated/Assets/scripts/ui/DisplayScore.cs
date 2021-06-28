using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayScore : MonoBehaviour
{
	TextMeshProUGUI tmpUI;
	[SerializeField] float time = 0.1f;
	private void Awake()
	{
		tmpUI = gameObject.GetComponent<TextMeshProUGUI>();
	}
	private void Update()
	{
		Invoke("UpdateScoreDisplay", time);
	}

	void UpdateScoreDisplay()
	{
		tmpUI.SetText(
			"Score: " + ScoreSystem.Instance.score +
			"\n Misses: " + ScoreSystem.Instance.misses
			 ) ;
	}
}
