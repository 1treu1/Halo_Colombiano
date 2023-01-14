using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    
    public Animator animator;
    public bool isScoped = false;
    public GameObject scopeOverlay;
    public GameObject weaponCamara;
    public GameObject[] rifleChildren;
    private GameObject sniperBody;
    private GameObject sniperScope;
    public GameObject rifle;
    

    // Update is called once per frame
    private void Start()
    {
        rifleChildren = new GameObject[rifle.transform.childCount];
        for (int i = 0; i < rifleChildren.Length; i++)
        {
            rifleChildren[i] = rifle.transform.GetChild(i).gameObject;
        }
        sniperBody = rifleChildren[0];
        sniperScope = rifleChildren[0].transform.GetChild(0).gameObject;
    }
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
        
        //weaponCamara.SetActive(false);
        sniperBody.SetActive(false);

    }
    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        
        //weaponCamara.SetActive(true);  
        sniperBody.SetActive(true);  
    }
}
