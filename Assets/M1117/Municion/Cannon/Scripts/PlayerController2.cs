using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public bool Shooting;
    public PistolController pistol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        ActionsControl();
        ItemsControl();
    }

    public void ActionsControl()
    {
        Shooting = Input.GetKeyDown(KeyCode.Mouse0);
    }
    public void ItemsControl()
    {
        if (pistol != null)
        {
            if(Shooting)
            {
                pistol.Shoot();
            }
        }
    }
}
