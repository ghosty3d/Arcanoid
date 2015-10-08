using UnityEngine;
using System.Collections;

public class BlocksManager : MonoBehaviour
{
	public static BlocksManager Instance;

	public GameObject BlockPrefab;

	public Vector3 BlockSize = Vector3.one;

	public int BlockRows;
	[HideInInspector]
	public int BlockCols;
	public float Offset;

	public float FreeSpace;

	public enum BlockColors
	{
		Red,
		Blue,
		Yellow
	}

	public BlockColors CurrentBlockColor;

	public string TargetColor;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		FreeSpace = WallsManager.Instance.CalculateFreeSpace();
		BlockCols = Mathf.RoundToInt(FreeSpace / (BlockSize.x + Offset * 2f));
		CreateLevel(BlockRows, BlockCols);

		SelectTargetColor();
	}

	public void CreateLevel(int rows, int cols)
	{
		for(int i = 0; i < rows; i++)
		{
			for(float j = (-FreeSpace * 0.5f); j < cols; j++)
			{
				if(i == 0)
				{
					CurrentBlockColor = BlockColors.Red;
				}
				else
				{
					CurrentBlockColor = (BlockColors)Random.Range(1, 3);
				}

				Vector3 newBlocPos = new Vector3((j + Offset), (3.5f - i), 0);
				BlocksFactory(BlockPrefab, newBlocPos, CurrentBlockColor);
			}
		}
	}

	public void BlocksFactory(GameObject blockPrefab, Vector3 newPosition, BlockColors newBlockColor)
	{
		GameObject newBlock = Instantiate(blockPrefab, newPosition, Quaternion.identity) as GameObject;
		newBlock.transform.localScale = BlockSize;

		switch(newBlockColor)
		{
			case BlockColors.Blue:
				newBlock.GetComponent<Block>().NewBlockColor = Color.blue;
				newBlock.GetComponent<Block>().BlockScores = 10;
				newBlock.tag = "Blue";
			break;

			case BlockColors.Red:
				newBlock.GetComponent<Block>().NewBlockColor = Color.red;
				newBlock.GetComponent<Block>().BlockScores = 30;
				newBlock.tag = "Red";
			break;

			case BlockColors.Yellow:
				newBlock.GetComponent<Block>().NewBlockColor = Color.yellow;
				newBlock.GetComponent<Block>().BlockScores = 5;
				newBlock.tag = "Yellow";
			break;
		}
	}

	public void SelectTargetColor()
	{
		TargetColor = ((BlockColors)Random.Range(1, 3)).ToString();
	}
}
