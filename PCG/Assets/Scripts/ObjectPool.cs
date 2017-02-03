using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool Instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject[] objectToPool;
    public int amountToPool;


    GameObject instance;


    void Awake()
    {
        Instance = this;
    }

	void Start ()
    {
	    for ( int i = 0; i < amountToPool; i++)
        {
            for (int j = 0; j < objectToPool.Length; j++)
            {
                GameObject obj = Instantiate(objectToPool[j]);

                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
	}

    public GameObject GetPooledObjects(int index)
    {        
        return objectToPool[index];
    }
}
