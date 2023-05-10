using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomarCarga : MonoBehaviour
{
    //Es un script para un collider2d trigger sobre el que estara el maletin o que sea el mismo maletin
    public bool traeCarga;
    public movimientoJugador movJug;
    public GameObject level1;
    public GameObject level2;

    private void Start()
    {
        movJug = GameObject.FindObjectOfType<movimientoJugador>();
    }
    private void Update()
    {
        float velocidad = movJug.velocidadDeMovimiento;
        float velocidadshift = movJug.velocidadDeMovimientoShift;
        bool traeCarga = movJug.traeCarga;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            movJug.traeCarga = true;
            //movJug.velocidadDeMovimiento /= 2f;
            movJug.velocidadDeMovimientoShift /= 2f;
            level1.SetActive(false);
            level2.SetActive(true);
            Destroy(gameObject);
        }
    }
}