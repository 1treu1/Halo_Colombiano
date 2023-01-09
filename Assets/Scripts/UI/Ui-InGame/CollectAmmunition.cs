using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAmmunition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ammunition"))
        {
            Destroy(other.gameObject);


        }
    }

}
