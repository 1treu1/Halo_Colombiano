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
    public Camera cam;
    public WeaponSwitch weaponList;



    void Update()
    {
        Debug.Log(weaponList.selectWeapon);
        if (Input.GetButtonDown("Fire1")){
            Debug.Log("Fire");
            if (Time.time > shotRateTime && weaponList.selectWeapon == 0)
            {
                Debug.Log("1");
                if (GameManager.Instance.gunAmmo > 0)
                {
                    Debug.Log("Weapon 1");
                    GameManager.Instance.gunAmmo--;
                    Shoot();


                }
            }
            if (Time.time > shotRateTime && weaponList.selectWeapon == 1)
            {
                Debug.Log("2");
                if (GameManager.Instance.gunAmmo1 > 0)
                {
                    Debug.Log("Weapon 2");
                    GameManager.Instance.gunAmmo1--;
                    Shoot();

                }
            }

        }
    }
    void Shoot()
    {
        DrawSight(cam.transform);
        GameObject newBullet;
        GameObject newFlash;
        newBullet = Instantiate(bullet, spawnShot.position, spawnShot.rotation); //Genera las balas
        newFlash = Instantiate(flashPrefab, spawnShot.position, spawnShot.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnShot.forward * shotForce); //Dispara las balas
        newFlash.GetComponent<Rigidbody>().AddForce(spawnShot.forward * shotForce); //Dispara las balas
        shotRateTime = Time.time + shotRate;
        Destroy(newBullet, 5f);
        Destroy(newFlash, 2f);
    }
    public void DrawSight(Transform camera)
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit))
        {
            spawnShot.LookAt(hit.point);
        }
        else
        {
            Vector3 end = camera.position + camera.forward;
            spawnShot.LookAt(end);
        }
    }
}
