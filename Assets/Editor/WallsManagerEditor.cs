using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(WallsManager))]
public class WallsManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		WallsManager wallsManager = (WallsManager)target;

		if(GUILayout.Button("Place Walls"))
		{
			wallsManager.PlaceWalls();
		}

		if(GUILayout.Button("Update Walls"))
		{
			wallsManager.UpdateWallsPositions();
		}
	}
}
