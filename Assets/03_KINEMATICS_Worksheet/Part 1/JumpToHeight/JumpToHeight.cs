using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        // Get RigidBody component
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        // Calculate the initial vertical velocity (u) for the jump using the kinematic equation
        float u = Mathf.Sqrt(0 - 2F * Physics.gravity.y * Height);
        // Set the Rigidbody;s velovity to initiate the jump with the calculated initial velocity
        rb.velocity = new Vector3(0, u, 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Make the cube jump
            Jump();
        }
    }
}

