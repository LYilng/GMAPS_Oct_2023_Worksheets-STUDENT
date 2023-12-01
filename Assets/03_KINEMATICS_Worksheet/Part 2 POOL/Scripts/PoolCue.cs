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
		// Check if left mouse button is pressed
		if (Input.GetMouseButtonDown(0))
		{
			// Convert mouse position to world coordinates for line drawing start
			var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
			// Check if the ball exists and the mouse click is on or within the ball's radius
			if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))
			{
				// Create a new line and enable drawing
				drawnLine = lineFactory.GetLine(startLinePos, startLinePos, 0.1f, Color.black);
				drawnLine.EnableDrawing(true);
			}
		}
		// Check if the left mouse button is released and a line is being drawn
		else if (Input.GetMouseButtonUp(0) && drawnLine != null)
		{
			// Disable drawing 
			drawnLine.EnableDrawing(false);

			//update the velocity of the white ball based on the drawn line
			HVector2D v = new HVector2D(drawnLine.end - drawnLine.start);
			ball.Velocity = v;

			drawnLine = null; // End line drawing            
		}
		// Update the end position of the drawn line if it exists
		if (drawnLine != null)
		{
			// Convert mouse position to world coordinates for updating line end
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
