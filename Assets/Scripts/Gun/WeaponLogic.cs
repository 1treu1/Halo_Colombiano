using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    public Transform spawnShot; // posicion donde se genera el disparo
    public GameObject bullet; // bala
    public GameObject flashPrefab;
    public float shotForce = 1500f; //fuarza del disparo
    public float shotRate = 0.5f; //Balas por segundo
    private float shotRateTime = 0; //numero de balas disparadas



    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            if(Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0)
            {
                GameManager.Instance.gunAmmo--;
                GameObject newBullet;
                GameObject newFlash;
                newBullet = Instantiate(bullet, spawnShot.position, spawnShot.rotation); //Genera las balas
                newFlash = Instantiate(flashPrefab, spawnShot.position, spawnShot.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnShot.up * shotForce); //Dispara las balas
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 5f);
                Destroy(newFlash, 2f);
            }
        }
    }
}
