using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class crono2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoCrono;
    [SerializeField] private float tiempo;

    private int tiempoMinutos, tiemposegundos, tiempoDecimasSegundo;

    void Cronometro()
    {
        tiempo += Time.deltaTime;

        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiemposegundos = Mathf.FloorToInt (tiempo % 60);
        tiempoDecimasSegundo = Mathf.FloorToInt((tiempo % 1) * 100);

        textoCrono.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiemposegundos, tiempoDecimasSegundo);
    }
    // Update is called once per frame
    void Update()
    {
        Cronometro();
    }
}
