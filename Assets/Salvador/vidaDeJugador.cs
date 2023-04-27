using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaDeJugador : MonoBehaviour
{
    public int vidaPlayer = 100;
    public int vidaMaxima = 100;
    public int vecesMuerto;
    public int multiplicadorVida = 3;



    private void Start()
    {
        vecesMuerto = 0;


    }
    private void Update()
    {
        Escudo();
    }


    public void RecibirDaño(int daño)
    {
        vidaPlayer -= daño;
        if (vidaPlayer < 0)
        {
            vidaPlayer = 0;
        }


        if (vidaPlayer == 0)
        {
            Muerte();
        }

    }

    public void Muerte()
    {
        vecesMuerto++;
        Debug.Log("Has muerto");
    }

    public void Escudo()
    {
        if (vecesMuerto == 3)
        {
            vidaPlayer = vidaPlayer * multiplicadorVida;
        }
    }
}
