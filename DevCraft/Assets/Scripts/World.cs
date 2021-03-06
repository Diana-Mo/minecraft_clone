﻿using UnityEngine;
using Noise;

public class World : MonoBehaviour
{
    [SerializeField] GameObject chunk;

    [SerializeField] int worldX = 16;
    [SerializeField] int worldY = 16;
    [SerializeField] int worldZ = 16;
    [SerializeField] int chunkSize = 16;

    private byte[,,] worldData;
    private Chunk[,,] chunks;

    // Start is called before the first frame update
    void Start()
    {
        worldData = new byte[worldX, worldY, worldZ];

        for(int x = 0; x < worldX; x++ )
        {
            for (int z = 0; z < worldZ; z++)
            {
                int rock = PerlinNoise(x, 0, z, 10f, 3f, 1.2f);
                rock += PerlinNoise(x, 200, z, 50, 30f, 0f) + 10;
                int grass = PerlinNoise(x, 100, z, 50, 30f, 0f) + 1;
                //int icyGrass = PerlinNoise(x, 50, z, 50, 30f, 0f) + 1;
                //int ice = PerlinNoise(x, 3, z, 10f, 3.2f, 1.5f);
                //ice += PerlinNoise(x, 350, z, 50, 30f, 0f) + 12;
                
                //int ice = PerlinNoise(x, 3, z, 10f, 3.2f, 1.5f);
                //ice += PerlinNoise(x, 300, z, 50, 30f, 0f) + 12;
                for (int y = 0; y < worldY; y++)
                {
                    if (y <= rock)
                    //&& y >= icyGrass
                    {
                        worldData[x, y, z] = (byte)TextureType.grass.GetHashCode();
                    }
                    else if (y <= grass)
                    {
                        worldData[x, y, z] = (byte)TextureType.rock.GetHashCode();
                    }
                    //else if (y <= rock && y != grass)
                    //{
                    //    worldData[x, y, z] = (byte)TextureType.icyGrass.GetHashCode();
                    //}
                    //else if (y <= icyGrass)
                    //{
                    //    worldData[x, y, z] = (byte)TextureType.ice.GetHashCode();
                    //}
                    //else if (y >= icyGrass)
                    //{
                    //    worldData[x, y, z] = (byte)TextureType.ice.GetHashCode();
                    //}

                }
                    //if (y <= 8)
                    //{
                    //    worldData[x, y, z] = (byte)TextureType.rock.GetHashCode();

                    //}
            }
        }

        chunks = new Chunk[Mathf.FloorToInt(worldX / chunkSize), Mathf.FloorToInt(worldY / chunkSize), Mathf.FloorToInt(worldZ / chunkSize)];
        for (int x = 0; x < chunks.GetLength(0); x++)
        {
            for (int y = 0; y < chunks.GetLength(0); y++)
            {
                for (int z = 0; z < chunks.GetLength(0); z++)
                {
                    GameObject newChunk = Instantiate(chunk, new Vector3(x * chunkSize, y * chunkSize, z * chunkSize), new Quaternion(0, 0, 0, 0));
                    chunks[x, y, z] = newChunk.GetComponent("Chunk") as Chunk;
                    chunks[x, y, z].WorldGO = gameObject;
                    chunks[x, y, z].ChunkSize = chunkSize;
                    chunks[x, y, z].ChunkX = x * chunkSize;
                    chunks[x, y, z].ChunkY = y * chunkSize;
                    chunks[x, y, z].ChunkZ = z * chunkSize;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int PerlinNoise (int x, int y, int z, float scale, float height, float power)
    {
        float perlinValue;
        perlinValue = Noise.Noise.GetNoise((double)x / scale, (double)y / scale, (double)z / scale);
        perlinValue *= height;

        if (power != 0)
        {
            perlinValue = Mathf.Pow(perlinValue, power);
        }
        return (int)perlinValue;
    }

    public byte Block (int x, int y, int z)
    {
        if (x >= worldX || x < 0 || y >= worldY || y < 0 || z >= worldZ || z < 0)
        {
            return (byte)TextureType.rock.GetHashCode();
        }
        return worldData[x, y, z];
    }
}
