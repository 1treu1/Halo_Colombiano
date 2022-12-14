using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//libreria para ui, habilita los comando del canvas

public class VolumenUi : MonoBehaviour
{
    public Slider slider; //referenciar el slider
    public float sliderValue;
    public Image imageMute;
   
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumenAudio", 0.5f);//playerprefs es una variable que se mantiene guardada en el juego
        //y le diremos que tenga una valor predefinido de 0.5, osea cuando se inicie el juego por vez primera tendra ese valor.
        AudioListener.volume = slider.value;//que valor tendra el volumen? el valor del slider.value
        Mute();
    }

  public void ChangeSlider(float valor)//el valor del slider sera igual al valor que tenga esta funcion "valor"
        //que es el value que esta en el inspector
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("VolumenAudio", sliderValue);//aqui le ponemos un valor a la variable "VolumenAudio"
        //con getfloat lo llamamos y con setfloat le asignamos un valor
        AudioListener.volume = slider.value;
        Mute();
    }

    public void Mute()//si el valor del slider es = 0 saca un icono de muet
    {
        if(sliderValue == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }
}
