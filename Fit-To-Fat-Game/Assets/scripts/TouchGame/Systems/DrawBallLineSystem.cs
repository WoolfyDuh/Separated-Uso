using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBallLineSystem : MonoBehaviour
{
	private List<GameObject> ballsInScene = new List<GameObject>(50);
	//private List<GameObject> activeBallsInScene = new List<GameObject>();
	// Start is called before the first frame update
	void Start()
	{
		Invoke("FillBallList", 0.1f);
	}


	private void Update()
	{
		Invoke("GetActiveBalls", 0.1f);
/*		if(activeBallsInScene.Count >= 2)
		{
			DrawLine();
		}*/
	}
	void FillBallList()
	{
		Debug.Log("All Balls Added");
		for (int i = 0; i < 50; i++)
		{
			GameObject ball = ObjectPooling.Instance.GetPooledBall();
			ballsInScene.Add(ball);
		}
	}

	void GetActiveBalls()
	{
		for(int i = 0; i < 49; i++)
		{
			if (ballsInScene[i].activeSelf && ballsInScene[i + 1].activeSelf)
			{
				Debug.Log("We Might Have A Premise Here!!!! " + ballsInScene[i].name + " IS READY TO BE USED ALONG WITH " + ballsInScene[i + 1].name);
			//	activeBallsInScene.Add(ballsInScene[i]);
			}
		/*	else if (!ballsInScene[i].activeSelf && activeBallsInScene.Contains(ballsInScene[i]))
			{
				Debug.Log("REMOVING THE IMPOSTER");
				activeBallsInScene.Remove(ballsInScene[i]);
			}*/
		}
	}

	/*void DrawLine()
	{
		Debug.Log("just pretend I'm doing something");
		for(int i = 0; i < activeBallsInScene.Count; i++)
		{
			if (activeBallsInScene[i + 1] != null)
			{
				Debug.Log("I should be drawing a line?");
				Debug.DrawLine(activeBallsInScene[i].transform.position, activeBallsInScene[i + 1].transform.position, Color.white, 1f);
			}
		}
	}*/
}

