using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    
    public Animator animator;
    private bool isScoped = false;
    public GameObject scopeOverlay;
    public GameObject weaponCamara;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scope", isScoped);
            scopeOverlay.SetActive(isScoped);
            if (isScoped)
                StartCoroutine( OnScoped());
            else
                OnUnScoped();
        }
        
    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);
        scopeOverlay.SetActive(true);
        weaponCamara.SetActive(false);

    }
    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);  
        weaponCamara.SetActive(true);  
    }
}
