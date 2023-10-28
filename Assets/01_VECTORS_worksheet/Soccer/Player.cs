using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsCaptain = true;
    public Player OtherPlayer;

    //float Magnitude(Vector3 vector)
    //{
    //    // Your code here
    //}

    //Vector3 Normalise(Vector3 vector)
    //{
    //    // Your code here
    //}

    //float Dot(Vector3 vectorA, Vector3 vectorB)
    //{
    //    // Your code here
    //}

    //float AngleToPlayer()
    //{
    //    // Steps to calculate the angle between the direction Captain is facing and 
    //    // the direction from Captain to Other
    //    // 1. A
    //    // 2. B
    //    // 3. Calculate the angle between the vectors from A and B
    //    //    3.1 Calculate the dot product between A and B
    //    //       3.1.1 Calculate the magnitude of the vector from Captain to Other (A)
    //    //       3.1.2 Normalise the vector from Captain to Other
    //    //       3.1.3 Calculate the dot product of the normalised vectors A and B
    //    //    3.2 From the dot product, calculate the actual angle between A and B
    //    //       3.2.1 Take the arc cosine (acos) of the dot product (because if 
    //    //             both vector are normalised, the dot product equals the cos
    //    //             of the angle between vectors A and B.
    //    //       3.2.2 The acos angle returned is in radians. We must convert to
    //    //             degrees.

    //    // A
    //    // Steps to draw the arrow that represents the vector from Captain to Other 
    //    // 1. Find the vector from Captain to Other
    //    //     1.1 Find the position of Captain (A -- from)
    //    //     1.2 Find the position of Other (B -- to)
    //    //     1.3 Calculate B-A to get the vector from A to B
    //    // 2. Draw the arrow to represent visually the vector AB
    //    //

    //    // Your code here

    //    // B
    //    // Steps to draw an arrow that represents which direction Captain is facing
    //    // 1. Find which vector to draw as an arrow
    //    //    1.1 The transform.forward vector of Captain
    //    // 2. Draw the arrow to represent visually the the transform.forward vector of Captain
    //    DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);

    //    // CALCULATING THE ANGLE

    //    // Your code here
    //    // ...

    //    // Your code here
    //}

    void Update()
    {
        if (IsCaptain)
        {
            // Find the direction vector between captain and player
            Vector3 direction = OtherPlayer.transform.position - transform.position;
            // Draw arrow from captain to player
            DebugExtension.DebugArrow(transform.position, direction, Color.black);
            // Draw foward vector
            DebugExtension.DebugArrow(transform.position, transform.forward, Color.blue);

            // Find the angle between captain's forward vector and direction vector 
            float angle = Vector3.Angle(transform.forward, direction);
            // Debug.Log(angle);
            // Find the dot product of two vectors
            float dot = Vector3.Dot(transform.right, direction);

            // Check if it is a anticlockise dot product
            if (dot < 0)
            {
                // Find the clockwise angle
                angle = 360 - angle;
            }

            Debug.Log("Angle is " + angle + " degrees");
        }
    }
}
