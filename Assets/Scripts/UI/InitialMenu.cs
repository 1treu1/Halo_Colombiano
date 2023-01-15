using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Libreria necesaria para hacer los cambios de escena

public class InitialMenu : MonoBehaviour
{
   //Funcion para cambiar de escena
   public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Game()
    {
        Time.timeScale = 1;
    }
    //Funcion para salir del juego 

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
