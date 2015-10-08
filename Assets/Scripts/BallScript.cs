using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{
	void OnBecameInvisible()
	{
		if(GameManager.Instance.CurrentGameState == GameManager.GameStates.Game)
		{
			ResetBallPosition();
			Player.Instance.TakeLife();
		}
	}

	public void ResetBallPosition()
	{
		transform.position = Vector3.zero;
		transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
