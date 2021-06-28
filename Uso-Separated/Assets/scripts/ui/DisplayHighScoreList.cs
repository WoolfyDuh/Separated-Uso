using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScoreList : MonoBehaviour
{
	private TextMeshProUGUI[] tmpUIChildren = new TextMeshProUGUI[10];
	private IEnumerator placeHolder;
	private void Awake()
	{
		InitList();
		placeHolder = WaitForHighScoreToLoad();
	}
	private void Start()
	{
		StopCoroutine(placeHolder);
		StartCoroutine(placeHolder);
	}

	private void InitList()
	{
		Transform child;
		for (int i = 0; i < transform.childCount; i++)
		{
			child = transform.GetChild(i);
			tmpUIChildren[i] = child.GetComponent<TextMeshProUGUI>();
		}
	}

	private void SetChildScores()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			tmpUIChildren[i].SetText("nr" + (i + 1) + ":" +
															" Name: " + HighScoreSystem.Instance.GetHighScorePlayerName(i) +
															" Score: " + HighScoreSystem.Instance.GetHighScorePlayerScore(i) +
															" Misses: " + HighScoreSystem.Instance.GetHighScorePlayerMiss(i));
		}

	}

	IEnumerator WaitForHighScoreToLoad()
	{
		if(HighScoreSystem.Instance == null)
		{
			Debug.Log("this should appear every 10 seconds");
			Invoke("placeHolder", 10f);
		}
		else
		{
			SetChildScores();
			StopCoroutine(placeHolder);
		}
		yield return null;
	}

}
