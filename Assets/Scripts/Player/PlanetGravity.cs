using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Planet Gravity Variables")]
    public GameObject planet;
    public float gravityForce;
    public float gravityDistance;
    float lookAngle;
    [Header("Player Variables")]
    public float playerSpeed = 8;
    public float playerJump = 15;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CalculatePlanetGravity();
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * (Time.deltaTime * playerSpeed), Space.Self);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * (Time.deltaTime * playerSpeed), Space.Self);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector2.up *  playerSpeed, Space.Self);
        }
        else
        {
            transform.Translate(Vector2.zero, Space.Self);
        }
    }

    void CalculatePlanetGravity()
    {
        float dist = Vector3.Distance(gameObject.transform.position, planet.transform.position);
        Vector3 v = planet.transform.position - transform.position;
        rb.AddForce(v.normalized*(1.0f - dist / gravityDistance)*gravityForce);

        lookAngle = 90 + Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Asteroide")
        {
            rb.gravityScale = 1.0f;
            planet = null;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            this.GetComponent<movimientoJugador>().enabled = true;
            this.GetComponent<PlanetGravity>().enabled = false;
        }
    }
}
