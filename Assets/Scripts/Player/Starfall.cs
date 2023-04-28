using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfall : MonoBehaviour
{
    public float speed = 1.0f,     angle = 90.0f;
    public float minAngle = 45.0f, maxAngle = 135.0f;
    public float minSpeed = 2.0f,  maxSpeed = 5.0f;
    ObjectPool boomPool;

    void Awake()
    {
        boomPool = GameObject.Find("BoomPool").GetComponent<ObjectPool>();
    }

    void OnDisable()
    {
        float randomX = Random.Range(-10.0f, 10.0f);
        angle = Random.Range(minAngle, maxAngle);
        speed = Random.Range(minSpeed, maxSpeed);
        transform.position = new Vector3(randomX, 5.0f, 0);
    }

    void Update()
    {
        float step = Time.deltaTime * speed;
        float radians = Mathf.PI * angle / 180;
        float X = Mathf.Cos(radians) * step;
        float Y = Mathf.Sin(radians) * step;

        // Mover
        transform.Rotate(Vector3.forward * step * 45);
        transform.position -= new Vector3(X, Y, 0);

        if (transform.position.y < -5.0f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Vector2 dir = player.transform.position - transform.position;
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
            // Explosion Particle System
            ParticleSystem boom = boomPool.GetPooledObject().GetComponent<ParticleSystem>();
            boom.transform.position = transform.position;
            boom.gameObject.SetActive(true);
            boom.Clear();
            boom.Play();
            // Die
            gameObject.SetActive(false);
        }
    }
}
