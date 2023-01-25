using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public AudioSource audio;
    public AudioClip audioShoot;
    public AudioClip audioR;
    public TextMeshProUGUI bulletCounter;
    public TextMeshProUGUI allBullet;
    public Animator animator;

    private void Start()
    {
        DrawSight(cam.transform);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (weaponList.selectWeapon == 0)
        {
            allBullet.SetText(GameManager.Instance.gunMaxAmmo.ToString());
        }
        else
        {
            allBullet.SetText(GameManager.Instance.gunMaxAmmo1.ToString());
        }
        Debug.Log(weaponList.selectWeapon);
        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("Fire");


            if (Time.time > shotRateTime && weaponList.selectWeapon == 0)
            {
                //Debug.Log("1");
                if (GameManager.Instance.gunAmmo > 0)
                {
                    audio.PlayOneShot(audioShoot, 0.2f);
                    //Debug.Log("Weapon 1");

                    bulletCounter.SetText((GameManager.Instance.gunAmmo - 1).ToString());
                    GameManager.Instance.gunAmmo--;

                    Shoot(0);
                    animator.SetBool("Shoot", true);
                    StartCoroutine("Wait");
                    


                }
            }
            if (Time.time > shotRateTime && weaponList.selectWeapon == 1)
            {
                //Debug.Log("2");
                if (GameManager.Instance.gunAmmo1 > 0)
                {
                    audio.PlayOneShot(audioShoot, 0.3f);
                    //Debug.Log("Weapon 2");

                    bulletCounter.SetText((GameManager.Instance.gunAmmo1 - 1).ToString());
                    GameManager.Instance.gunAmmo1--;
                    Shoot(1);
                    audio.PlayOneShot(audioR, 0.1f);
                    //StartCoroutine("Wait");

                }
            }

        }


    }
    void Shoot(int i)
    {
        DrawSight(cam.transform);
        GameObject newBullet;
        GameObject newFlash;
        newBullet = Instantiate(bullet, spawnShot.position, spawnShot.rotation); //Genera las balas
        newFlash = Instantiate(flashPrefab, spawnShot.position, spawnShot.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(spawnShot.forward * shotForce); //Dispara las balas
        newFlash.GetComponent<Rigidbody>().AddForce(spawnShot.forward * shotForce); //Dispara las balas
       
        shotRateTime = Time.time + shotRate;
        if (i == 0)
            Destroy(newFlash, 0.02f);
        else
            Destroy(newFlash, 2f);
        Destroy(newBullet, 5f);

    }
    public void DrawSight(Transform camera)
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit))
        {
            spawnShot.LookAt(hit.point);
        }
        else
        {
            Vector3 end = camera.position + camera.forward;
            spawnShot.LookAt(end);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Shoot", false);
    }
}
