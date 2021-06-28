using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance { get; private set; }
    private List<GameObject> pooledBalls;
    [SerializeField] private GameObject ballToPool;
    private int amountToPool = 50;

    //set pooler to never disappear
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    //instantiate all the balls
	private void Start()
	{
        pooledBalls = new List<GameObject>();
        GameObject ball;
        for(int i = 0; i < amountToPool; i++)
		{
            ball = Instantiate(ballToPool);
            ball.name = "ball nr: " + i;
            ball.SetActive(false);
            pooledBalls.Add(ball);
		}
	}

    //to be used in other scripts
    public GameObject GetPooledBall()
	{
        for (int i = 0; i < amountToPool; i++)
		{
            if (!pooledBalls[i].activeInHierarchy)
                return pooledBalls[i];
		}
        return null;
	}
    public int getBalls()
	{
        return amountToPool;
	}
}
