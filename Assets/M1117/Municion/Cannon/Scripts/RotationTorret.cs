using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTorret : MonoBehaviour
{
    public float sensibilidadRaton = 120.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xR = Input.GetAxis("Mouse X") * sensibilidadRaton * Time.deltaTime;
        transform.Rotate(0, xR, 0);
    }
}
