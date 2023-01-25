using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public float playerLife = 100;
    public Slider barLifePlayer;
    public TextMeshProUGUI lifeText;
    public int counterHealth = 0;


    //public TMPro.TextMeshProUGUI bulletCounter;
    //private int amountOfBales = 0;//cantidad de balas

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
            playerLife = 0;
        }
         barLifePlayer.GetComponent<Slider>().value = playerLife;
        if(Input.GetKeyDown(KeyCode.Q) && counterHealth >= 0)
        {
            playerLife += 60;
            counterHealth -= 1;
        }
            
        //se muestre la cantidad de balas
        //bulletCounter.text = amountOfBales.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            if (playerLife <= 0)
            {
                playerLife = 0;
                SceneManager.LoadScene(0);
                Destroy(gameObject, 0.5f);

            }
            playerLife -= 25;
        }
        if (other.tag == "HealthBox")
        {
            if (playerLife >= 100)
            {
                playerLife = 100;
                counterHealth += 1;
            }
            else
            {
                playerLife += 60;
            }
           
        }


    }


}
