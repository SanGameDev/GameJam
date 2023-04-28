using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class contadorEstrellasTimer : MonoBehaviour
{
    public float tiempoLimite = 60f; // Tiempo l�mite para completar el nivel
    private float tiempoTranscurrido = 0f; // Tiempo que ha pasado desde que se inici� el nivel
    private int numEstrellas = 0; // N�mero de estrellas obtenidas
    public bool nivelCompletado = false; // Indica si el jugador ha completado el nivel
    public Text textoTiempo; // Referencia al objeto de texto que muestra el tiempo
    public Text textoEstrellas; // Referencia al objeto de texto que muestra el n�mero de estrellas
    public float DosEstrellas = 10; //Tiempo en el que se dan cada numero de estrellas
    public float TresEstrellas = 20;
    public TimeSpan time;
    

    void Start()
    {
        tiempoTranscurrido = 0f;
        numEstrellas = 0;
        nivelCompletado = false;
        ActualizarTextos();
    }

    void Update()
    {
        if (!nivelCompletado)  //Aqui ayuda a que el contador siga avanzando
        {
            tiempoTranscurrido = tiempoTranscurrido + Time.deltaTime;
            //tiempoTranscurrido += Time.deltaTime;
            ActualizarTextos();

            // Comprobar si se ha superado el tiempo l�mite
            if (tiempoTranscurrido >= tiempoLimite)
            {
                nivelCompletado = true;
                numEstrellas = 1;
                ActualizarTextos();
            }
        }
        time = TimeSpan.FromSeconds(tiempoTranscurrido); 
        CompletarNivel();
    }

    void ActualizarTextos()
    {
        // Mostrar el tiempo transcurrido y el n�mero de estrellas obtenidas
        textoTiempo.text = time.ToString(@"mm\:ss\:fff");
        textoEstrellas.text = "Estrellas: " + numEstrellas.ToString();
    }   
    public void CompletarNivel()
    {
        if (nivelCompletado == true)   //Determina si el tiempo empleado merece una dos o tres etrellas
        {
            if (tiempoTranscurrido <= TresEstrellas)
            {
                Debug.Log("Tres estrellas");

            }
            else if (tiempoTranscurrido >= TresEstrellas && tiempoTranscurrido <= DosEstrellas)
            {
                Debug.Log("Dos Estrellas");
            }
            else if (tiempoTranscurrido > DosEstrellas)
            {
                Debug.Log("Una estrella");
            }
        }
    }
}
