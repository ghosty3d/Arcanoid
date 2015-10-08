using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIRootScript : MonoBehaviour
{
	public static UIRootScript Instance;

	public Text LivesText;
	public Text ScoresText;
	public Text GameOverText;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start ()
	{
	
	}

	public void UpdateLives(int newLivesCount)
	{
		LivesText.text = "Lives: " + newLivesCount;
	}

	public void UpdateScores(int newScoresCount)
	{
		ScoresText.text = "Scores: " + newScoresCount;
	}

	public void ShowGameOver()
	{
		GameOverText.gameObject.SetActive(true);
	}
}
