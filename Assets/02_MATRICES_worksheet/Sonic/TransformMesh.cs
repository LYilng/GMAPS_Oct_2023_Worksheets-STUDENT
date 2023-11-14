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
        meshManager = GetComponent<MeshManager>();
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
        transformMatrix.setIdentity();
        transformMatrix.setTranslationMat(x,y);
        Transform();

        pos = transformMatrix * pos;
    }

    private void Transform()
    {
        vertices = meshManager.meshFilter.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x,vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y; 
        }
        meshManager.meshFilter.mesh.vertices = vertices;
    }

    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix  = new HMatrix2D();
        HMatrix2D rotationMatrix = new HMatrix2D();

        toOriginMatrix.setTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.setTranslationMat(pos.x,pos.y);

        rotationMatrix.setRotationMat(angle);

        transformMatrix.setIdentity();
        transformMatrix = fromOriginMatrix * rotationMatrix * toOriginMatrix;

        Transform();
    }
}
