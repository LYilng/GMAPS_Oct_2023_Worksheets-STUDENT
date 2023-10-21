using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x + b.x, a.y + b.y);
    }

    public static HVector2D operator -(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x - b.x, a.y - b.y);
    }

    public static HVector2D operator *(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x * b.x, a.y * b.y);
    }

    public static HVector2D operator /(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x / b.x, a.y / b.y);
    }

    public float Magnitude()
    {
        return Mathf.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float magnitude = Mathf.Sqrt(x * x + y * y);

        if (magnitude > 0)
        {
            x /= magnitude;
            y /= magnitude;
        }
    }

    public float DotProduct(HVector2D otherVector)
    {
        return x * otherVector.x + y * otherVector.y;
    }

    public HVector2D Projection(float projection)
    {
        return new HVector2D(x * projection, y * projection);
    }

    // public float FindAngle(/*???*/)
    // {

    // }

    public Vector2 ToUnityVector2()
    {
        return new Vector2(x, y); // change this
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0); // change this
    }

    // public void Print()
    // {

    // }
}
