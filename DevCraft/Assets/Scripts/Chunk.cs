﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TextureType
{
    air, grass, rock, icyGrass, ice
}

public class Chunk : MonoBehaviour
{
    private List<Vector3> newVertices = new List<Vector3>();
    //each surface of the cube has 4 vertices ^
    private List<int> newTriangles = new List<int>();
    //triangles tell unity how to build each mesh with its textures and colliders
    //the integers are numbers of the corners of those triangles
    private List<Vector2> newUV = new List<Vector2>();
    //UV is how the textures lines on the polygon it was placed on
    //2D because it's just one side, one plane of the cube

    private Mesh mesh;
    private MeshCollider chunkCollider;
    private float textureWidth = 0.083f;
    private int faceCount = 0;

    //Textures
    private Vector2 grassTop = new Vector2(1,11);
    private Vector2 grassSide = new Vector2(0, 10);
    private Vector2 rock = new Vector2(7, 8);
    private Vector2 icyGrassTop = new Vector2(7, 11);
    private Vector2 icyGrassSide = new Vector2(6, 10);
    private Vector2 ice = new Vector2(4, 11);
    private Vector2 magma = new Vector2(1, 8);

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        chunkCollider = GetComponent<MeshCollider>();

        CubeTop(0, 0, 0, (byte)TextureType.rock.GetHashCode());
        CubeNorth(0, 0, 0, (byte)TextureType.rock.GetHashCode());
        CubeEast(0, 0, 0, (byte)TextureType.rock.GetHashCode());
        CubeSouth(0, 0, 0, (byte)TextureType.rock.GetHashCode());
        CubeWest(0, 0, 0, (byte)TextureType.rock.GetHashCode());
        CubeBot(0, 0, 0, (byte)TextureType.rock.GetHashCode());

        UpdateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called everytime a surface is created
    //it will refresh our display
    //clear out a raise and add the three arrays to the mesh
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = newVertices.ToArray();
        mesh.uv = newUV.ToArray();
        mesh.triangles = newTriangles.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();

        chunkCollider.sharedMesh = null;
        chunkCollider.sharedMesh = mesh;

        newVertices.Clear();
        newUV.Clear();
        newTriangles.Clear();
        faceCount = 0;
    }

    //
    void CubeTop(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x, y, z + 1));
        newVertices.Add(new Vector3(x+1, y, z + 1));
        newVertices.Add(new Vector3(x+1, y, z));
        newVertices.Add(new Vector3(x, y, z));

        Vector2 texturePos; ;
        texturePos = rock;

        Cube(texturePos);
    }

    void CubeNorth(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x + 1, y - 1, z + 1));
        newVertices.Add(new Vector3(x + 1, y, z + 1));
        newVertices.Add(new Vector3(x, y, z + 1));
        newVertices.Add(new Vector3(x, y - 1, z + 1));

        Vector2 texturePos; ;
        texturePos = rock;

        Cube(texturePos);
    }

    void CubeEast(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x + 1, y - 1, z));
        newVertices.Add(new Vector3(x + 1, y, z));
        newVertices.Add(new Vector3(x + 1, y, z + 1));
        newVertices.Add(new Vector3(x + 1, y - 1, z + 1));

        Vector2 texturePos; ;
        texturePos = rock;

        Cube(texturePos);
    }

    void CubeSouth(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x, y - 1, z));
        newVertices.Add(new Vector3(x, y, z));
        newVertices.Add(new Vector3(x + 1, y, z));
        newVertices.Add(new Vector3(x + 1, y - 1, z));

        Vector2 texturePos; ;
        texturePos = rock;

        Cube(texturePos);
    }

    void CubeWest(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x, y - 1, z + 1));
        newVertices.Add(new Vector3(x, y, z + 1));
        newVertices.Add(new Vector3(x, y, z));
        newVertices.Add(new Vector3(x, y - 1, z));

        Vector2 texturePos; ;
        texturePos = rock;

        Cube(texturePos);
    }

    void CubeBot(int x, int y, int z, byte block)
    {
        newVertices.Add(new Vector3(x, y - 1, z));
        newVertices.Add(new Vector3(x + 1, y - 1, z));
        newVertices.Add(new Vector3(x + 1, y - 1, z + 1));
        newVertices.Add(new Vector3(x, y - 1, z + 1));

        Vector2 texturePos; ;
        texturePos = rock;

        Cube(texturePos);
    }

    void Cube (Vector2 texturePos)
    {
        newTriangles.Add(faceCount * 4); //1
        newTriangles.Add(faceCount * 4 + 1); //2
        newTriangles.Add(faceCount * 4 + 2); //2
        newTriangles.Add(faceCount * 4); //1
        newTriangles.Add(faceCount * 4 + 2); //3
        newTriangles.Add(faceCount * 4 + 3); //4

        newUV.Add(new Vector2(textureWidth * texturePos.x + textureWidth, textureWidth * texturePos.y));
        newUV.Add(new Vector2(textureWidth * texturePos.x + textureWidth, textureWidth * texturePos.y + textureWidth));
        newUV.Add(new Vector2(textureWidth * texturePos.x, textureWidth * texturePos.y + textureWidth));
        newUV.Add(new Vector2(textureWidth * texturePos.x, textureWidth * texturePos.y));

        faceCount++; 
    }
}
