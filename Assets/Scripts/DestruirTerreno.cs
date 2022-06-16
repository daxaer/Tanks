using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestruirTerreno : MonoBehaviour
{
    [SerializeField] private Tilemap terrain;
    public static DestruirTerreno instance;

    private void Awake()
    {
        instance = this;
    }
    public void DestruirMapa(Vector3 explosionLocation, float radius)
    {
        for(int x = -(int)radius; x < radius; x++)
        {
            for(int y = -(int)radius; y < radius; y++)
            {
                Vector3Int tilePos = terrain.WorldToCell(explosionLocation + new Vector3(x,y,0));
                if(terrain.GetTile(tilePos) != null)
                {
                    DestroyTile(tilePos);
                }
            }
        }
    }
    void DestroyTile(Vector3Int tilePos)
    {
        terrain.SetTile(tilePos, null);
    }
}

