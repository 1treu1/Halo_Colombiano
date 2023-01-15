using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsEsceneController : MonoBehaviour
{
    public OptionsController panelOptions;//referencia al codigo OptionsControlles
    private bool isMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        panelOptions = GameObject.FindGameObjectWithTag("Options").GetComponent<OptionsController>();//Obtener el componente de OptionsController al objeto que lo tiene
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//precionar la tecla Esc para que se active la funcion de mostrar opciones
        {
            isMenu = !isMenu;
            ShowOptions(isMenu);
            
        }
     
    }
    public void ShowOptions(bool menu)
    {
        if (menu)
        {
            Time.timeScale = 0;
            panelOptions.optionsScreen.SetActive(menu);//Funcion que activa el panel de opciones
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            panelOptions.optionsScreen.SetActive(menu);//Funcion que activa el panel de opciones
            Cursor.lockState = CursorLockMode.Locked ;
            Cursor.visible = false;
            Time.timeScale = 1;

        }
       
       

    }
}
