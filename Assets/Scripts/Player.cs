using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public static Player Instance;

	public int Lives = 5;
	public int Scores = 0;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		UIRootScript.Instance.UpdateScores(Scores);
		UIRootScript.Instance.UpdateLives(Lives);
	}

	public void AddScores(int scores)
	{
		Scores += scores;
		UIRootScript.Instance.UpdateScores(Scores);
	}

	public void TakeLife()
	{
		Lives--;
		if(Lives == 0)
		{
			GameManager.Instance.SetGameOverState();
		}

		UIRootScript.Instance.UpdateLives(Lives);
	}
}
