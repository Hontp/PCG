using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnviromentGenerator : MonoBehaviour
{
    [Header("Array of Tiles")]
    public GameObject[] tiles;

    [Header("Grid to Popluate")]
    public GameObject Grid;

    [Header("Level DB")]
    public Level levelDB;

    Vector2 tilePosition;
    Vector2 objectSpacing;
    GameObject instance;

    void OnEnable()
    {
        tilePosition.x = Grid.GetComponent<WorldGrid>().GridXPosition;
        tilePosition.y = Grid.GetComponent<WorldGrid>().GridYPosition;

        objectSpacing = tiles[0].GetComponent<SpriteRenderer>().bounds.size;
       
    }

    void Start()
    {
        Generate(); 
    }

    public void Generate()
    {
        int rand = 0;
                
        for (int x = 0; x < Grid.GetComponent<WorldGrid>().GridWidth; x++)
        {
            for (int y = 0; y < Grid.GetComponent<WorldGrid>().GridHeight; y++)
            {
                rand = Random.Range(0, tiles.Length);
                              
                Vector2 position = new Vector2(tilePosition.x + (x * objectSpacing.x), tilePosition.y + (y * objectSpacing.y));

                instance = (GameObject)Instantiate(tiles[rand], position, Quaternion.identity);

                instance.transform.SetParent(transform);

                Grid.GetComponent<WorldGrid>().PopulateGrid(instance);               
            }
        }
    }

    public void DeleteTile(int XPos, int YPos)
    {
        DestroyImmediate(Grid.GetComponent<WorldGrid>().GetTile(XPos, YPos));
    }

  
    public void Generate(int widthOffset, int heightOffset)
    {
        for (int x = 0; x < Grid.GetComponent<WorldGrid>().GridWidth + widthOffset; x++)
        {
            for (int y = 0; y < Grid.GetComponent<WorldGrid>().GridHeight + heightOffset; y++)
            {
                int rand = Random.Range(0, tiles.Length);

                Vector2 position = new Vector2(tilePosition.x + (y * objectSpacing.x), tilePosition.y + (x * objectSpacing.y));

                instance = (GameObject)Instantiate(tiles[rand], position, Quaternion.identity);

                instance.transform.SetParent(transform);

                Grid.GetComponent<WorldGrid>().PopulateGrid(instance);
            }
        }
    }
}
