using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VoxelDisplay : MonoBehaviour
{


    ushort[,] voxels = new ushort[16,255];

    Mesh mesh;
    Vector3[] Vertices;
    int[] triangles;
    void populateOneFloor()
    {
        for (int i = 0; i < 16; i++)
            voxels[i, 0] = 0xffff;
    }

    void CalculateVertices()
    {
        Array.Clear(Vertices,0,Vertices.Length);
        Array.Clear(triangles,0,triangles.Length);
        int VerticeArrayIndex = 0;
        int trianglesIndex = 0;
        for(int i = 0;i < 255; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                ushort current = voxels[j, i];
                for(int k = 0; k < 16; k++)
                {
                    if((current & (1<<k))!= 0)
                    {
                        Debug.Log("prout");
                        Vertices[VerticeArrayIndex] = new Vector3(k, i, j); VerticeArrayIndex++;
                        Vertices[VerticeArrayIndex] = new Vector3(k+1, i, j); VerticeArrayIndex++;
                        Vertices[VerticeArrayIndex] = new Vector3(k, i, j+1); VerticeArrayIndex++;
                        Vertices[VerticeArrayIndex] = new Vector3(k+1, i, j+1); VerticeArrayIndex++;
                        Vertices[VerticeArrayIndex] = new Vector3(k, i - 1, j); VerticeArrayIndex++;
                        Vertices[VerticeArrayIndex] = new Vector3(k+1, i - 1, j); VerticeArrayIndex++;
                        Vertices[VerticeArrayIndex] = new Vector3(k, i - 1, j+1); VerticeArrayIndex++;
                        Vertices[VerticeArrayIndex] = new Vector3(k+1, i - 1, j+1); VerticeArrayIndex++;

                        triangles[trianglesIndex] = 0 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 2 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 1 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 1 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 2 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 3 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 0 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 5 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 4 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 0 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 1 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 5 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 0 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 4 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 6 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 0 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 6 + (VerticeArrayIndex - 8); trianglesIndex++; 
                        triangles[trianglesIndex] = 2 + (VerticeArrayIndex - 8); trianglesIndex++; 
                    }

                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        populateOneFloor();
        Vertices = new Vector3[3000];
        triangles = new int[Vertices.Length*3];
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        CalculateVertices();

        mesh.vertices = Vertices;
        //    new Vector3[3]
        //{
        //    new Vector3(0, 0, 0),
        //    new Vector3(1, 0, 0),
        //    new Vector3(0, 0, 1),
        //};
        mesh.triangles = triangles;
        //    new int[3]
        //{
        //    0,
        //    1,
        //    2
        //};
        mesh.RecalculateNormals();

    }


    void UpdateMesh()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
