using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float throwForce = 500;
    public GameObject grenadePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Throw();
        }
    }

    public void Throw()
    {
        GameObject newGrenade = Instantiate(grenadePrefab , transform.position, transform.rotation);
        newGrenade.GetComponent<Rigidbody>().AddForce(transform.up * throwForce);

    }
}
