using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;

        // Calculate the displacement in each axis using velocity and time
        float dx = Velocity.x * dt;
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        // Update the position of the GameObject using the calculated displacement
        transform.position += new Vector3(dx,dy, dz);
    }
}
