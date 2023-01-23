using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove ;
    public float speed = 1;
    public GameObject mover;
    
    
    
        
    private void Start()
    {
        Cursor.lockState = CursorLockMode. Locked;
    }

    
    
    private void Update()
    {
        turn.x += Input.GetAxis ("Mouse X") * sensitivity;
        turn.y -= Input.GetAxis ( "Mouse Y") * sensitivity;
        mover.transform.localRotation = Quaternion . Euler (0, 0, -turn.y);
        turn.y = Mathf.Clamp(turn.y, -45, 4);
        //transform. localRotation = Quaternion . Euler (0, turn.x, 0);
    }

}    