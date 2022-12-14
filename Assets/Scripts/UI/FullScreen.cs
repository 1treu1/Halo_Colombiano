using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        checkresolution();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    public void checkresolution()
    {
        resolutions = Screen.resolutions;//varia dependiendo de la pc, detecta  las resoluciones del pc y sale en el menui de opciones
        resolutionDropdown.ClearOptions();//borrar las opciones que tenemos(a, b,c.)
        List<string> options = new List<string>();//crea una lista nueva  donde s eva a guardar el tamaño de la resolucion para mostrarlo en los despegables
        int actualResolution = 0;//inicializar en 0

        for (int i = 0; i < resolutions.Length; i++)//si la pc tiene 10 resoluciones entonces hara este for 10 veces
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;//ancho por alto
            options.Add(option);//se guarda el valor ej: 300x200

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)//verifica si actualmente el juego esta en tal resolucion para luego mostrarla
            {
                actualResolution = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = actualResolution;//detecta en que resolucion nos encontramos
        resolutionDropdown.RefreshShownValue();//actualiza la lista que tenemos guardada

        resolutionDropdown.value = PlayerPrefs.GetInt("numberResolution", 0);
    }
    public void ChangeResolution(int indiceResolution)
    {

        PlayerPrefs.SetInt("numberResolution", resolutionDropdown.value);

        Resolution resolution = resolutions[indiceResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);//detecta si estamos en pantalla completa o no.
    }
    
}
