using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    float countdown;
    public float radius = 5;
    public float explosionForce = 70;
    bool exploded = false;
    public GameObject explosionEffect;
    public AudioSource audio;
    public AudioClip soundCollision;
    public AudioClip soundGrenade;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && exploded == false)
        {
            Explode();
            exploded = true;
            audio.PlayOneShot(soundGrenade);
            Debug.Log("Exploded");
        }
    }
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(var rangeObjects in colliders)
        {
            IA ia = rangeObjects.GetComponent<IA>();
            if(ia != null)
            {
                ia.GrenadeImpact();
            }
            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce * 10, transform.position, radius);
            }
        }
        exploded = false;
        Destroy(gameObject, 0.8f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            
            audio.PlayOneShot(soundCollision);
        }
    }
  
}
