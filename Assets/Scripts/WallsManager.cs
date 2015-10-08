using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class WallsManager : MonoBehaviour
{
	public static WallsManager Instance;

	public GameObject FrontWall;
	public GameObject SideWall;

	private Transform parentWalls;

	[SerializeField]
	private GameObject frontWall;
	[SerializeField]
	private GameObject leftWall;
	[SerializeField]
	private GameObject rightWall;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		UpdateWallsPositions();
		PlaceWalls();
	}

	//use this method to place walls according to Screen size
	public void PlaceWalls()
	{
		if(!frontWall)
		{
			//Front Wall
			Vector3 frontWallPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height, -Camera.main.transform.position.z));
			Debug.Log("Front Wall Pos[1]: " + frontWallPos);
			frontWall = Instantiate(FrontWall, frontWallPos, Quaternion.identity) as GameObject;
			frontWall.transform.parent = transform;
		}

		if(!leftWall)
		{
			//Left Wall
			Vector3 leftWallPos = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height * 0.5f, -Camera.main.transform.position.z));
			leftWall = Instantiate(SideWall, leftWallPos, Quaternion.identity) as GameObject;
			leftWall.transform.parent = transform;
		}

		if(!rightWall)
		{
			//Right Wall
			Vector3 rightWallPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 0.5f, -Camera.main.transform.position.z));
			rightWall = Instantiate(SideWall, rightWallPos, Quaternion.identity) as GameObject;
			rightWall.transform.parent = transform;
		}
	}

	//use this to update walls position in case of change Game View Aspect Ratio
	public void UpdateWallsPositions()
	{
		if(frontWall && leftWall && rightWall)
		{
			//Unparent Walls
			//frontWall.transform.parent = null;
			//leftWall.transform.parent = null;
			//rightWall.transform.parent = null;

			Debug.Log("Screen: " + Screen.width + ", " + Screen.height);

			//Update Positions
			Vector3 frontWallPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height, -Camera.main.transform.position.z));
			Vector3 leftWallPos = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height * 0.5f, -Camera.main.transform.position.z));
			Vector3 rightWallPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 0.5f, -Camera.main.transform.position.z));

			Debug.Log("Front Wall Pos[2]: " + frontWallPos);

			frontWall.transform.position = frontWallPos;
			leftWall.transform.position = leftWallPos;
			rightWall.transform.position = rightWallPos;

			//Parent Back to this transform, Just to keep hierarchy more clean
			//frontWall.transform.parent = transform;
			//leftWall.transform.parent = transform;
			//rightWall.transform.parent = transform;
		}
		else
		{
			Debug.LogError("Sorry, but you need to Instantiate Walls first!");
		}
	}

	public float CalculateFreeSpace()
	{
		if(leftWall && rightWall)
		{
			float dist = Vector3.Distance(leftWall.transform.position, rightWall.transform.position);
			dist -= (leftWall.transform.localScale.x + rightWall.transform.localScale.x);
			return dist;
		}
		else
		{
			return 0f;
		}
	}


}