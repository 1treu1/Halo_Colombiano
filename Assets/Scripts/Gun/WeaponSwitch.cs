using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] weapon;
    public int selectWeapon = 0;
    public Scope statusSight;
    

    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGun) { 
   
            int previusWeapon = selectWeapon;
            if(Input.GetAxis("Mouse ScrollWheel") > 0 &&  statusSight.isScoped == false)
            {
                if(selectWeapon >= weapon.Length - 1)
                {
                    selectWeapon = 0;
                }
                else
                {
                    selectWeapon++;
                   
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && statusSight.isScoped == false)
            {
                if (selectWeapon <= 0)
                {
                    selectWeapon = weapon.Length-1;
                }
                else
                {
                    selectWeapon--;
                    
                }
            }
            if(previusWeapon != selectWeapon)
            {
                SelectWeapon();
            }
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if(i == selectWeapon && statusSight.isScoped == false)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
                i++;
            }
        }
    }
}
