using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance { get; private set; }
    public float score { get; private set; } = 0f;
    public float misses { get; private set; } = 0f;

	private void Awake()
	{
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
	}
	// Start is called before the first frame update
	void Start()
    {
        ResetScore();
        ResetMisses();
    }
  //setters
    public void AddScore(float amount) => score += amount;
    public void AddMisses(float amount) => misses += amount;
    //other useful functions
    public void ResetScore() => score = 0;
    public void ResetMisses() => misses = 0; 
}
