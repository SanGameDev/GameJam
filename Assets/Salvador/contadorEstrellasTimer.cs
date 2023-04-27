using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contadorEstrellasTimer : MonoBehaviour
{
    public float tiempoLimite = 60f; // Tiempo límite para completar el nivel
    private float tiempoTranscurrido = 0f; // Tiempo que ha pasado desde que se inició el nivel
    private int numEstrellas = 0; // Número de estrellas obtenidas
    public bool nivelCompletado = false; // Indica si el jugador ha completado el nivel
    public Text textoTiempo; // Referencia al objeto de texto que muestra el tiempo
    public Text textoEstrellas; // Referencia al objeto de texto que muestra el número de estrellas
    public float DosEstrellas = 10; //Tiempo en el que se dan cada numero de estrellas
    public float TresEstrellas = 20;

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
            tiempoTranscurrido += Time.deltaTime;
            ActualizarTextos();

            // Comprobar si se ha superado el tiempo límite
            if (tiempoTranscurrido >= tiempoLimite)
            {
                nivelCompletado = true;
                numEstrellas = 1;
                ActualizarTextos();
            }
        }
        CompletarNivel();
    }

    void ActualizarTextos()
    {
        // Mostrar el tiempo transcurrido y el número de estrellas obtenidas
        textoTiempo.text = "Tiempo: " + Mathf.FloorToInt(tiempoTranscurrido).ToString();
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
