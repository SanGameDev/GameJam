using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaDeJugador : MonoBehaviour
{
    public int vidaPlayer = 100;
    public int vidaMaxima = 100;
    public int vecesMuerto;
    public int multiplicadorVida = 3;
    public movimientoJugador movJug;
    public bool estaMuerto;



    private void Start()
    {
        vecesMuerto = 0;
        

        movJug = GameObject.FindObjectOfType<movimientoJugador>();
    }
    private void Update()
    {
        Escudo();
        bool estaMuerto = movJug.estaMuerto;
        
        Muerte();
    }


    public void RecibirDano(int dano)
    {
        vidaPlayer -= dano;
        if (vidaPlayer < 0)
        {
            vidaPlayer = 0;
        }

    }

    public void Muerte()
    {
        if (vidaPlayer == 0)
        {
            vecesMuerto++;
            movJug.estaMuerto = true;
            Debug.Log("Has muerto");
        }
    }

    public void Escudo()
    {
        if (vecesMuerto == 3)
        {
            vidaPlayer = vidaPlayer * multiplicadorVida;
        }
    }
}
