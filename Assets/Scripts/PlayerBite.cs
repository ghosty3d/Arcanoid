using UnityEngine;
using System.Collections;

public class PlayerBite : MonoBehaviour
{
	public float Borders;

	public float Speed = 5f;

	private float horizontal;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(GameManager.Instance.CurrentGameState == GameManager.GameStates.Game)
		{
			horizontal = Input.GetAxis("Horizontal");			
			transform.Translate(Vector3.right * horizontal * Speed *Time.deltaTime);			
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, -Borders, Borders), transform.position.y, transform.position.z);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag == "Ball" && GameManager.Instance.CurrentGameState == GameManager.GameStates.Game)
		{
			Debug.Log("Ball");
			Vector3 force = new Vector3(Random.Range(-1f, 1f), 1f, 0) * 10f;
			other.collider.GetComponent<Rigidbody>().AddForceAtPosition(force, other.contacts[0].point, ForceMode.VelocityChange);
		}
	}
}
