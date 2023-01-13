using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Inicio()
    {
        SceneManager.LoadScene(1);
    }

    public void Abandonar()
    {
        Application.Quit();
        Debug.Log("Saliendo de la Mision!!!");
    }
}
