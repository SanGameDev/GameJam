using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class contadorEstrellasTimer : MonoBehaviour
{
    public float tiempoLimite = 60f; // Tiempo l�mite para completar el nivel
    private float tiempoTranscurrido = 0f; // Tiempo que ha pasado desde que se inici� el nivel
    public bool nivelCompletado = false; // Indica si el jugador ha completado el nivel
    public Text textoTiempo; // Referencia al objeto de texto que muestra el tiempo
    public Text textoEstrellas; // Referencia al objeto de texto que muestra el n�mero de estrellas
    public float UnaEstrellas = 40; //Tiempo en el que se dan cada numero de estrellas
    public float TresEstrellas = 30;
    public TimeSpan time;
    public int stars;
    

    void Start()
    {
        tiempoTranscurrido = 0f;
        stars = 0;
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
                CompletarNivel();
                stars = 1;
                ActualizarTextos();
            }
        }
        time = TimeSpan.FromSeconds(tiempoTranscurrido); 
    }

    void ActualizarTextos()
    {
        // Mostrar el tiempo transcurrido y el n�mero de estrellas obtenidas
        textoTiempo.text = time.ToString(@"mm\:ss\:fff");
        textoEstrellas.text = "Estrellas: " + stars.ToString();
    }   
    public void CompletarNivel()
    {
            if (tiempoTranscurrido <= TresEstrellas)
            {
                stars = 3;
            }
            else if (tiempoTranscurrido < UnaEstrellas && tiempoTranscurrido > TresEstrellas)
            {
                stars = 2;
                Debug.Log("dos estrellas");
            }
            else if (tiempoTranscurrido >= UnaEstrellas)
            {
                stars = 1;
            }
    }
}
