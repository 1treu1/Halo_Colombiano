using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            GameManager.Instance.gunAmmo1 += other.gameObject.GetComponent<AmmoBox>().ammo1;
            if (GameManager.Instance.gunAmmo > GameManager.Instance.gunMaxAmmo)
                GameManager.Instance.gunMaxAmmo = GameManager.Instance.gunAmmo;
            if (GameManager.Instance.gunAmmo1 > GameManager.Instance.gunMaxAmmo1)
                GameManager.Instance.gunMaxAmmo1 = GameManager.Instance.gunAmmo1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("HealthBox"))
        {

            GameManager.Instance.AddHealth(other.gameObject.GetComponent<HealthBox>().healthBox);
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Muerto");
            //Destroy(gameObject);
        }
    }
}
