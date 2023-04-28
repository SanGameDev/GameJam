using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;   //Aqui arrastramos los botones del canvas, el de pausa y abajo el de menu
    [SerializeField] private GameObject menuDePausa;
    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()   //Al adjuntarlo en unity aparece la opcion de OnClick, ahi seleccionamos esta funcion y tenemos que asignarle el canvas
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuDePausa.SetActive(true);
    }

    public void Reanudar()   //Hay que agregar esta funcion en el OnClick
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuDePausa.SetActive(false);
    }


    public void Reiniciar()

    {
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        Debug.Log("Saliendo..."); //Hay que quitar esto, solo es para ver si funciona
        Application.Quit();
    }
}
