using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    ObjectPool starPool;
    public float spawnTimer = 0.5f;
    float timer;

    void Start()
    {
        timer = spawnTimer;
        starPool = GameObject.Find("StarPool").GetComponent<ObjectPool>();
    }

    void Update()
    {
        // Make a star every second
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = spawnTimer;
            starPool.GetPooledObject().SetActive(true);
        }
    }
}
