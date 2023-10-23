
using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {// https://www.youtube.com/watch?v=aZOyZJhreSU&t=4s
        // Calculate the gravity force direction
        gravityDir = transform.position - planet.position;
        // Creates the move direction vector
        moveDir = new Vector3(gravityDir.y, -gravityDir.x ,0f);
        // Set the move direction vector to 1
        moveDir = moveDir.normalized * -1f;
        
        // Move the astranaut
        rb.AddForce(-moveDir * force);
        
        // Sets the normal for the gravity (Arrow that points up) by swapping with teh gravityDir 
        gravityNorm = -gravityDir.normalized;
        // Pulls the astraunaut down
        rb.AddForce(gravityNorm * gravityStrength);

        // Calculates the angle between the vector gravityNorm and moveDir 
        float angle = Vector3.SignedAngle(gravityNorm, moveDir, Vector3.right);

        // Rotato to align the object based on gravity force
        rb.MoveRotation(Quaternion.Euler(0,0,angle));

        // Draw the two arrows
        DebugExtension.DebugArrow(transform.position, -gravityDir, Color.red);
        DebugExtension.DebugArrow(transform.position, -moveDir, Color.blue);  
    }
}


