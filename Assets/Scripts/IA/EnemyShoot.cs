using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform spawnBulletPoint;
    public Transform playerPosition;
    public GameObject flashPrefab;
    public float bulletVelocity = 100;
    private float distanceToPlayer;
    public float distanceToFollowPlayer = 10;
    float i = 0;
    private float shotRateTime = 0;
    public float shotRate = 0.5f;
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;
        //InvokeRepeating("ShootPlayer",1.5f, 0.5f);
    }
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition.position);
        if (Time.time > shotRateTime && distanceToPlayer <= distanceToFollowPlayer)
        {
            ShootPlayer();
            shotRateTime = Time.time + shotRate;
        }
    }


    void ShootPlayer()
    {  
        Vector3 playerDirection = playerPosition.position - transform.position;
        GameObject newBullet;
        newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
        GameObject newFlash;
        newFlash = Instantiate(flashPrefab, spawnBulletPoint.position, spawnBulletPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
        newFlash.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
        Destroy(newBullet, 5f);
        Destroy(newFlash, 2f);
    }
}
