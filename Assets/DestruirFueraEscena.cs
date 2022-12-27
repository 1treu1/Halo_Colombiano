using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirFueraEscena : MonoBehaviour
{
    float limiteSuperior = 30;
    float limiteInferior = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > limiteSuperior) 
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < limiteInferior)
        {
            Destroy(gameObject);
            Debug.Log ("Fin de Partida!");
        }
    }
}
