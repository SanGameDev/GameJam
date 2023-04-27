using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject item;
    public static ObjectPool SharedInstance;
    public List<GameObject> pool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pool = new List<GameObject>();
    }

    public GameObject GetPooledObject()
    {
        // Picks the first inactive item
        for (int i=0; i<pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        GameObject temp = Instantiate(item);
        temp.SetActive(false);
        pool.Add(temp);
        return temp;
    }
}
