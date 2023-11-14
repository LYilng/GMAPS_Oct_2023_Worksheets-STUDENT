using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    // Start is called before the first frame update
    void Start()
    {
        mat.setIdentity();
        mat.Print();
        Question2a();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Question2a()
    {
        // Define 3x3 matrices and a 3x1 vector
        HMatrix2D mat1 = new HMatrix2D(
        1.0f, 2.0f, 3.0f,
        4.0f, 5.0f, 6.0f,
        7.0f, 8.0f, 9.0f
    );

        HMatrix2D mat2 = new HMatrix2D(
            9.0f, 8.0f, 7.0f,
            6.0f, 5.0f, 4.0f,
            3.0f, 2.0f, 1.0f
        );
        HMatrix2D resultMat;
        HVector2D vec1 = new HVector2D(1.0f, 2.0f);

        // Perform matrix and vector multiplications
        resultMat = mat1 * mat2;  // Matrix multiplication
        HVector2D resultVec = mat1 * vec1;  // Matrix-vector multiplication

        // Compare the results with the online matrix multiplication
        // website by printing them in the console
        Debug.Log("Matrix Matrix Multiplication Result:\n" + resultMat.PrintMatrix());
        Debug.Log("Matrix Vector Multiplication Result:\n" + resultVec.x + ", " + resultVec.y);
    }
}
