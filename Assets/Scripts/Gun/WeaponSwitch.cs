using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] weapon;
    public int selectWeapon = 0;
    
    void Start()
    {
        SelectWeapon();
        
    }

    // Update is called once per frame
    void Update()
    {
   
        int previusWeapon = selectWeapon;
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
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
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
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

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if(i == selectWeapon)
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
