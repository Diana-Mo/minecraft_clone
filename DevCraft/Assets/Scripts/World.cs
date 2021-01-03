﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] byte[,,] worldData;
    [SerializeField] int worldX = 16;
    [SerializeField] int worldY = 16;
    [SerializeField] int worldZ = 16;

    // Start is called before the first frame update
    void Start()
    {
        worldData = new byte[worldX, worldY, worldZ];

        for(int x = 0; x < worldX; x++ )
        {
            for (int y = 0; y < worldY; y++)
            {
                for (int z = 0; z < worldZ)
                {
                    if (y <= 8)
                    {
                        worldData[x, y, z] = (byte)TextureType.rock.GetHashCode();

                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
