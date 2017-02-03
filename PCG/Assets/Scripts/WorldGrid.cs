using System;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    GameObject[,] tiles;

    [Header("Position of The Grid On Screen")]
    public float GridXPosition;
    public float GridYPosition;

    [Header("Size of The Grid in Whole Numbers")]
    public int GridWidth;
    public int GridHeight;

    Rect renderWindow;

    void OnEnable()
    {
       RenderWindow(GridXPosition, GridYPosition, GridWidth, GridHeight);
        
       tiles = new GameObject[(int)renderWindow.width, (int)renderWindow.height];
    }


     Rect RenderWindow(float XPos, float YPos, int Width, int Height)
    {
        renderWindow = new Rect(XPos, YPos, Width, Height);

        return renderWindow;
    }


    public void PopulateGrid(GameObject tile)
    {
        for (int x = 0; x < renderWindow.width; x++)
        {
            for (int y = 0; y < renderWindow.height; y++)
            {
                tiles[x,y] = tile;
            }
        }
    }

    public Vector2 GetTileCoordinates( string tileName)
    {
        Vector2 coord = new Vector2(-9999,-9999);

        for (int x = 0; x < renderWindow.width; x++)
        {
            for ( int y =0; y < renderWindow.height; y++)
            {
                if (tiles[x, y] != null)
                {
                    if (tiles[x, y].name == tileName)
                    {
                        coord = new Vector2(x, y);
                    }
                }
            }
        }

        return coord;
    }

    public GameObject[,] GetRegion(int regionWidth, int regionHeight)
    {
        GameObject[,] region = new GameObject[regionWidth , regionHeight];
        Array.Copy(tiles, region, regionWidth * regionHeight);

        return region;
    }

    public GameObject GetTile( int XPos, int YPos)
    {
        if (tiles[XPos, YPos] != null)
            return tiles[XPos, YPos];

        return null;
    }

    public void SetTile(int XPos, int YPos, GameObject tile)
    {
        if (XPos < renderWindow.width && YPos < renderWindow.height)
        {
            tiles[XPos, YPos] = tile;
        }
        else
        {
            Debug.Log("Can not place tile, Out of Grid Bounds");
        }
    }

    public void SetTile(GameObject[,] Region ,int XPos, int YPos, GameObject tile)
    {
        if (XPos < renderWindow.width && YPos < renderWindow.height)
        {
            Region[XPos, YPos] = tile;
        }
        else
        {
            Debug.Log("Can not place tile, Out of Region Bounds");
        }
    }
    
}
