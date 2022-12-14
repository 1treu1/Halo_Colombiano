using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;//textmechpro

public class ImageQuality : MonoBehaviour
{
    public TMP_Dropdown dropdown;//para referencias
    public int quality;//el numero entero que va a cambiar el valor 
    // Start is called before the first frame update
    void Start()
    {
        quality = PlayerPrefs.GetInt("numberOfQuality", 4);//el valor predefinido va a ser alto, por eso ponemos el 3
        dropdown.value = quality;//sacamos la variable de valor del dropdown
        adjustquality();//aplica la funcion de ajuste de calida que se creo abajo
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void adjustquality()//funcion para cambiar los valores del proyect settings en quality
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numberOfQuality", dropdown.value);//con setint cambiamos el valor 
        quality = dropdown.value;
    }

}
