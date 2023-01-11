using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage;
    [SerializeField] public PlayerData Player;
    

    //cuando la bala choca con el personaje
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Player.playerLife -= damage;
        }

        if(other.tag == "Enemy")
        {
            Debug.Log("Este es el enemigo");
        }
    }

}
