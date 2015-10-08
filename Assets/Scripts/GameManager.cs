using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public enum GameStates
	{
		Game,
		GameOver
	}

	public GameStates CurrentGameState;

	void Awake()
	{
		Instance = this;
		SetGameState();
	}

	public void SetGameState()
	{
		CurrentGameState = GameStates.Game;
	}

	public void SetGameOverState()
	{
		CurrentGameState = GameStates.GameOver;
		UIRootScript.Instance.ShowGameOver();
	}
}
