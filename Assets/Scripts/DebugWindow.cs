using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugWindow : MonoBehaviour {

	public Text inputMousePos;
	public Text hitInfo;

	public static DebugWindow instance;
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void LogMousePos(float x, float y)
	{
		inputMousePos.text = "( " + x + ", " + y + " )";
	}

	public void LogHitInfo(RaycastHit hit)
	{
		hitInfo.text = "Name: " + hit.transform.name
		 			 + "\nPos: " + hit.transform.position;
	}
}
