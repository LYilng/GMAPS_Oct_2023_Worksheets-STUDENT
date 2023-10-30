using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(t => t != this).ToArray();

        // if(IsCaptain) FindMinimum();        
    }

    // void FindMinimum()
    // {
    //     for(int i = 0; i <10; i++)
    //     {
    //         float height = Random.Range(5f, 20f);
    //         Debug.Log(height);
    //     }
    // }

    //float Magnitude(Vector3 vector)
    //{
        
    //}

    Vector3 Normalise(Vector3 vector)
    {
        return vector.normalized;
    }

    //float Dot(Vector3 vectorA, Vector3 vectorB)
    //{
        
    //}

    SoccerPlayer FindClosestPlayerDot()
    {
       SoccerPlayer closest = null;
       float minAngle = 180f;

       for(int i = 0; i < OtherPlayers.Length; i++)
       {
        Vector3 toPlayer = OtherPlayers[i].transform.position - transform.position;
        toPlayer = Normalise(toPlayer);

        float dot = Vector3.Dot(transform.forward, toPlayer);
        float angle = Mathf.Acos(dot);
        angle = angle * Mathf.Rad2Deg;

        if (angle < minAngle)
        {
            minAngle = angle;
            closest = OtherPlayers[i];
        }
       }
       return closest;
    }

    void DrawVectors()
    {
       foreach (SoccerPlayer other in OtherPlayers)
       {
           // Your code here
           foreach (SoccerPlayer other2 in OtherPlayers)
           {
            if (other != other2)
            {
                Vector3 direction = other2.transform.position - other.transform.position;
                Debug.DrawRay(other.transform.position, direction, Color.black);
            }
           }
       }
    }

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

            // DrawVectors();

            SoccerPlayer targetPlayer = FindClosestPlayerDot();
            targetPlayer.GetComponent<Renderer>().material.color = Color.green;

            foreach (SoccerPlayer other in OtherPlayers.Where(t => t != targetPlayer))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}


