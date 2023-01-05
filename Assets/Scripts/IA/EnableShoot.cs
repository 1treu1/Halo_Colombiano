using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShoot : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<EnemyShoot>().enabled = false;
       
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        IA.OnFollow += EnableShootEnemy;
        IA.OnNoFollow += NoEnableShootEnemy;
    }


    void OnDisable()
    {
        IA.OnFollow -= EnableShootEnemy;
        IA.OnNoFollow -= NoEnableShootEnemy;
    }

    void EnableShootEnemy()
    {
        gameObject.GetComponent<EnemyShoot>().enabled = true;
    }
    void NoEnableShootEnemy()
    {
        gameObject.GetComponent<EnemyShoot>().enabled = false;
    }
}
