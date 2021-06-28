using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNameInHighScore : MonoBehaviour
{
	private TMP_InputField inputField;
	
	private void Awake()
	{
		inputField = FindObjectOfType<TMP_InputField>();
	}

	public void SetPlayerNameInHighscore()
	{
		HighScoreSystem.Instance.UpdateHighscoreOrdered(ScoreSystem.Instance.score, ScoreSystem.Instance.misses, inputField.text);
	}
}
