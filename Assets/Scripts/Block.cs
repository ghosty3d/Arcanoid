using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
	public Color NewBlockColor;
	public int BlockScores;

	// Use this for initialization
	void Start ()
	{
		transform.GetComponent<MeshRenderer>().material.SetColor("_AlbedoColor", NewBlockColor);
		transform.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", NewBlockColor);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag == "Ball" && this.gameObject.tag == BlocksManager.Instance.TargetColor)
		{
			Player.Instance.AddScores(BlockScores);
			Destroy(this.gameObject);
		}
	} 
}
