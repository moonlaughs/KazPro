using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController control;
    Vector3 velocity;
    public Transform ground;
    public LayerMask groundMask;
    bool isOnTheGround;

    [SerializeField]
    private float groundDistance = 0.5f;
    private float gravity = -50f;
    [SerializeField]
    private int movementSpeed;
    [SerializeField]
    private int jumpHeight;


    void Update()
    {
        //Checking if player is on the ground
        isOnTheGround = Physics.CheckSphere(ground.position, groundDistance, groundMask);

        if(isOnTheGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Setting the axis 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Vector 3 takes direction of player facing going right or forward
        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;

        control.Move(movement * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isOnTheGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
    }
}
