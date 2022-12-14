using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsEsceneController : MonoBehaviour
{
    public OptionsController panelOptions;//referencia al codigo OptionsControlles
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
            ShowOptions();
        }
    }
    public void ShowOptions()
    {

        panelOptions.optionsScreen.SetActive(true);//Funcion que activa el panel de opciones

    }
}
