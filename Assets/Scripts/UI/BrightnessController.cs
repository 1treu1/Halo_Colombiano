using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelBrillo;
    public float blackValue, whiteValue;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brightness", 0.5f);
        //saca el valor del rgb y el ultimo valor es el alfa que sera dado por el slider.value.
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        blackValue = 1 - sliderValue - 0.5f;
        whiteValue = sliderValue - 0.5f;
        if(sliderValue<0.5f)
        {
            panelBrillo.color = new Color(0, 0, 0, blackValue);
        }
        if(sliderValue>0.5f)
        {
            panelBrillo.color = new Color(255, 255, 255, whiteValue);
        }
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brightness", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider.value/3);
    }
}
