using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
        // Update is called once per frame
    public float speedRotate = 0.50f;
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * speedRotate);
    }
}
