using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        // your code here
        // Initialize the matrix to an identity matrix
        setIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        // your code here
        // Loop through each element in the provided array
        for (int y = 0; y < 3; y++)
        {
            // Copy the values from the array to the matrix's entries
            for (int x = 0; x < 3; x++)
            {
                entries[y, x] = multiArray[y, x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        // Assign the values to the elements in the matrix
        // your code here
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;
        // Second row
        // your code here
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;
        // Third row
        // your code here
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        // Iterate through each element and add corresponding elements from left and right matrices
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.entries[y, x] = left.entries[y, x] + right.entries[y, x];
            }
        }
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        // Iterate through each element and subtract corresponding elements from left to rght matrices
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        // Multiply each element of the matrix by the scalar value
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                result.entries[y, x] = left.entries[y, x] * scalar;
            }
        }
        return result;
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        // Matrix-vector multiplication
        float x = left.entries[0, 0] * right.x + left.entries[0, 1] * right.y + left.entries[0, 2];
        float y = left.entries[1, 0] * right.x + left.entries[1, 1] * right.y + left.entries[1, 2];
        // Retrun the results
        return new HVector2D(x, y);
    }

    //     // Note that the second argument is a HMatrix2D object
    //     //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            // Matrix multiplication operator
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],
            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
            left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],
            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
            left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
    );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        // Iterate through each element of the matrices
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
            // Check if corresponding element are not equal, if inequality is found, matrices are not equal
                if (left.entries[y, x] != right.entries[y, x]) return false;

        // If not found, matrices are equal
        return true;
    }

    // Same as == operator but reversed
    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (left.entries[y, x] != right.entries[y, x]) return true;
        return false;
    }

    //     public override bool Equals(object obj)
    //     {
    //         // your code here
    //     }

    //     public override int GetHashCode()
    //     {
    //         // your code here
    //     }

    //     public HMatrix2D transpose()
    //     {
    //         return // your code here
    //     }

    //     public float getDeterminant()
    //     {
    //         return // your code here
    //     }

    public void setIdentity()
    {
        // Set the matrix into an identity matrix
        // your code here
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                //         if(x == y)
                //         {
                //             entries[y,x] = 1;
                //         }
                //         else
                //         {
                //             entries[y,x] = 0;
                //         }

                // Set the vales to 1 or 0
                entries[y, x] = (x == y) ? 1 : 0;
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        // your code here
        setIdentity();

        // Update the matrix with translation values
        entries[0, 2] = transX;
        entries[1, 2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {
        // your code here
        setIdentity();

        // Convert degress to radians
        float rad = rotDeg * Mathf.Deg2Rad;

        // Find cosine and sine of the rotation angle
        float cosTheta = Mathf.Cos(rad);
        float sinTheta = Mathf.Sin(rad);

        // Update the rotation matrix
        entries[0, 0] = cosTheta;
        entries[0, 1] = -sinTheta;
        entries[1, 0] = sinTheta;
        entries[1, 1] = cosTheta;
    }

    //     public void setScalingMat(float scaleX, float scaleY)
    //     {
    //         // your code here
    //     }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }

    public string PrintMatrix()
    {
        return $"[{entries[0, 0]}, {entries[0, 1]}, {entries[0, 2]}\n {entries[1, 0]}, {entries[1, 1]}, {entries[1, 2]}\n {entries[2, 0]}, {entries[2, 1]}, {entries[2, 2]}]";
    }

}