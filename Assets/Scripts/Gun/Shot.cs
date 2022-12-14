using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnShot; // posicion donde se genera el disparo
    public GameObject bullet; // bala
    public float shotForce = 1500f; //fuarza del disparo
    public float shotRate = 0.5f; //Balas por segundo
    private float shotRateTime = 0; //numero de balas disparadas



    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            if(Time.time > shotRateTime)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnShot.position, spawnShot.rotation); //Genera las balas
                newBullet.GetComponent<Rigidbody>().AddForce(spawnShot.forward * shotForce); //Dispara las balas
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 5f);
            }
        }
    }
}
