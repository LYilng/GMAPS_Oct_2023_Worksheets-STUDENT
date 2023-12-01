using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);
    
    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        // Calculate the distance between the specified point x,y and the center of the object
        float distance = Mathf.Sqrt(Mathf.Pow(x - Position.x, 2) + Mathf.Pow(y - Position.y, 2));
        // Check if the calculated distance is less than or equal to the object's radius
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        // Calculate the displacement in the x and y aces based on the current velocity and time passed
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        // Update the ball's position by adding the calculated displacements
        Position.x += displacementX;
        Position.y += displacementY;

        // Update the Unity transform position to match the new 2D position
        transform.position = new Vector2(Position.x, Position.y);
    }
}

