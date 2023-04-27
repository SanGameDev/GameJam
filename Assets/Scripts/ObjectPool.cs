using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pool;
    public GameObject item;
    float timer = 1.0f;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pool = new List<GameObject>();
    }

    void Update()
    {
        // Make a star every second
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 1.0f;
            GetPooledObject().SetActive(true);
        }
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
