using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public float balas_disparadas=0;
    public float balas_necesarias=5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
  {
    print(other.gameObject.tag);
    if(other.gameObject.tag == "Player")
    {
        balas_disparadas += 1;
        //Destroy(other.gameObject);
        if(balas_necesarias == balas_disparadas)
        {
            GameManager.Instance.AddEnemyKill();
            Destroy(this.gameObject);
        }
    }


  }
  
}
