using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRadar : MonoBehaviour
{
    public bool active;

    private void Update()
    {
        if(active)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(Time());
            Debug.Log("DetectadoPapu");
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(2);  //tiempo que dura activo el enemigo en el radar.
        active = false;
    }
}
