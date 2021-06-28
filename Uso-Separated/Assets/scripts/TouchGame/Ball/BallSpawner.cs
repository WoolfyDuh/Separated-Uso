using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float nextTimeToSpawn = 0f;
    [SerializeField] private float spawnFrequency = 0.5f;
    [SerializeField] private GameObject canvas;
    bool isSpawning;

    private Vector3 RandPos = new Vector3(0, 0, 1);

	void Update()
    {
        if(Time.time >= nextTimeToSpawn && isSpawning) 
		{
            SpawnBalls();                             // the lower the divisible number the faster the spawns
            nextTimeToSpawn = Time.time + ( spawnFrequency / spawnRate);  
		}
    }

    /// <summary>
    /// set the spawnrate and frequency of the balls.
    /// the lower the divisble number the faster they spawn
    /// </summary>
    /// <param name="frequency"></param>
    /// <param name="rate"></param>
    public void SetSpawnRate(float frequency, float rate)
	{
        spawnFrequency = frequency;
        spawnRate = rate;
	}

    void SpawnBalls()
    {
        GameObject ball = ObjectPooling.Instance.GetPooledBall();
        ball.transform.SetParent(canvas.transform, false);
        RandPos.x = Random.Range(20f, Screen.width - 20f);
        RandPos.y = Random.Range(10f, Screen.height - 160f);
        ball.transform.position = RandPos;
        ball.SetActive(true);
    }

    public void IsSpawning(bool choice)
	{
        isSpawning = choice;
	}
}
