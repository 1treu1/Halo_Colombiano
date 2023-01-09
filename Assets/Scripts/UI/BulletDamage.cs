using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage;
    public GameObject Player;
    

    //cuando la bala choca con el personaje
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Player.GetComponent<PlayerData>().playerLife -= damage;
        }

        if(other.tag == "Enemy")
        {
            Debug.Log("Este es el enemigo");
        }
    }

}
