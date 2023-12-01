using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    private Vector3[] vertices;
    private MeshManager meshManager;
    private HMatrix2D transformMatrix = new HMatrix2D();
    private HVector2D pos = new HVector2D();

    // Start is called before the first frame update
    void Start()
    {
        // Get the MeshManger component attached to the GameObject
        meshManager = GetComponent<MeshManager>();
        // Set vector to current position of gameObject
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Translate(1.0f, 1.0f);
        Rotate(45.0f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void Translate(float x, float y)
    {
        // Reset the transform matrix to an identity matrix
        transformMatrix.setIdentity();
        // Set the transformation matrix to a translation matrix with specified value
        transformMatrix.setTranslationMat(x,y);
        Transform();

        // Show new position after translation
        pos = transformMatrix * pos;
    }

    private void Transform()
    {
        // Get vertices of the mesh
        vertices = meshManager.meshFilter.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            // Convert each vertix to a homgeneous vector
            HVector2D vert = new HVector2D(vertices[i].x,vertices[i].y);
            // Apply the transformation to the vertex
            vert = transformMatrix * vert;
            // Update the vertex coorfinates with the transformed values
            vertices[i].x = vert.x;
            vertices[i].y = vert.y; 
        }
        // Update the mesh with the transformed vectices
        meshManager.meshFilter.mesh.vertices = vertices;
    }

    void Rotate(float angle)
    {
        // Create transformation matrices for translating to and from the origin
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix  = new HMatrix2D();

        // Create a rotation matric with the specified angle
        HMatrix2D rotationMatrix = new HMatrix2D();
        rotationMatrix.setRotationMat(angle);

        // Translate to the origin, rotate, and then translate back to the original positon
        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.setTranslationMat(pos.x,pos.y);

        // Reset the transform matrix to an identity matrix
        transformMatrix.setIdentity();

        // Combine the translation, rotation, and inverse translation matrices
        transformMatrix = fromOriginMatrix * rotationMatrix * toOriginMatrix;

        // Apply the transformation to the gameObject anad update its vertices
        Transform();
    }
}
