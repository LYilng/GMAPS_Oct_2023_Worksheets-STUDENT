using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
	public LineFactory lineFactory;
	public GameObject ballObject;

	private Line drawnLine;
	private Ball2D ball;

	private void Start()
	{
		ball = ballObject.GetComponent<Ball2D>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
			if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
			{
				drawnLine = lineFactory.GetLine(startLinePos, startLinePos, 0.1f, Color.black);
				drawnLine.EnableDrawing(true);
			}
		}
		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		{
			drawnLine.EnableDrawing(false);

			//update the velocity of the white ball.
			HVector2D v = new HVector2D(drawnLine.end - drawnLine.start);
			ball.Velocity = v;

			drawnLine = null; // End line drawing            
		}

		if (drawnLine != null)
		{
            var endLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			drawnLine.end = new HVector2D(endLinePos.x, endLinePos.y).ToUnityVector2(); // Update line end
		}
	}

	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
	public void Clear()
	{
		var activeLines = lineFactory.GetActive();

		foreach (var line in activeLines)
		{
			line.gameObject.SetActive(false);
		}
	}
}
