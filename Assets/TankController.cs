using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    Rigidbody rg;
    public float tankSpeed;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }


    void FixeUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    }
}