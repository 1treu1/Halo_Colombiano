using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int playerLife;
    public Slider barLifePlayer;
   

    // Update is called once per frame
    void Update()
    {
        if (playerLife <= 0)
        {
            Debug.Log("Game Over");
        }
        barLifePlayer.GetComponent<Slider>().value = playerLife;
    }
}
