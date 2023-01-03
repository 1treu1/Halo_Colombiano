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
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;
        Invoke("ShootPlayer", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShootPlayer()
    {
        Vector3 playerDirection = playerPosition.position - transform.position;
        GameObject newBullet;
        newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);
        GameObject newFlash;
        newFlash = Instantiate(flashPrefab, spawnBulletPoint.position, spawnBulletPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection*bulletVelocity, ForceMode.Force);
        Invoke("ShootPlayer", 3);
    }
}
