using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{

    //Se debe agregar un empty object como controlador suelo
    //Agregar la capa de suelo


    private Rigidbody2D rb2d;
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;


    //Salto
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;

    private bool salto = false;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        if(Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
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




}
