using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        // Get rigidbody component attached to the same Gameobject
        rb = GetComponent<Rigidbody>();// your code here;
        // Add an impluse force to the Rigidbody along the x-axis
        rb.AddForce(new Vector3(force.x, 0f, 0f), ForceMode.Impulse);// your code here;
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

