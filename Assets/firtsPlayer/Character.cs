using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public float gravity = -9.81f;
    public float sphereRadius = 0.3f;
    public float jumpHeight = 3;
    public Transform groundCheck;
    public LayerMask isGround;
    bool isGrounded;
    Vector3 velocity;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, isGround);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float horizontalInput = Input.GetAxis("Horizontal"); //X
        float verticalInput = Input.GetAxis("Vertical"); //Z

        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); 
        }
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        
    }
}
