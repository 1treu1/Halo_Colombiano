using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationEnemy();
    }

    public void RotationEnemy()
    {
        float angleRadian = Mathf.Atan2(player.position.x - transform.position.x, player.position.z - transform.position.z);
        float angleGrades = (180 / Mathf.PI) * angleRadian;
        transform.rotation = Quaternion.Euler(0, angleGrades, 0);
    }
}
