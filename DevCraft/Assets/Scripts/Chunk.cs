using System.Collections;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    void CubeTop(int s, int y, int z, byte block)
    {

    }

    //called everytime a surface is created
    //it will refresh our display
    //clear out a raise and add the three arrays to the mesh
    void UpdateMesh()
    {

    }
}
