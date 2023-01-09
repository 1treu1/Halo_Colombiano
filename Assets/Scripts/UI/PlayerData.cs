using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public float playerLife = 100;
    public Slider barLifePlayer;
    public TextMeshProUGUI lifeText;

    public TMPro.TextMeshProUGUI bulletCounter;
    private int amountOfBales = 0;//cantidad de balas

    void Start()
    {
        lifeText.text = "" + playerLife + "%";//comillas para transformar la vida e un texto
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "" + playerLife + "%";
         
        if (playerLife <= 0)
        {
            Debug.Log("Game Over");
        }
         barLifePlayer.GetComponent<Slider>().value = playerLife;

        //se muestre la cantidad de balas
        bulletCounter.text = amountOfBales.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammunition"))
        {
            Destroy(other.gameObject);
         amountOfBales += 30;

        }
    }


}
