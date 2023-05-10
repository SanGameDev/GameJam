using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivel : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorialCanvas;
    public GameObject creditos;

    public void Tutorial()
    {
        mainMenu.SetActive(false);
        tutorialCanvas.SetActive(true);
    }

    public void ExitTutorial()
    {
        mainMenu.SetActive(true);
        tutorialCanvas.SetActive(false);
    }

    public void Creditos()
    {
        mainMenu.SetActive(false);
        creditos.SetActive(true);
    }

    public void ExitCreditos()
    {
        mainMenu.SetActive(true);
        creditos.SetActive(false);
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
