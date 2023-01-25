using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
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
