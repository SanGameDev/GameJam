using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{

    //Se debe agregar un empty object como controlador suelo
    //Agregar la capa de suelo
    private Rigidbody2D rb2d;
    private float movimientoHorizontal = 0f;
    [SerializeField] public float velocidadDeMovimiento;
    [SerializeField] private float suavizadoDeMovimiento;
    [SerializeField] public float velocidadDeMovimientoShift;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    public bool estaCorriendo = false;
    public bool traeCarga = false;


    //Salto
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    public bool estaMuerto = false;
  

    private Animator animator;

    PlanetGravity planetGravity;

    private bool salto = false;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) // Verificar si se est� presionando la tecla Shift
        {
            movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimientoShift; // Usar la velocidad de movimiento con Shift
            estaCorriendo = true;
        }
        else
        {
            movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento; // Usar la velocidad de movimiento normal

            animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

            estaCorriendo = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
        animMuerte();
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);


        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        salto = false;
    }
    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }
        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2d.AddForce(new Vector2(0f, fuerzaSalto));
        }
    }

    void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Asteroide")
        {
            rb2d.gravityScale = 0.0f;
            planetGravity = this.GetComponent<PlanetGravity>();
            planetGravity.enabled = true;
            this.GetComponent<movimientoJugador>().enabled = false;
            planetGravity.planet = other.gameObject;
        }
    }

    void animMuerte()
    {
        if (estaMuerto==true)
        {
            animator.SetBool("estaMuerto", estaMuerto);
        }
    }
}

