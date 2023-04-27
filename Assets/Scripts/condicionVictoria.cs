using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condicionVictoria : MonoBehaviour
{
    public movimientoJugador movJug;

    private void Start()
    {
        movJug = GameObject.FindObjectOfType<movimientoJugador>();
    }

    private void Update()
    {
        bool traeCarga = movJug.traeCarga;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (movJug.traeCarga == true)
            {
                Debug.Log("Has ganado");
            }
            else if (movJug.traeCarga == false)
            {
                Debug.Log("Ve por la carga");
            }
        }
    }
}