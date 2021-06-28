using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreSystem :	MonoBehaviour
{
	private string url; 
	public static HighScoreSystem Instance { get; private set; }
	[SerializeField] private HighScoreData highScoreData = new HighScoreData();

 void Awake()
	{
		url = Application.persistentDataPath + "UsoHighscores.json";

		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(this.gameObject);
}
	private void Start()
	{
		if (!File.Exists(url))
			InitHighscoreJSON();
		else
			LoadFromLocalFile(url);
	}

	private void InitHighscoreJSON()
	{
		string dataToBeSaved;
		for (int i = 0; i < 10; i++)
		{
			highScoreData.PlayerList.Add(new HighScoreData.Player("Your Name!", 1.0f, 9999.0f));
			Debug.Log(highScoreData.PlayerList[i]);
		}
		dataToBeSaved = JsonUtility.ToJson(highScoreData, true);
		SaveToLocalFile(url, dataToBeSaved);
		Debug.Log("initializing save");
	}
	public void UpdateHighscoreOrdered(float score, float missCount, string name)
	{
		HighScoreData.Player previousPlayerValues;
		string dataToBeSaved;
		bool hasInserted = false;

		HighScoreData.Player newEntry = new HighScoreData.Player(name, score, missCount);

		for (int i = 0; i < 10; i++)
				{
			
					if (newEntry.PlayerValue.Score  > highScoreData.PlayerList[i].PlayerValue.Score && !hasInserted )
					{
		
					previousPlayerValues = highScoreData.PlayerList[i];
					highScoreData.PlayerList[i] = newEntry;
					hasInserted = true;

					UpdateHighscoreOrdered(previousPlayerValues.PlayerValue.Score, previousPlayerValues.PlayerValue.MissCount, previousPlayerValues.Name);
					}
					else
					{
						continue;
					}		
				}

		dataToBeSaved = JsonUtility.ToJson(highScoreData, true);
		SaveToLocalFile(url, dataToBeSaved);
		LoadFromLocalFile(url);
	}

	public string GetHighScorePlayerName(int index)
	{
		return highScoreData.PlayerList[index].Name;
	}
	public float GetHighScorePlayerScore(int index)
	{
		return highScoreData.PlayerList[index].PlayerValue.Score;
	}
	public float GetHighScorePlayerMiss(int index)
	{
		return highScoreData.PlayerList[index].PlayerValue.MissCount;
	}

	private void SaveToLocalFile(string url, string data)
	{
		try
		{
			File.WriteAllText(url, data);
		}
		catch (FileLoadException err)
		{
			if(err.Source != null)
			Debug.LogWarning("Unable To Load File");
			throw;
		}
	}
	private void LoadFromLocalFile(string url) 
	{
		string dataToBeOverWritten;
		try
		{
			dataToBeOverWritten = File.ReadAllText(url);
			highScoreData = JsonUtility.FromJson<HighScoreData>(dataToBeOverWritten);
			Debug.Log("Loading Save Successful");
		}
		catch (FileNotFoundException err)
		{
			if (err.Source != null)
				Debug.LogWarning("Unable To Find File");
			throw;
		}
	}



[Serializable]
	private class HighScoreData
{
		public List<Player> PlayerList = new List<Player>(10);
		[Serializable]
				public class Player
				{
					public Player(string name, float score, float missCount)
						{
							Name = name;
							PlayerValue = new MissAndScore(score, missCount);
						}
				public	string Name;
				public MissAndScore PlayerValue;
				}
				[Serializable]
						public class MissAndScore
						{
						public MissAndScore(float score, float missCount)
							{
							Score = score;
							MissCount = missCount;
							}
						public float Score;
						public float MissCount;
						}
}
}
